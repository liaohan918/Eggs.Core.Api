
using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IRepository.UnitOfWork;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.Repository.Base;

namespace Eggs.Core.Api.Repository
{
	/// <summary>
	/// TasksQzRepository
	/// </summary>
    public class TasksQzRepository : BaseRepository<TasksQz>, ITasksQzRepository
    {
        public TasksQzRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
                    