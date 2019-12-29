using System.Threading.Tasks;
using Wheather.Dal.Entities;

namespace Wheather.Dal.Interface
{
    public interface IFavoritesRepo
    {
        Task<Favorite> GetFavoriteAsync(string locationId);
        Task DeleteFavoriteAsync(string locationId);
        Task AddFavoriteAsync(Favorite favorite);
    }
}