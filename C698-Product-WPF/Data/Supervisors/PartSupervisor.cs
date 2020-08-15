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
      foreach (InHouse part in await _repository.GetAllInHouse())
        vms.Add(new PartDTO(part));
      foreach (OutSourced part in await _repository.GetAllOutSourced())
        vms.Add(new PartDTO(part));

      return vms;
    }

    public async Task<PartDTO> GetById(int id)
    {
      InHouse inhouse = await _repository.GetInHouseById(id);
      if (inhouse != null && inhouse != default(InHouse))
        return new PartDTO(inhouse);

      return new PartDTO(await _repository.GetOutSourcedById(id));
    }

    public async Task<PartDTO> AddItem(PartDTO part)
    {
      if (part.Source == Source.InHouse)
        return new PartDTO(await _repository.AddItem(new InHouse(part, CUD.Add)));

      return new PartDTO(await _repository.AddItem(new OutSourced(part, CUD.Add)));
    }

    public async Task<PartDTO> UpdateItem(PartDTO part)
    {
      if (part.Source == Source.InHouse)
        return new PartDTO(await _repository.UpdateItem(new InHouse(part, CUD.Modify)));

      return new PartDTO(await _repository.UpdateItem(new OutSourced(part, CUD.Modify)));
    }

    public async Task Delete(int id)
    {
      await _repository.Delete(id);
    }
  }
}
