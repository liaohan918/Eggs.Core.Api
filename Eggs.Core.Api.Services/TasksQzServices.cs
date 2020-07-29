
using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IServices;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.Services.BASE;

namespace Eggs.Core.Api.Services
{
    public partial class TasksQzServices : BaseServices<TasksQz>, ITasksQzServices
    {
        ITasksQzRepository _dal;
        public TasksQzServices(ITasksQzRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

    }
}
                    