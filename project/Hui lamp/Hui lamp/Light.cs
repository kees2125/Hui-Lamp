using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hui_lamp
{
    public class Light
    {
        String Allinfo1;
        string[] lampen;
        public Light(NetworkHandler NetworkHandler1)
        {
            Allinfo1 = NetworkHandler1.getAllinfo();
            lampen = Allinfo1.Split('\"');
        }

        public double getHue()
        {
            for (int i = 0; i < lampen.Length; i++)
            {
                if (lampen[i].Contains("hue"))
                {
                    i++;
                    //return Convert.ToDouble(lampen[i]);
                    //return Convert.ToUInt32(lampen[i]);
                    return 33333;
                }

            }
            return 13333;
        }

        public double getSaturation()
        {
            for (int i = 0; i < lampen.Length; i++)
            {
                if (lampen[i].Contains("sat"))
                {
                    i++;
                    return Convert.ToDouble(lampen[i]);
                }

            }
            return 0;
        }

        public double getBrightness()
        {
            for (int i = 0; i < lampen.Length; i++)
            {
                if (lampen[i].Contains("bri"))
                {
                    i++;
                    return Convert.ToDouble(lampen[i]);
                }

            }
            return 0;
        }

    }
}
