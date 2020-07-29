using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.Repository.Base;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.IRepository.UnitOfWork;

namespace Eggs.Core.Api.Repository
{
    /// <summary>
    /// RoleRepository
    /// </summary>	
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
