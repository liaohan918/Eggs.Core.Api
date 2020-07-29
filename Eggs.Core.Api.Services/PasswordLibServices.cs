using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IServices;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.Services.BASE;

namespace Eggs.Core.Api.Services
{
    public partial class PasswordLibServices : BaseServices<PasswordLib>, IPasswordLibServices
    {
        IPasswordLibRepository _dal;
        public PasswordLibServices(IPasswordLibRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

    }
}
