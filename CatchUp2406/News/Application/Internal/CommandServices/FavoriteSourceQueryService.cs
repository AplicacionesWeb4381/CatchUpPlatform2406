using CatchUp2406.News.Domain.Model.Aggregates;
using CatchUp2406.News.Domain.Model.Queries;
using CatchUp2406.News.Domain.Repositories;
using CatchUp2406.News.Domain.Services;
using CatchUp2406.Shared.Domain.Repositories;

namespace CatchUp2406.News.Application.Internal.CommandServices
{
    public class FavoriteSourceQueryService(IFavoriteSourceRepository favoriteSourceRepository, IUnitOfWork unitOfWork)
    : IFavoriteSourceQueryService
    {

        public async Task<IEnumerable<FavoriteSource>> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query) { 
            return await favoriteSourceRepository.FindByNewsApiKeyAsync(query.NewsapiKey);

        }
    }
}
