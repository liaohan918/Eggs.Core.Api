using Eggs.Core.Api.Services.BASE;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IServices;

namespace Eggs.Core.Api.Services
{	
	/// <summary>
	/// PermissionServices
	/// </summary>	
	public class PermissionServices : BaseServices<Permission>, IPermissionServices
    {
	
        IPermissionRepository _dal;
        public PermissionServices(IPermissionRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }
       
    }
}
