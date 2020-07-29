using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IRepository.UnitOfWork;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.Repository.Base;

namespace Eggs.Core.Api.Repository
{
    /// <summary>
    /// sysUserInfoRepository
    /// </summary>	
    public class sysUserInfoRepository : BaseRepository<sysUserInfo>, IsysUserInfoRepository
    {
        public sysUserInfoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
