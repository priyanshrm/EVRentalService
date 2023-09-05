using EVRentalEntity;
using EVRentalEntity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalDAL.Repositories
{
    public class ElectricVehicleRepository: IElectricVehicleRepository
    {
        private readonly EVRentalDbContext _db;

        public ElectricVehicleRepository(EVRentalDbContext dbContext)
        {
            _db = dbContext;    

        }

        public string AddEV(EVModel ev)
        {
            _db.ev.Add(ev);
            _db.SaveChanges();
            return "Inserted";
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
        
        public string DeleteEVbyId(int id)
        {
            // select * from movie where id=value;
            var ev = _db.ev.Find(id);
            // delete from movie where id=movieid;
            _db.ev.Remove(ev);
            _db.SaveChanges();
            return "Deleted";
        }

        public List<EVModel> GetAll()
        {
            List<EVModel> evList = _db.ev.ToList();
            return evList;
        }

        public EVModel GetEVbyId(int id)
        {
            return _db.ev.Find(id);
        }

        public string UpdateEV(EVModel ev)
        {
            _db.Entry(ev).State = EntityState.Modified; //update statement
            _db.SaveChanges();
            return "Updated";
        }

        
    }
}

