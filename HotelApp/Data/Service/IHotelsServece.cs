using HotelApp.Models;

namespace HotelApp.Data.Service
{
    public interface IHotelsServece
    {
        Task<IEnumerable<Hotels>> GetAll();
        Task Add(Hotels hotels);
        Task Delete(int id);

    }
}
