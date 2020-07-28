using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace C698_Product_WPF.EntityModels
{
  public abstract class Product : Base
  {
    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public List<Part> Parts { get; set; }
  }
}
