using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Persistence.Repositories.Interfaces;

namespace C698_Product_WPF.Data.ViewModels
{
  public class PartVM : BaseVM
  {
    private readonly IPartRepository _repository;
    public string WindowLabel;
    public string InOut;

    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public Source Source { get; set; }
    public CUD CUD { get; set; }

    public int MachineId { get; set; }

    public string CompanyName { get; set; }

    public Visibility MachineIdShow { get; set; }
    public Visibility CompanyNameShow { get; set; }

    public PartVM()
    {
      WindowLabel = CUD.ToString() + " Part";
      InOut_Switch(Source.InHouse);
    }

    public PartVM(IPartRepository repository)
    {
      _repository = repository;
    }

    public static PartVM LoadVM(IPartRepository repository, int id, CUD cud)
    {
      PartVM part = new PartVM(repository);
      part.LoadPart(id, cud);
      return part;
    }

    private void LoadPart(int id, CUD cud)
    {
      Part part = new Part();
      _repository.GetById(id).ContinueWith(t =>
      {
        if (t.Exception == null)
        {
          part = t.Result;
          Name = part.Name;
          Price = part.Price;
          InStock = part.InStock;
          Min = part.Min;
          Max = part.Max;
          Source = part.Source;
          CUD = cud;
          if (part.Source == Source.InHouse)
            MachineId = Convert.ToInt32(part.InOut);
          else
            CompanyName = part.InOut;
        }
      });
      InOut_Switch(part.Source);
      WindowLabel = CUD.ToString() + " Part";
    }

    private async Task Update()
    {
      await _repository.UpdateItem(new Part(this));
    }

    private async Task Delete()
    {
      await _repository.Delete(this.Id.Value);
    }

    private void InOut_Switch(Source source)
    {
      switch (source)
      {
        case Source.InHouse:
          InOut = "Machine ID";
          MachineIdShow = Visibility.Visible;
          CompanyNameShow = Visibility.Hidden;
          break;
        case Source.OutSourced:
          InOut = "Company Name";
          MachineIdShow = Visibility.Hidden;
          CompanyNameShow = Visibility.Visible;
          break;
      }
    }
  }
}
