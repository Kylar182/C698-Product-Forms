using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace C698_Product_WPF.Data.EntityModels
{
  public abstract class Part
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public List<PartProduct> Products { get; set; }
  }
}
