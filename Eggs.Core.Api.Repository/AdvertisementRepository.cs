using Eggs.Core.Api.IRepository;
using Eggs.Core.Api.IRepository.UnitOfWork;
using Eggs.Core.Api.Model.Models;
using Eggs.Core.Api.Repository.Base;

namespace Eggs.Core.Api.Repository
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
