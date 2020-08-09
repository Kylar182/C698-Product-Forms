using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;
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
      foreach (Inhouse part in await _repository.GetAll())
        vms.Add(new PartDTO(part));

      return vms;
    }

    public async Task<PartDTO> GetById(int id)
    {
      return new PartDTO(await _repository.GetById(id));
    }

    public async Task<PartDTO> AddItem(PartDTO part)
    {

      return new PartDTO(await _repository.AddItem(new Inhouse(part, CUD.Add)));
    }

    public async Task<PartDTO> UpdateItem(PartDTO part)
    {
      return new PartDTO(await _repository.UpdateItem(new Inhouse(part, CUD.Modify)));
    }

    public async Task Delete(int id)
    {
      await _repository.Delete(id);
    }
  }
}
