using CatchUp2406.News.Domain.Model.Aggregates;
using CatchUp2406.News.Interfaces.REST.Resources;
namespace CatchUp2406.News.Interfaces.REST.Transform
{
    public static class FavoriteSourceResourceFromEntityAssembler
    {
        public static FavoriteSourceResource ToResourceFromEntity(FavoriteSource entity) =>
            new FavoriteSourceResource(entity.Id, entity.NewsApiKey, entity.SourceId);
        
    }
}
