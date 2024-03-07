using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IConstructionReceivedRepository
    {
        ICollection<ConstructionReceived> GetConstructionReceiveds();
        ConstructionReceived ConstructionReceived(string id);
        bool ConstructionReceivedExits(string id);
        bool CreateConstructionReceived (ConstructionReceived constructionReceived);
        bool RemoveConstructionReceived(ConstructionReceived constructionReceived);
        bool UpdateConstructionReceived(ConstructionReceived constructionReceived);
        bool Save();
    }
}
