using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C698_Product_WPF.EntityModels
{
  /// <summary>
  /// Base Model for Entity Models to Inherit From
  /// </summary>
  public abstract class Base
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
