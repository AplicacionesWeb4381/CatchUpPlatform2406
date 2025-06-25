using CatchUp2406.News.Domain.Model.Commands;
using CatchUp2406.News.Interfaces.REST.Resources;

namespace CatchUp2406.News.Interfaces.REST.Transform
{
    public static class CreateFavoriteSourceCommandFromResourceAssembler
    {
        public static CreateFavoriteSourceCommand ToCommandFromResource(CreateFavoriteSourceResource resource) =>
            new CreateFavoriteSourceCommand(resource.NewsApiKey, resource.SourceId);
    }
}
