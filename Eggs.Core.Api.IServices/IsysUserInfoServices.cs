    

using Eggs.Core.Api.IServices.BASE;
using Eggs.Core.Api.Model.Models;
using System.Threading.Tasks;

namespace Eggs.Core.Api.IServices
{	
	/// <summary>
	/// sysUserInfoServices
	/// </summary>	
    public interface ISysUserInfoServices :IBaseServices<sysUserInfo>
	{
        Task<sysUserInfo> SaveUserInfo(string loginName, string loginPwd);
        Task<string> GetUserRoleNameStr(string loginName, string loginPwd);
    }
}
