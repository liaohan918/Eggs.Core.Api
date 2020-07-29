using Eggs.Core.Api.Services.BASE;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IServices;

namespace Eggs.Core.Api.Services
{	
	/// <summary>
	/// ModuleServices
	/// </summary>	
	public class ModuleServices : BaseServices<Modules>, IModuleServices
    {
	
        IModuleRepository _dal;
        public ModuleServices(IModuleRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }
       
    }
}
