using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papiashvili.Vstupenky.Web.Vstupenky.Application.ViewModels;

namespace Papiashvili.Vstupenky.Web.Vstupenky.Abstraction
{
    public interface IHomeService
    {
        CarouselConcertViewModel GetHomeViewModel();
    }
}
