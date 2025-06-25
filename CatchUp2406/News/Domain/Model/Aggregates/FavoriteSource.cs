using CatchUp2406.News.Domain.Model.Commands;

namespace CatchUp2406.News.Domain.Model.Aggregates
{
    public partial class FavoriteSource
    {
        public int Id { get; }

        public string NewsApiKey { get; private set; }
        public string SourceId { get; private set; }    

        protected FavoriteSource() { 
        
            NewsApiKey = string.Empty;
            SourceId = string.Empty;    
        }

        public FavoriteSource(CreateFavoriteSourceCommand command)
        {
            NewsApiKey = command.NewsApiKey;
            SourceId = command.SourceId;
        }
    }
}
