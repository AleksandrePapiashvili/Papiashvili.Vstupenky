using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papiashvili.Vstupenky.Web.Vstupenky.Abstraction;
using Papiashvili.Vstupenky.Web.Vstupenky.Application.ViewModels;
using Papiashvili.Vstupenky.Web.Vstupenky.Infrastrucure.Database;

namespace Papiashvili.Vstupenky.Web.Vstupenky.Implementation
{
    public class HomeService : IHomeService
    {
        public CarouselConcertViewModel GetHomeViewModel()
        {
            CarouselConcertViewModel viewModel = new CarouselConcertViewModel();
            
            viewModel.Concerts = DatabaseFake.Concerts;
            viewModel.Carousels = DatabaseFake.Carousels;

            return viewModel;
        }
    }
}
