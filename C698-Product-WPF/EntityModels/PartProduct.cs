using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace C698_Product_WPF.EntityModels
{
  public class PartProduct
  {
    [JsonIgnore]
    public Product Product { get; set; }
    [Key, Column(Order = 0)]
    public int ProductId { get; set; }

    [JsonIgnore]
    public Part Part { get; set; }
    [Key, Column(Order = 1)]
    public int PartId { get; set; }
  }
}
