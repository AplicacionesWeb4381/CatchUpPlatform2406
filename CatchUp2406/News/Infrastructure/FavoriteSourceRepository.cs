using CatchUp2406.News.Domain.Model.Aggregates;
using CatchUp2406.News.Domain.Repositories;
using CatchUp2406.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUp2406.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatchUp2406.News.Infrastructure
{
    public class FavoriteSourceRepository(AppDbContext context) : BaseRepository<FavoriteSource>(context), IFavoriteSourceRepository
    {

        public async Task<IEnumerable<FavoriteSource>> FindByNewsApiKeyAsync(string newsApiKey) { 
           return await Context.Set<FavoriteSource>().Where(f => f.NewsApiKey == newsApiKey).ToListAsync();
        }

        public async Task<FavoriteSource> FindByIdAsync(string Id)
        {
            return await Context.Set<FavoriteSource>().FirstOrDefaultAsync(f => f.SourceId == Id);
        }

        public async Task<FavoriteSource> FindByNewsApiKeyAsyncSourceId(string NewapiKey, string SourceId)
        {
            return await Context.Set<FavoriteSource>().FirstOrDefaultAsync(f => f.NewsApiKey == NewapiKey && f.SourceId== SourceId);
        }
    }
}
