using System.ComponentModel;
using C698_Product_WPF.Data.EntityModels;

namespace C698_Product_WPF.Data
{
  public class Inventory
  {
    public BindingList<Product> AllProducts = new BindingList<Product>();
    public BindingList<Part> AllParts = new BindingList<Part>();

    public Inventory() { }

    public void AddPart(Part part) 
    {
      AllParts.Add(part);
    }

    public bool DeletePart(Part part)
    {      
      return AllParts.Remove(part);
    }

    public Part LookupPart(int id)
    {
      return AllParts[id];
    }

    public void UpdatePart(Part part, int id) 
    {
      AllParts.Remove(AllParts[id]);
      AllParts.Add(part);
    }

    public void AddProduct(Product product) 
    {
      AllProducts.Add(product);
    }

    public bool RemoveProduct(int id)
    {      
      return AllProducts.Remove(AllProducts[id]);
    }

    public Product LookupProduct(int id)
    {
      return AllProducts[id];
    }

    public void EditProduct(int id, Product product) 
    {
      AllProducts.Remove(AllProducts[id]);
      AllProducts.Add(product);
    }
  }
}
