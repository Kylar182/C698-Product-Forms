using System;
using System.ComponentModel.DataAnnotations;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;

namespace C698_Product_WPF.Data.DTOs
{
  public class PartProductDTO : BaseDTO
  {
    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public int? ProductId { get; set; }
    public int PartId { get; set; }

    public CUD CUD { get; set; }

    public PartProductDTO() { }

    public PartProductDTO(PartDTO part, CUD cud)
    {
      Name = part.Name;
      Price = part.Price;
      InStock = part.InStock;
      Min = part.Min;
      Max = part.Max;
      CUD = cud;
      PartId = part.Id.Value;
    }

    public PartProductDTO(PartProduct part, PartDTO dto, CUD cud)
    {
      Id = part.Id;
      Name = dto.Name;
      Price = dto.Price;
      InStock = dto.InStock;
      Min = dto.Min;
      Max = dto.Max;
      CUD = cud;
      PartId = part.PartId;
      ProductId = part.ProductId;
    }
  }
}
