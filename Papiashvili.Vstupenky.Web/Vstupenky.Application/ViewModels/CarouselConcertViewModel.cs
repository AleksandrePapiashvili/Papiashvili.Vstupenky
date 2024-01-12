using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papiashvili.Vstupenky.Web.Vstupenky.Domain.Entites;

namespace Papiashvili.Vstupenky.Web.Vstupenky.Application.ViewModels
{
    public class CarouselConcertViewModel
    {
        public IList<Carousel> Carousels { get; set; }
        public IList<Concert> Concerts { get; set; }
    }
}
