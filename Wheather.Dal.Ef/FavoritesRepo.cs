using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheather.Dal.Entities;
using Wheather.Dal.Interface;

namespace Wheather.Dal.Ef
{
    public class FavoritesRepo : IFavoritesRepo
    {
        private readonly WeatherContext _wheatherContext;

        public FavoritesRepo(WeatherContext wheatherContext)
        {
            _wheatherContext = wheatherContext;
        }

        public async Task AddFavoriteAsync(Favorite favorite)
        {
            _wheatherContext.Favorites.Add(favorite);
            await _wheatherContext.SaveChangesAsync();
        }

        public async Task DeleteFavoriteAsync(string locationId)
        {
            var item = await GetFavoriteAsync(locationId);
            if (item != null)
            {
                _wheatherContext.Favorites.Remove(item);
                await _wheatherContext.SaveChangesAsync();
            }
        }

        public async Task<Favorite> GetFavoriteAsync(string locationId)
        {
            var result = await _wheatherContext.Favorites.Where(x => x.LocationId == locationId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> IsExistsAsync(string locationId)
        {
            var result = await _wheatherContext.Favorites.AnyAsync(x => x.LocationId == locationId);
            return result;
        }
    }
}
