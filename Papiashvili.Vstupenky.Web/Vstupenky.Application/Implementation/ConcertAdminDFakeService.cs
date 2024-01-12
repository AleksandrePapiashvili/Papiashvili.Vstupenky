using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papiashvili.Vstupenky.Web.Vstupenky.Abstraction;
using Papiashvili.Vstupenky.Web.Vstupenky.Domain.Entites;
using Papiashvili.Vstupenky.Web.Vstupenky.Infrastrucure.Database;

namespace Papiashvili.Vstupenky.Web.Vstupenky.Implementation
{
    public class ConcertAdminDFakeService : IConcertAdminService
    {
        public IList<Concert> Select()
        {
            return DatabaseFake.Concerts;
        }

        public void Create(Concert concert)
        {
            if (DatabaseFake.Concerts != null &&
                DatabaseFake.Concerts.Count > 0)
            {
                concert.Id = DatabaseFake.Concerts.Last().Id + 1;
            }
            else
            {
                concert.Id = 1;
            }


            if (DatabaseFake.Concerts != null)
                DatabaseFake.Concerts.Add(concert);
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Concert? concert =
                DatabaseFake.Concerts.FirstOrDefault(concert => concert.Id == id);
            
            if (concert != null)
            {
                deleted = DatabaseFake.Concerts.Remove(concert);
            }

            return deleted;
        }
    }
}
