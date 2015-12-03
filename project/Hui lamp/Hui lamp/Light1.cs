using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hui_lamp
{
    public class Light1
    {
        double bri;
        double hue;
        double sat;
        public Light1(double bri, double hue, double sat)
        {
            this.bri = bri;
            this.hue = hue;
            this.sat = sat;
        }

        public void setColor(double bri, double hue, double sat)
        {
            this.bri = bri;
            this.hue = hue;
            this.sat = sat;
        }

        public double getHue()
        {
            return hue;
        }

        public double getSaturation()
        {
            return sat;
        }

        public double getBrightness()
        {
            return bri;
        }

    }
}
