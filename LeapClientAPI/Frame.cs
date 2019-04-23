using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeapClientAPI
{
    class Frame
    {
        public String ip { get; set; }
        public String positionX { get; set; }
        public String positionY { get; set; }
        public String dump { get; set; }
        public String toString { get; set; }
        public List<Hand> hands { get; set; }
    }
}
