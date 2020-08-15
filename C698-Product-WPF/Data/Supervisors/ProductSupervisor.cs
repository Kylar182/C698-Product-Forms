using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.Supervisors.Interfaces;
using C698_Product_WPF.Persistence.Repositories.Interfaces;

namespace C698_Product_WPF.Data.Supervisors
{
  public class ProductSupervisor : IProductSupervisor
  {
    private readonly IProductRepository _repository;
    private readonly IPartRepository _partRepository;

    public ProductSupervisor(IProductRepository repository, IPartRepository partRepository)
    {
      _repository = repository;
      _partRepository = partRepository;
    }

    public async Task<List<ProductDTO>> GetAll()
    {
      List<ProductDTO> vms = new List<ProductDTO>();
      foreach (Product product in await _repository.GetAll())
        vms.Add(new ProductDTO(product));

      return vms;
    }

    public async Task<List<PartDTO>> GetAllParts()
    {
      List<PartDTO> parts = new List<PartDTO>();

      foreach (InHouse inHousePart in await _partRepository.GetAllInHouse())
        parts.Add(new PartDTO(inHousePart));
      foreach (OutSourced outsourcedPart in await _partRepository.GetAllOutSourced())
        parts.Add(new PartDTO(outsourcedPart));

      return parts;
    }

    public async Task<ProductDTO> GetById(int id)
    {
      return new ProductDTO(await _repository.GetById(id));
    }

    public async Task<ProductDTO> AddItem(Product product)
    {
      return new ProductDTO(await _repository.AddItem(product));
    }

    public async Task<ProductDTO> UpdateItem(Product product)
    {
      return new ProductDTO(await _repository.UpdateItem(product));
    }

    public async Task Delete(int id)
    {
      await _repository.Delete(id);
    }
  }
}
