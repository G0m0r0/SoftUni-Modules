using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot:IRobot
    {
        public Robot(string model)
        {
            this.Model = model;
    }
        public string Model { get; set; }
    }
}
