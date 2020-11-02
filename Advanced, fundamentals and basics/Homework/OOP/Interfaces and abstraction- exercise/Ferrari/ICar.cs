using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface ICar
    {
        public string Model { get; set; }
        public bool Brakes { get; set; }
        public bool Pedal { get; set; }
    }
}
