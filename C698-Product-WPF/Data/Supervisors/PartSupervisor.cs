using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.Supervisors.Interfaces;
using C698_Product_WPF.Data.ViewModels;
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
    public async Task<List<PartVM>> GetAll()
    {
      List<PartVM> vms = new List<PartVM>();
      foreach (Part part in await _repository.GetAll())
        vms.Add(new PartVM(part));

      return vms;
    }

    public async Task<PartVM> GetById(int id)
    {
      return new PartVM(await _repository.GetById(id));
    }

    public async Task<PartVM> AddItem(PartVM vm)
    {
      await _repository.AddItem(new Part(vm));

      return vm;
    }

    public async Task<PartVM> UpdateItem(PartVM vm)
    {
      await _repository.UpdateItem(new Part(vm));

      return vm;
    }

    public async Task Delete(int id)
    {
      await _repository.Delete(id);
    }
  }
}
