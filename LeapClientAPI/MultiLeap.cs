using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeapClientAPI
{
    class MultiLeap
    {
        public List<Frame> sensors { get; set; }

        internal void reconstructData()
        {
            foreach(Frame f in sensors)
            {
                f.reconstructAll();
            }
        }
    }
}
