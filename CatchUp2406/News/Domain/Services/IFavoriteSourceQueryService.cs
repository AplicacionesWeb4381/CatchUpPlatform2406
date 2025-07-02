using CatchUp2406.News.Domain.Model.Aggregates;
using CatchUp2406.News.Domain.Model.Queries;

namespace CatchUp2406.News.Domain.Services
{
    public interface IFavoriteSourceQueryService
    {
        /// <summary>
        ///     Handle the GetAllFavoriteSourcesByNewsApiKeyQuery.
        /// </summary>
        /// <remarks>
        ///     This method handles the GetAllFavoriteSourcesByNewsApiKeyQuery. It returns all the favorite sources for the given
        ///     NewsApiKey.
        /// </remarks>
        /// <param name="query">The GetAllFavoriteSourcesByNewsApiKeyQuery query</param>
        /// <returns>An IEnumerable containing the FavoriteSource objects</returns>
        Task<IEnumerable<FavoriteSource>> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query);

        /// <summary>
        ///     Handle the GetFavoriteSourcesById.
        /// </summary>
        /// <remarks>
        ///     This method handles the GetFavoriteSourcesById. It returns all the favorite sources for the given
        ///     NewsApiKey.
        /// </remarks>
        /// <param name="query">The GetFavoriteSourcesById query</param>
        /// <returns>An IEnumerable containing the FavoriteSource objects</returns>
        Task<FavoriteSource> Handle(GetFavoriteSourcesByIdQuery query);

        /// <summary>
        ///     Handle the GetFavoriteSourcesById.
        /// </summary>
        /// <remarks>
        ///     This method handles the GetFavoriteSourcesById. It returns all the favorite sources for the given
        ///     NewsApiKey.
        /// </remarks>
        /// <param name="query">The GetFavoriteSourcesById query</param>
        /// <returns>An IEnumerable containing the FavoriteSource objects</returns>
        Task<FavoriteSource> Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query);
    }
}
