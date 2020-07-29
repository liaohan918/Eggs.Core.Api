using Eggs.Core.Api.IRepository.Base;
using Eggs.Core.Api.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eggs.Core.Api.IRepository
{
    /// <summary>
    /// IRoleModulePermissionRepository
    /// </summary>	
    public interface IRoleModulePermissionRepository : IBaseRepository<RoleModulePermission>//类名
    {
        Task<List<TestMuchTableResult>> QueryMuchTable();
        Task<List<RoleModulePermission>> RoleModuleMaps();
        Task<List<RoleModulePermission>> GetRMPMaps();
    }
}
