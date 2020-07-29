using Eggs.Core.Api.Services.BASE;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IServices;

namespace Eggs.Core.Api.Services
{	
	/// <summary>
	/// ModulePermissionServices
	/// </summary>	
	public class ModulePermissionServices : BaseServices<ModulePermission>, IModulePermissionServices
    {
	
        IModulePermissionRepository _dal;
        public ModulePermissionServices(IModulePermissionRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }
       
    }
}
