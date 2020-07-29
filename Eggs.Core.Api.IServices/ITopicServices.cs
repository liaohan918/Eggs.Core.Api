using Eggs.Core.Api.IServices.BASE;
using Eggs.Core.Api.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eggs.Core.Api.IServices
{
    public interface ITopicServices : IBaseServices<Topic>
    {
        Task<List<Topic>> GetTopics();
    }
}
