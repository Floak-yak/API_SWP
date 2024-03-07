using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;

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

        public string GetAdvise(string id)
        {
            return _context.ConstructionPriceQuotations.Where(p => p.QuotationId == id).FirstOrDefault().Advise;
        }

        public ConstructionPriceQuotation GetConstructionPriceQuotation(string id)
        {
            return _context.ConstructionPriceQuotations.Where(p => p.QuotationId == id).FirstOrDefault();
        }

        public ICollection<ConstructionPriceQuotation> GetConstructionPriceQuotations()
        {
            return _context.ConstructionPriceQuotations.OrderBy(p => p.ConstructionReceived).ToList();
        }

        public string GetCustomerComment(string id)
        {
            return _context.ConstructionPriceQuotations.Where(p => p.QuotationId == id).Select(p => p.CustomerComment).ToString();
        }

        public string GetHouseType(string id)
        {
            return _context.ConstructionPriceQuotations.Where(p => p.QuotationId == id).Select(p => p.HouseSType).ToString();
        }

        public string GetPayment(string id)
        {  
            return _context.ConstructionPriceQuotations.Where(p => p.QuotationId == id).Select(p => p.Payment).ToString();
        }

        public double GetPrice(string id)
        {
            return _context.ConstructionPriceQuotations.Where(p => p.QuotationId == id).Select(p => p.Price).FirstOrDefault();
        }

        public string GetProductName(string id)
        {
            return _context.ConstructionPriceQuotations.Where(p => p.QuotationId == id).Select(p => p.Product).ToString();
        }

        public string GetStatus(string id)
        {
            int status = _context.ConstructionPriceQuotations.Where(p=>p.QuotationId==id).Select(p => p.Status).FirstOrDefault();
            if (status == 1)
            {
                return "Quatation has been done";
            }
            if (status == 0)
            {
                return "Still on going";
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
