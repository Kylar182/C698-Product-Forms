using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels.Types;

namespace C698_Product_WPF.Data.EntityModels
{
  public class OutSourced : Part
  {
    public string CompanyName { get; set; }

    public OutSourced() { }

    public OutSourced(PartDTO part, CUD cud)
    {
      if (cud != CUD.Add)
        Id = part.Id.Value;

      Name = part.Name;
      Price = part.Price;
      InStock = part.InStock;
      Min = part.Min;
      Max = part.Max;
      CompanyName = part.CompanyName;
    }
  }
}
