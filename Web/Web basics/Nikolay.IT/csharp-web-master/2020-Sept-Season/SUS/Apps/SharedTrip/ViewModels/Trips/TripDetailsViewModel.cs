using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class TripDetailsViewModel:HomePageTripViewModel
    {
        public string ImagePath { get; set; }

        public string Description { get; set; }
    }
}
