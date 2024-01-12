using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papiashvili.Vstupenky.Web.Vstupenky.Domain.Entites;

namespace Papiashvili.Vstupenky.Web.Vstupenky.Infrastrucure.Database
{
    public class DatabaseFake
    {
        public static List<Uzivatel> Uzivatels { get; set; }
        public static List<Concert> Concerts { get; set; }
        public static List<Carousel> Carousels { get; set; }
        public static List<Vstupenka> Vstupenkas { get; set; }
        public static List<Admin> Admins { get; set; }
        public static List<Recenze> Recenzes { get; set; }

        static DatabaseFake()
        {
            DatabaseInit dbInit = new DatabaseInit();
            Uzivatels = dbInit.GetUzivatels().ToList();
            Concerts = dbInit.GetConcerts().ToList();
            Carousels = dbInit.GetCarousels().ToList();
            Admins = dbInit.GetAdmins().ToList();
            Vstupenkas = dbInit.GetVstupenkas().ToList();
            Recenzes = dbInit.GetRecenzes().ToList();


        }
    }
}
