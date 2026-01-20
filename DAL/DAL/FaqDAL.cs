using DAL.Models;
using DTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FaqDAL : IFaqDAL
    {
        private readonly MyCaDbContext _context;

        public FaqDAL(MyCaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<object>> GetFaq()
        {
            //List<FaqDTO> list = await _context.TFaqs
            //    .Include(f=>f.Category)
            //    .Select(f => new FaqDTO
            //    {
            //        Question = f.Question,
            //        Answer = f.Answer,
            //        Category = f.Category.CategoryName
            //    }).ToListAsync();


            var list = await _context.TCategories
           .Select(c => new
           {
               Name = c.CategoryName,
               Faqs = c.TFaqs.Select(f => new 
               {
                   Question = f.Question,
                   Answer = f.Answer
               }).ToList()
           })
           .ToListAsync();



            //List<TCategory> list = await _context.TCategories
            //    .Include(c=>c.TFaqs)
            //    .ToListAsync();
            return list;
        }
    }
}
