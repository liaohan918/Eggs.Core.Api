using Eggs.Core.Api.IServices.BASE;
using Eggs.Core.Api.Model;
using Eggs.Core.Api.Model.Models;
using System.Threading.Tasks;

namespace Eggs.Core.Api.IServices
{
    public partial interface IGuestbookServices : IBaseServices<Guestbook>
    {
        Task<MessageModel<string>> TestTranInRepository();
        Task<bool> TestTranInRepositoryAOP();
    }
}
