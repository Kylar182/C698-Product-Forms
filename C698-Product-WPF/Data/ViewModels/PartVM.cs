using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows;
using C698_Product_WPF.Commands;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Persistence.Repositories.Interfaces;

namespace C698_Product_WPF.Data.ViewModels
{
  public class PartVM : BaseVM
  {
    private readonly IPartRepository _repository;
    public bool Deleting => (CUD == CUD.Delete) ? true : false;
    public string CUDString => CUD.ToString();
    public string WindowLabel => CUDString + " Part";
    public string InOut => (Source == Source.InHouse) ? "Machine ID" : "Company Name";

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
        OnPropertyChanged(nameof(Max));
      }
    }

    private Source source;
    public Source Source
    {
      get { return source; }
      set
      {
        source = value;
        OnPropertyChanged(nameof(Source));
      }
    }

    private CUD cud;
    public CUD CUD
    {
      get { return cud; }
      set
      {
        cud = value;
        OnPropertyChanged(nameof(CUD));
      }
    }

    private int machineId;
    public int MachineId
    {
      get { return machineId; }
      set
      {
        machineId = value;
        OnPropertyChanged(nameof(MachineId));
      }
    }

    private string companyName;
    public string CompanyName
    {
      get { return companyName; }
      set
      {
        companyName = value;
        OnPropertyChanged(nameof(CompanyName));
      }
    }

    public Visibility MachineIdShow => (Source == Source.InHouse) ? Visibility.Visible : Visibility.Hidden;
    public Visibility CompanyNameShow => (Source == Source.OutSourced) ? Visibility.Visible : Visibility.Hidden;
    public Visibility AddUpdateThis => (CUD == CUD.Add || CUD == CUD.Modify) ? Visibility.Visible : Visibility.Hidden;
    public Visibility DeleteThis => (CUD == CUD.Delete) ? Visibility.Visible : Visibility.Hidden;

    private AddUpdatePart addUpdatePart;
    public AddUpdatePart AddUpdatePart
    {
      get { return addUpdatePart; }
      set
      {
        addUpdatePart = value;
        OnPropertyChanged(nameof(AddUpdatePart));
      }
    }
    private DeletePart deletePart;
    public DeletePart DeletePart
    {
      get { return deletePart; }
      set
      {
        deletePart = value;
        OnPropertyChanged(nameof(DeletePart));
      }
    }

    public PartVM()
    {
      AddUpdatePart = new AddUpdatePart(this);
      DeletePart = new DeletePart(this);
    }

    public PartVM(IPartRepository repository, CUD cud)
    {
      _repository = repository;
      CUD = cud;
      AddUpdatePart = new AddUpdatePart(this);
      DeletePart = new DeletePart(this);
    }

    public static PartVM LoadVM(IPartRepository repository, int id, CUD cud)
    {
      PartVM part = new PartVM(repository, cud);
      part.LoadPart(id);
      return part;
    }

    private void LoadPart(int id)
    {
      Part part = new Part();
      _repository.GetById(id).ContinueWith(t =>
      {
        if (t.Exception == null)
        {
          part = t.Result;
          Id = id;
          Name = part.Name;
          Price = part.Price;
          InStock = part.InStock;
          Min = part.Min;
          Max = part.Max;
          Source = part.Source;
          if (part.Source == Source.InHouse)
            MachineId = Convert.ToInt32(part.InOut);
          else
            CompanyName = part.InOut;
          if (CUD == CUD.Modify)
            AddUpdatePart = new AddUpdatePart(this);
          else
            DeletePart = new DeletePart(this);
        }
      });
    }

    public async Task Add()
    {
      await _repository.AddItem(new Part(this));
    }

    public async Task Update()
    {
      await _repository.UpdateItem(new Part(this));
    }

    public async Task Delete()
    {
      await _repository.Delete(this.Id.Value);
    }
  }
}
