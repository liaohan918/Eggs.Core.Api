using Eggs.Core.Api.IServices.BASE;
using Eggs.Core.Api.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eggs.Core.Api.IServices
{
    public interface ITopicDetailServices : IBaseServices<TopicDetail>
    {
        Task<List<TopicDetail>> GetTopicDetails();
    }
}
