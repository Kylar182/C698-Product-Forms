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
      foreach (Inhouse part in await _repository.GetAllInHouse())
        vms.Add(new PartDTO(part));
      foreach (Outsourced part in await _repository.GetAllOutsourced())
        vms.Add(new PartDTO(part));

      return vms;
    }

    public async Task<PartDTO> GetById(int id)
    {
      Inhouse inhouse = await _repository.GetInhouseById(id);
      if (inhouse != null && inhouse != default(Inhouse))
        return new PartDTO(inhouse);

      return new PartDTO(await _repository.GetOutSourcedById(id));
    }

    public async Task<PartDTO> AddItem(PartDTO part)
    {
      if (part.Source == Source.InHouse)
        return new PartDTO(await _repository.AddItem(new Inhouse(part, CUD.Add)));

      return new PartDTO(await _repository.AddItem(new Outsourced(part, CUD.Add)));
    }

    public async Task<PartDTO> UpdateItem(PartDTO part)
    {
      if (part.Source == Source.InHouse)
        return new PartDTO(await _repository.UpdateItem(new Inhouse(part, CUD.Modify)));

      return new PartDTO(await _repository.UpdateItem(new Outsourced(part, CUD.Modify)));
    }

    public async Task Delete(int id)
    {
      await _repository.Delete(id);
    }
  }
}
