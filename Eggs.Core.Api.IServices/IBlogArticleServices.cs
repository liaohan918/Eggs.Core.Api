using Eggs.Core.Api.IServices.BASE;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eggs.Core.Api.IServices
{
    public interface IBlogArticleServices :IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();
        Task<BlogViewModels> GetBlogDetails(int id);

    }

}
