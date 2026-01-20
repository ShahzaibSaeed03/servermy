using DAL.Models;
using DTO;

namespace BL
{
    public interface IFaqBL
    {
        Task<IEnumerable<object>> GetFaq();
    }
}