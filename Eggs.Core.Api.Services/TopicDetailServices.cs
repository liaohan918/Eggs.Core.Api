using System.Collections.Generic;
using System.Threading.Tasks;
using Eggs.Core.Api.Common;
using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IServices;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.Services.BASE;

namespace Eggs.Core.Api.Services
{
    public class TopicDetailServices : BaseServices<TopicDetail>, ITopicDetailServices
    {
        ITopicDetailRepository _dal;
        public TopicDetailServices(ITopicDetailRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

        /// <summary>
        /// 获取开Bug数据（缓存）
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<TopicDetail>> GetTopicDetails()
        {
            return await base.Query(a => !a.tdIsDelete && a.tdSectendDetail == "tbug");
        }
    }
}
