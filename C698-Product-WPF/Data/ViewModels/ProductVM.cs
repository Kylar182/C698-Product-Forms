using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using C698_Product_WPF.Commands;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.Supervisors.Interfaces;

namespace C698_Product_WPF.Data.ViewModels
{
  public class ProductVM : BaseVM
  {
    private readonly IProductSupervisor _supervisor;
    public bool Deleting => (CUD == CUD.Delete);

    [Range(0.00, 99999999999.99)]
    private decimal price;
    [Range(0.00, 99999999999.99)]
    public decimal Price
    {
      get { return price; }
      set
      {
        price = value;
        OnPropertyChanged(nameof(Price));
      }
    }

    private int inStock;
    public int InStock
    {
      get { return inStock; }
      set
      {
        inStock = value;
        AddUpdateProduct = new AddUpdateProduct(this);
        OnPropertyChanged(nameof(InStock));
      }
    }

    private int min;
    public int Min
    {
      get { return min; }
      set
      {
        min = value;
        AddUpdateProduct = new AddUpdateProduct(this);
        OnPropertyChanged(nameof(Min));
      }
    }

    private int max;
    public int Max
    {
      get { return max; }
      set
      {
        max = value;
        AddUpdateProduct = new AddUpdateProduct(this);
        OnPropertyChanged(nameof(Max));
      }
    }

    private CUD cud;
    public CUD CUD
    {
      get { return cud; }
      set
      {
        cud = value;
        CUDString = cud.ToString();
        OnPropertyChanged(nameof(CUD));
      }
    }
    private string cudString;
    public string CUDString
    {
      get { return cudString; }
      set
      {
        cudString = value;
        WindowLabel = cudString + " Product";
        OnPropertyChanged(nameof(CUDString));
      }
    }
    private string windowLabel;
    public string WindowLabel
    {
      get { return windowLabel; }
      set
      {
        windowLabel = value;
        OnPropertyChanged(nameof(WindowLabel));
      }
    }

    private Part partSelected;
    public Part PartSelected
    {
      get { return partSelected; }
      set
      {
        partSelected = value;
        AddPartProduct = new AddPartProduct(this);
        OnPropertyChanged(nameof(PartSelected));
      }
    }

    private PartProductDTO partProductSelected;
    public PartProductDTO PartProductSelected
    {
      get { return partProductSelected; }
      set
      {
        partProductSelected = value;
        RemovePartProduct = new RemovePartProduct(this);
        OnPropertyChanged(nameof(PartProductSelected));
      }
    }

    public Visibility AddUpdateThis => (CUD == CUD.Add || CUD == CUD.Modify) ? Visibility.Visible : Visibility.Hidden;
    public Visibility DeleteThis => (CUD == CUD.Delete) ? Visibility.Visible : Visibility.Hidden;

    private int? search;
    public int? Search
    {
      get { return search; }
      set
      {
        search = value;
        SearchParts = new SearchParts(this);
        OnPropertyChanged(nameof(Search));
      }
    }

    private SearchParts searchParts;
    public SearchParts SearchParts
    {
      get { return searchParts; }
      set
      {
        searchParts = value;
        OnPropertyChanged(nameof(SearchParts));
      }
    }

    private AddPartProduct addPartProduct;
    public AddPartProduct AddPartProduct
    {
      get { return addPartProduct; }
      set
      {
        addPartProduct = value;
        OnPropertyChanged(nameof(AddPartProduct));
      }
    }

    private RemovePartProduct removePartProduct;
    public RemovePartProduct RemovePartProduct
    {
      get { return removePartProduct; }
      set
      {
        removePartProduct = value;
        OnPropertyChanged(nameof(RemovePartProduct));
      }
    }

    private AddUpdateProduct addUpdateProduct;
    public AddUpdateProduct AddUpdateProduct
    {
      get { return addUpdateProduct; }
      set
      {
        addUpdateProduct = value;
        OnPropertyChanged(nameof(AddUpdateProduct));
      }
    }
    private DeleteProduct deleteProduct;
    public DeleteProduct DeleteProduct
    {
      get { return deleteProduct; }
      set
      {
        deleteProduct = value;
        OnPropertyChanged(nameof(DeleteProduct));
      }
    }

    private CloseProduct closeProduct;
    public CloseProduct CloseProduct
    {
      get { return closeProduct; }
      set
      {
        closeProduct = value;
        OnPropertyChanged(nameof(CloseProduct));
      }
    }

    public Action CloseAction { get; set; }

    private bool? dialogResult;
    public bool? DialogResult
    {
      get { return dialogResult; }
      set
      {
        dialogResult = value;
        OnPropertyChanged(nameof(DialogResult));
      }
    }

    public ObservableCollection<PartProductDTO> PartProducts { get; set; }
    public ObservableCollection<Part> Parts { get; set; }

    public ProductVM() { }

    public ProductVM(IProductSupervisor supervisor, CUD cud)
    {
      _supervisor = supervisor;
      CUD = cud;
      SearchParts = new SearchParts(this);
      AddUpdateProduct = new AddUpdateProduct(this);
      DeleteProduct = new DeleteProduct(this);
      CloseProduct = new CloseProduct(this);
      AddPartProduct = new AddPartProduct(this);
      RemovePartProduct = new RemovePartProduct(this);
      PartProducts = new ObservableCollection<PartProductDTO>();
      Parts = new ObservableCollection<Part>();
      _supervisor.GetAllParts().ContinueWith(t =>
      {
        if (t.Exception == null)
        {
          List<Part> PartList = t.Result;
          foreach (Part part in PartList)
            Parts.Add(part);
        }
      });
    }

    public static ProductVM LoadVM(IProductSupervisor supervisor, int id, CUD cud)
    {
      ProductVM product = new ProductVM(supervisor, cud);
      product.LoadProduct(id);
      return product;
    }

    private void LoadProduct(int id)
    {
      ProductDTO product = new ProductDTO();
      _supervisor.GetById(id).ContinueWith(t =>
      {
        if (t.Exception == null)
        {
          product = t.Result;
          Id = id;
          Name = product.Name;
          Price = product.Price;
          InStock = product.InStock;
          Min = product.Min;
          Max = product.Max;
          if (CUD == CUD.Modify)
            AddUpdateProduct = new AddUpdateProduct(this);
          else
            DeleteProduct = new DeleteProduct(this);
          foreach (PartProduct part in product.Parts)
            PartProducts.Add(new PartProductDTO(part, CUD));
        }
      });
    }

    public async Task SearchPart()
    {
      List<Part> PartList = await _supervisor.GetAllParts();
      Parts.Clear();

      if (Search != null)
        PartList = PartList.Where(x => x.Id == Search.Value).ToList();  

      foreach (Part part in PartList)
        Parts.Add(part);
    }

    public void AddPart(Part part)
    {
      PartProducts.Add(new PartProductDTO(part, CUD));
      DeleteProduct = new DeleteProduct(this);
    }

    public void RemovePart(PartProductDTO part)
    {
      PartProducts.Remove(part);
      DeleteProduct = new DeleteProduct(this);
    }

    public async Task Add()
    {
      await _supervisor.AddItem(new Product(this));
      Close();
    }

    public async Task Update()
    {
      await _supervisor.UpdateItem(new Product(this));
      Close();
    }

    public async Task Delete()
    {
      await _supervisor.Delete(this.Id.Value);
      Close();
    }

    public void Close()
    {
      CloseAction();
    }
  }
}
