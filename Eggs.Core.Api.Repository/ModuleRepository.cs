using Eggs.Core.Api.Repository.Base;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IRepository.UnitOfWork;

namespace Eggs.Core.Api.Repository
{
    /// <summary>
    /// ModuleRepository
    /// </summary>	
    public class ModuleRepository : BaseRepository<Modules>, IModuleRepository
    {
        public ModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
