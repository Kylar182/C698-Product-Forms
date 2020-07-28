using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace C698_Product_WPF.EntityModels
{
  public abstract class Part : Base
  {
    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    [JsonIgnore]
    public Product Product { get; set; }
    public int ProductId { get; set; }
  }
}
