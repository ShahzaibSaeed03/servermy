using DAL.Models;
using DTO;

namespace DAL
{
    public interface IFaqDAL
    {
        Task<IEnumerable<object>> GetFaq();
    }
}