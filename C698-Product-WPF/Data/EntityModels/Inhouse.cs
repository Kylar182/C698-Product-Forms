using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels.Types;

namespace C698_Product_WPF.Data.EntityModels
{
  public class Inhouse : Part
  {
    public int MachineId { get; set; }

    public Inhouse() { }

    public Inhouse(PartDTO part, CUD cud)
    {
      if (cud != CUD.Add)
        Id = part.Id.Value;

      Name = part.Name;
      Price = part.Price;
      InStock = part.InStock;
      Min = part.Min;
      Max = part.Max;
      MachineId = part.MachineId;
    }
  }
}
