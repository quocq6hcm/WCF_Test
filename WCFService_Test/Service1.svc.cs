using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFService_Test.Models;

namespace WCFService_Test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        Models.LaptopContext _db = new LaptopContext();



        public List<Models.Laptop> DeleteMovie(int MovieId)
        {
            Models.Laptop temp = _db.Laptops.SingleOrDefault(a => a.MovieId.Equals(MovieId));
            _db.Laptops.Remove(temp);
            _db.SaveChanges();
            return _db.Laptops.ToList();
        }

        public List<Laptop> GetMoviesList(string Director)
        {
            var rs = _db.Laptops.ToList();
            if (!string.IsNullOrEmpty(Director))
            {
                rs = _db.Laptops.ToList().Where(a => a.Director.Contains(Director)).ToList();
            }
            return rs;
        }

        public void PostMovie(Models.Laptop newLaptop)
        {
            _db.Laptops.Add(newLaptop);
            _db.SaveChanges();
            return;
        }
    }
}
