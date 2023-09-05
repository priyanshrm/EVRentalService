using EVRentalDAL;
using EVRentalEntity;
using EVRentalEntity.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EVRentalBusiness.Service
{
    public class ElectricVehicleService
    {
        private readonly IElectricVehicleRepository _elcObj;

        public ElectricVehicleService(IElectricVehicleRepository elcObj)
        {
            _elcObj = elcObj;

        }

        public string AddEV(EVModel ev)
        {
            return _elcObj.AddEV(ev);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public string DeleteEVbyId(int id)
        {
            return _elcObj.DeleteEVbyId(id);
        }

        public List<EVModel> GetAll()
        {
           return _elcObj.GetAll(); 
        }

        public EVModel GetEVbyId(int id)
        {
            return _elcObj.GetEVbyId(id);
        }

        public string UpdateEV(EVModel ev)
        {
            return _elcObj.UpdateEV(ev);
        }
    }
}