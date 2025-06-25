using CatchUp2406.News.Domain.Model.Aggregates;
using CatchUp2406.Shared.Domain.Repositories;

namespace CatchUp2406.News.Domain.Repositories
{
    public interface IFavoriteSourceRepository : IBaseRepository<FavoriteSource>
    {
        /// <summary>
        /// Find favorite sources by News API Key
        /// </summary>
        /// <param name="newsApiKey">The News API Key to search.</param>
        /// <returns>
        /// An Enumerable containing the favorite source objects if found, or empty otherwise.
        /// </returns>
        Task<IEnumerable<FavoriteSource>> FindByNewsApiKeyAsync(string newsApiKey);
    }
}
