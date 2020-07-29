using Eggs.Core.Api.IServices.BASE;
using Eggs.Core.Api.Model.Models;
using System.Threading.Tasks;

namespace Eggs.Core.Api.IServices
{	
	/// <summary>
	/// RoleServices
	/// </summary>	
    public interface IRoleServices :IBaseServices<Role>
	{
        Task<Role> SaveRole(string roleName);
        Task<string> GetRoleNameByRid(int rid);

    }
}
