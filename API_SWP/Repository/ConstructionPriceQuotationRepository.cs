using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace API_SWP.Repository
{
    public class ConstructionPriceQuotationRepository : IConstructionPriceQuotationRepository
    {
        private readonly SWPContext _context;

        public ConstructionPriceQuotationRepository(SWPContext context)
        {
            _context = context;
        }

        public bool ConstructionPriceQuotationExist(string id)
        {
            return _context.ConstructionPriceQuotations.Any(p => p.QuotationId == id);
        }

        public bool CostructionPriceQuotationExist(string id)
        {
            return _context.ConstructionPriceQuotations.Any(_ => _.QuotationId == id);
        }

        public bool CreateCostructionPriceQuotation(ConstructionPriceQuotation constructionPriceQuotation)
        {
            _context.Add(constructionPriceQuotation);
            return Save();
        }

        public ConstructionPriceQuotation GetConstructionPriceQuotation(string id)
        {
            return _context.ConstructionPriceQuotations.Where(p => p.QuotationId == id).FirstOrDefault();
        }

        public ICollection<ConstructionPriceQuotation> GetConstructionPriceQuotations()
        {
            return _context.ConstructionPriceQuotations.OrderBy(p => p.QuotationId).ToList();
        }

        public string GetStatus(string id)
        {
            string status = _context.ConstructionPriceQuotations.Where(p=>p.QuotationId==id).Select(p => p.Status).FirstOrDefault();
            if (status == "Quatation has been done")
            {
                return status;
            }
            if (status == "Still on going")
            {
                return status;
            }
            else return "On the way";
        }

        public bool RemoveCostructionPriceQuotation(ConstructionPriceQuotation constructionPriceQuotation)
        {
            _context.Remove(constructionPriceQuotation);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCostructionPriceQuotation(ConstructionPriceQuotation constructionPriceQuotation)
        {
            _context.Update(constructionPriceQuotation);
            return Save();
        }
    }
}
