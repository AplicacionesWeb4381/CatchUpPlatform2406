using CatchUp2406.News.Domain.Model.Aggregates;
using CatchUp2406.News.Domain.Model.Commands;
using CatchUp2406.News.Domain.Repositories;
using CatchUp2406.News.Domain.Services;
using CatchUp2406.Shared.Domain.Repositories;

namespace CatchUp2406.News.Application.Internal.CommandServices
{
    public class FavoriteSourceCommandService(IFavoriteSourceRepository favoriteSourceRepository, IUnitOfWork unitOfWork)
    : IFavoriteSourceCommandService
    {
        /// <inheritdoc />
        public async Task<FavoriteSource?> Handle(CreateFavoriteSourceCommand command)
        {
            var favoriteSource =
                await favoriteSourceRepository.FindByNewsApiKeyAsyncSourceId (command.NewsApiKey, command.SourceId);
            if (favoriteSource != null)
                throw new Exception("Favorite source with this SourceId already exists for the given NewsApiKey");


            favoriteSource = new FavoriteSource(command);

            try
            {
                await favoriteSourceRepository.AddAsync(favoriteSource);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return favoriteSource;
        }
    }
}
