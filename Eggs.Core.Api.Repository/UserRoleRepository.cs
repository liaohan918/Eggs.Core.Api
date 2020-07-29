using Eggs.Core.Api.FrameWork.IRepository;
using Eggs.Core.Api.Repository.Base;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.IRepository.UnitOfWork;

namespace Eggs.Core.Api.Repository
{
    /// <summary>
    /// UserRoleRepository
    /// </summary>	
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
