using Microsoft.AspNetCore.Identity;

namespace Papiashvili.Vstupenky.Web.Vstupenky.Domain.Entites
{
    public class Uzivatel : IdentityUser
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Login { get; set; }
        public string Heslo { get; set; }

    }
}