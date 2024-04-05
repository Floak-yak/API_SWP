using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IHouseTypeOptionRepository
    {
        List<HouseTypeOption> GetHouseTypeOptions();
        HouseTypeOption GetHouseTypeOptionById(string id);
        bool Remove(HouseTypeOption houseTypeOption);
        bool Create(HouseTypeOption houseTypeOption);
        bool Update(HouseTypeOption houseTypeOption);
        bool Save();
        bool Exist(string id);
    }
}
