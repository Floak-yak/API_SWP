using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IConstructionPriceQuotationRepository
    {
        ICollection<ConstructionPriceQuotation> GetConstructionPriceQuotations();
        ConstructionPriceQuotation GetConstructionPriceQuotation(string id);
        bool CostructionPriceQuotationExist(string id);
        string GetProductName(string id);
        string GetHouseType(string id);
        string GetStatus(string id);
        double GetPrice(string id);
        string GetPayment(string id);
        string GetAdvise(string id);
        string GetCustomerComment(string id);
        bool ConstructionPriceQuotationExist(string id);
        bool CreateCostructionPriceQuotation(ConstructionPriceQuotation constructionPriceQuotation);
        bool RemoveCostructionPriceQuotation(ConstructionPriceQuotation constructionPriceQuotation);
        bool UpdateCostructionPriceQuotation(ConstructionPriceQuotation constructionPriceQuotation);
        bool Save();
    }
}
