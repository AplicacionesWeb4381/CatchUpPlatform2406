using CatchUp2406.News.Domain.Model.Aggregates;
using CatchUp2406.News.Domain.Model.Commands;

namespace CatchUp2406.News.Domain.Services
{
    public interface IFavoriteSourceCommandService
    {
        Task <FavoriteSource?> Handle(CreateFavoriteSourceCommand command);
    }
}
