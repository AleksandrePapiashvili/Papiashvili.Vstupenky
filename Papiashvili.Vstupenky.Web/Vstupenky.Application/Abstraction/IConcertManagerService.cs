using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papiashvili.Vstupenky.Web.Vstupenky.Domain.Entites;

namespace Papiashvili.Vstupenky.Web.Vstupenky.Abstraction
{
    public interface IConcertManagerService
    {
        IList<Concert> Select();
        void Create(Concert product);
        bool Delete(int id);
    }
}
