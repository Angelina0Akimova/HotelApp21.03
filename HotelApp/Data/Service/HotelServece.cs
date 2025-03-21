using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data.Service
{
    public class HotelServece : IHotelsServece
    {
        private readonly HotelsAppContext _context;
        public HotelServece(HotelsAppContext context)
        {
            _context = context;
        }
        public async Task Add(Hotels hotels)
        {
            _context.Hotels.Add(hotels);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotels>> GetAll()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }
        public async Task Delete(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }

    }
}
