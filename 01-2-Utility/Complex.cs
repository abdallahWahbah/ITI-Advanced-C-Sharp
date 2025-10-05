using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Complex
    {
        int real;
        int img;

        // Property
        public int Real
        {
            //set { real = value; }
            //get { return real; }
            set => real = value;
            get => real;
        }
        // shorthand
        //public int Real { get => img; set => real = value; }
        public int Img
        {
            set
            {
                if (value >= 1)
                    img = value;
                else
                    img = 0;
            }
            //get { return img; }
            get => img;
        }


        //// automatic property >>> used only if there is no restrictions on the set and get (no validation)
        //public int Real { set; get; }
        //public int Img { set; get; }

        public Complex() { }
        public Complex(int _real = 0, int _img = 0)
        {
            this.real = _real;
            this.img = _img;    
        }

        public override string ToString()
        {
            return $"{this.real} + {this.img}j";
        }
    }
}
