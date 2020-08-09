using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows;
using C698_Product_WPF.Commands;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.Supervisors.Interfaces;

namespace C698_Product_WPF.Data.ViewModels
{
  public class PartVM : BaseVM
  {
    private readonly IPartSupervisor _supervisor;
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
        AddUpdatePart = new AddUpdatePart(this);
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
        AddUpdatePart = new AddUpdatePart(this);
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
        AddUpdatePart = new AddUpdatePart(this);
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
        InHouse = (source == Source.InHouse) ? true : false;
        Outsourced = (source == Source.OutSourced) ? true : false;
        InOut = (source == Source.InHouse) ? "Machine ID" : "Company Name";
        MachineIdShow = (source == Source.InHouse) ? Visibility.Visible : Visibility.Hidden;
        CompanyNameShow = (source == Source.OutSourced) ? Visibility.Visible : Visibility.Hidden;
        OnPropertyChanged(nameof(Source));
      }
    }
    private string inOut;
    public string InOut
    {
      get { return inOut; }
      set
      {
        inOut = value;
        OnPropertyChanged(nameof(InOut));
      }
    }
    private bool inHouse;
    public bool InHouse
    {
      get { return inHouse; }
      set
      {
        inHouse = value;
        OnPropertyChanged(nameof(InHouse));
      }
    }
    private bool outsourced;
    public bool Outsourced
    {
      get { return outsourced; }
      set
      {
        outsourced = value;
        OnPropertyChanged(nameof(Outsourced));
      }
    }
    private Visibility machineIdShow;
    public Visibility MachineIdShow
    {
      get { return machineIdShow; }
      set
      {
        machineIdShow = value;
        OnPropertyChanged(nameof(MachineIdShow));
      }
    }
    private Visibility companyNameShow;
    public Visibility CompanyNameShow
    {
      get { return companyNameShow; }
      set
      {
        companyNameShow = value;
        OnPropertyChanged(nameof(CompanyNameShow));
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
        WindowLabel = cudString + " Part";
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
        OnPropertyChanged(nameof(CUDString));
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

    private PartSource partSource;
    public PartSource PartSource
    {
      get { return partSource; }
      set
      {
        partSource = value;
        OnPropertyChanged(nameof(PartSource));
      }
    }

    private ClosePart closePart;
    public ClosePart ClosePart
    {
      get { return closePart; }
      set
      {
        closePart = value;
        OnPropertyChanged(nameof(ClosePart));
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

    public PartVM()
    {
      Source = Source.InHouse;
      AddUpdatePart = new AddUpdatePart(this);
      DeletePart = new DeletePart(this);
      PartSource = new PartSource(this);
      ClosePart = new ClosePart(this);
    }

    public PartVM(IPartSupervisor supervisor, CUD cud)
    {
      _supervisor = supervisor;
      CUD = cud;
      Source = Source.InHouse;
      AddUpdatePart = new AddUpdatePart(this);
      DeletePart = new DeletePart(this);
      PartSource = new PartSource(this);
      ClosePart = new ClosePart(this);
    }

    public static PartVM LoadVM(IPartSupervisor supervisor, int id, CUD cud)
    {
      PartVM part = new PartVM(supervisor, cud);
      part.LoadPart(id);
      return part;
    }

    private void LoadPart(int id)
    {
      PartDTO part = new PartDTO();
      _supervisor.GetById(id).ContinueWith(t =>
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
            MachineId = part.MachineId;
          else
            CompanyName = part.CompanyName;
          if (CUD == CUD.Modify)
            AddUpdatePart = new AddUpdatePart(this);
          else
            DeletePart = new DeletePart(this);
        }
      });
    }

    public async Task Add()
    {
      await _supervisor.AddItem(new Part(this));
      Close();
    }

    public async Task Update()
    {
      await _supervisor.UpdateItem(new Part(this));
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
