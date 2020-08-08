using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.Supervisors.Interfaces;
using C698_Product_WPF.Persistence.Repositories.Interfaces;

namespace C698_Product_WPF.Data.Supervisors
{
  public class PartSupervisor : IPartSupervisor
  {
    private readonly IPartRepository _repository;

    public PartSupervisor(IPartRepository repository)
    {
      _repository = repository;
    }
    public async Task<List<PartDTO>> GetAll()
    {
      List<PartDTO> vms = new List<PartDTO>();
      foreach (Part part in await _repository.GetAll())
        vms.Add(new PartDTO(part));

      return vms;
    }

    public async Task<PartDTO> GetById(int id)
    {
      return new PartDTO(await _repository.GetById(id));
    }

    public async Task<PartDTO> AddItem(Part part)
    {
      return new PartDTO(await _repository.AddItem(part));
    }

    public async Task<PartDTO> UpdateItem(Part part)
    {
      return new PartDTO(await _repository.UpdateItem(part));
    }

    public async Task Delete(int id)
    {
      await _repository.Delete(id);
    }
  }
}
