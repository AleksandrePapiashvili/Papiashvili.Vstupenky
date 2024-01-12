using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Papiashvili.Vstupenky.Web.Areas.Identity.Data;

// Add profile data for application users by adding properties to the PapiashviliVstupenkyWebUser class
public class PapiashviliVstupenkyWebUser : IdentityUser
{
    public string jmeno { get; set; }
    public string prijmeni { get; set; }

    // Добавление свойства для хранения роли пользователя
    
}


