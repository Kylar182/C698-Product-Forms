using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels.Types;

namespace C698_Product_WPF.Data.EntityModels
{
  public class PartProduct
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [JsonIgnore]
    public Product Product { get; set; }
    public int ProductId { get; set; }

    public int PartId { get; set; }

    public PartProduct() { }

    public PartProduct(PartProductDTO dto, int? productId)
    {
      if (dto.CUD != CUD.Add)
      {
        if (dto.Id != null && dto.Id != 0)
          Id = dto.Id.Value;
        ProductId = productId.Value;
      }

      PartId = dto.PartId;
    }
  }
}
