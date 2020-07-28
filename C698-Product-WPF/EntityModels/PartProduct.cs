using System.Text.Json.Serialization;

namespace C698_Product_WPF.EntityModels
{
  public class PartProduct
  {
    [JsonIgnore]
    public Product Product { get; set; }
    public int ProductId { get; set; }

    [JsonIgnore]
    public Part Part { get; set; }
    public int PartId { get; set; }
  }
}
