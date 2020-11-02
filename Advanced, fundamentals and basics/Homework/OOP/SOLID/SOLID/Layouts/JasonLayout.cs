using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Layouts
{
    class JasonLayout : ILayout
    {
        public string Format => @"{{
   ""log"": {{
      ""date"": {0},
      ""level"": {1},
      ""message"": {2}
         }}
     }}";

    }
}

