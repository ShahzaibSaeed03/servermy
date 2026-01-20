using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using Entities.Models;
using System.Data;

namespace BL
{
    public class FaqBL : IFaqBL
    {
        private readonly IFaqDAL _faqDAL;
        private readonly IMapper _mapper;

        public FaqBL(IFaqDAL faqDAL, IMapper mapper)
        {
            _faqDAL = faqDAL;
            _mapper = mapper;
        }
        public async Task<IEnumerable<object>> GetFaq()
        {
            return await _faqDAL.GetFaq();
        }
    }
}
