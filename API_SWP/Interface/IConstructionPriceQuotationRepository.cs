using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IConstructionPriceQuotationRepository
    {
        ICollection<ConstructionPriceQuotation> GetConstructionPriceQuotations();
        ConstructionPriceQuotation GetConstructionPriceQuotation(string id);
        List<ConstructionPriceQuotation> GetConstructionPriceQuotationByCustomerId(string customerId);
        string GetStatus(string id);
        bool ConstructionPriceQuotationExist(string id);
        bool CreateCostructionPriceQuotation(ConstructionPriceQuotation constructionPriceQuotation);
        bool RemoveCostructionPriceQuotation(ConstructionPriceQuotation constructionPriceQuotation);
        bool UpdateCostructionPriceQuotation(ConstructionPriceQuotation constructionPriceQuotation);
        bool Save();
    }
}
