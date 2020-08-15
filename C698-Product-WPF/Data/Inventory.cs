using System.ComponentModel;
using C698_Product_WPF.Data.EntityModels;

namespace C698_Product_WPF.Data
{
  public class Inventory
  {
    public BindingList<Product> AllProducts = new BindingList<Product>();
    public BindingList<Part> AllParts = new BindingList<Part>();

    public Inventory() { }

    public void AddPart(Part part) { }

    public bool DeletePart(Part part)
    {
      return true;
    }

    public Part LookupPart(int id)
    {
      return AllParts[id];
    }

    public void UpdatePart(Part part, int id) { }

    public void AddProduct(Product product) { }

    public bool RemoveProduct(int id)
    {
      return true;
    }

    public Product LookupProduct(int id)
    {
      return new Product();
    }

    public void EditProduct(int id, Product propduct) { }
  }
}
