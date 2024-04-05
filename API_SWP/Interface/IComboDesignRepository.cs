using API_SWP.Model;
using API_SWP.ViewModel;

namespace API_SWP.Interface
{
    public interface IComboDesignRepository
    {
        List<ComboDesign> GetComboDesigns();
        ComboDesign GetComboDesignById(string id);
        bool ComboDesignExits(string id);
        bool CreateComboDesign(ComboDesign comboDesign);
        bool RemoveComboDesign(ComboDesign comboDesign);
        bool UpdateComboDesign(ComboDesign comboDesign);
        bool Save();
    }
}
