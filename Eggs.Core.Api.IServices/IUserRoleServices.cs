using Eggs.Core.Api.IServices.BASE;
using Eggs.Core.Api.Model.Models;
using System.Threading.Tasks;

namespace Eggs.Core.Api.IServices
{	
	/// <summary>
	/// UserRoleServices
	/// </summary>	
    public interface IUserRoleServices :IBaseServices<UserRole>
	{

        Task<UserRole> SaveUserRole(int uid, int rid);
        Task<int> GetRoleIdByUid(int uid);
    }
}

