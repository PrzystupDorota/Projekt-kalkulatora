using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KalkulatorElektronika
{
    public class SeriesResistance : IResistance
    {
        private double resistor1;
        private double resistor2;
        private double resistorX;
   
    public SeriesResistance()
    {
    }

    public double Resistor1
    {
        get
        {
                if (this.resistorX - this.resistor2 > 0)
                {
                    return this.resistorX - this.resistor2;
                }

                MessageBox.Show("Please enter valid values!");
                return 0;
       }

            set
       {
            this.resistor1 = value;
       }
   }

        public double Resistor2
        {
            get
            {
                if (this.resistorX - this.resistor1 > 0)
                {
                    return this.resistorX - this.resistor1;
                }

                MessageBox.Show("Please enter valid values!");
                return 0;
            }

            set
            {
                this.resistor2 = value;
            }
        }

        public double ResistorX
        {
            get
            {
                return this.resistor1 + this.resistor2;               
            }

            set
            {
                this.resistorX = value;
            }
        }
    }
}
