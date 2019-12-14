using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        public string Name => throw new NotImplementedException();

        public IMotorcycle Motorcycle => throw new NotImplementedException();

        public int NumberOfWins => throw new NotImplementedException();

        public bool CanParticipate => throw new NotImplementedException();

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        public void WinRace()
        {
            throw new NotImplementedException();
        }
    }
}
