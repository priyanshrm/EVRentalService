using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalEntity.Repositories
{
    public interface IElectricVehicleRepository
    {
        string AddEV(EVModel ev);
        string UpdateEV(EVModel ev);

        string DeleteEVbyId(int id);

        void DeleteAll();

        EVModel GetEVbyId(int id);

        List<EVModel> GetAll();
    }
}
