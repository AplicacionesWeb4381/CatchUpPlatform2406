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
        /// <summary>
        ///     Handles the GetAllFavoriteSourcesByNewsApiKeyQuery.
        /// </summary>
        /// <remarks>
        ///     This method retrieves all favorite sources associated with the specified NewsApiKey.
        /// </remarks>
        /// <param name="query">The GetAllFavoriteSourcesByNewsApiKeyQuery containing the NewsApiKey.</param>
        /// <returns>
        ///     An IEnumerable containing the FavoriteSource objects found for the given NewsApiKey.
        /// </returns>
        public async Task<IEnumerable<FavoriteSource>> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query) { 
            return await favoriteSourceRepository.FindByNewsApiKeyAsync(query.NewsapiKey);

        }

        /// <summary>
        ///     Handles the GetFavoriteSourcesByIdQuery.
        /// </summary>
        /// <remarks>
        ///     This method retrieves a favorite source by its unique identifier.
        /// </remarks>
        /// <param name="query">The GetFavoriteSourcesByIdQuery containing the Id.</param>
        /// <returns>
        ///     The FavoriteSource object found for the given Id.
        /// </returns>
        public async Task<FavoriteSource> Handle(GetFavoriteSourcesByIdQuery query)
        {
            return await favoriteSourceRepository.FindByIdAsync(query.Id);

        }

        /// <summary>
        ///     Handles the GetFavoriteSourcesByIdQuery.
        /// </summary>
        /// <remarks>
        ///     This method retrieves a favorite source by its unique identifier.
        /// </remarks>
        /// <param name="query">The GetFavoriteSourcesByIdQuery containing the Id.</param>
        /// <returns>
        ///     The FavoriteSource object found for the given Id.
        /// </returns>
        public async Task<FavoriteSource> Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query)
        {
            return await favoriteSourceRepository.FindByNewsApiKeyAsyncSourceId(query.NewsApiKey, query.Id);

        }

    }
}
