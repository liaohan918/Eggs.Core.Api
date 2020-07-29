using System.Collections.Generic;
using System.Threading.Tasks;
using Eggs.Core.Api.Common;
using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IServices;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.Services.BASE;

namespace Eggs.Core.Api.Services
{
    public class TopicServices: BaseServices<Topic>, ITopicServices
    {

        ITopicRepository _dal;
        public TopicServices(ITopicRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

        /// <summary>
        /// 获取开Bug专题分类（缓存）
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 60)]
        public async Task<List<Topic>> GetTopics()
        {
            return await base.Query(a => !a.tIsDelete && a.tSectendDetail == "tbug");
        }

    }
}
