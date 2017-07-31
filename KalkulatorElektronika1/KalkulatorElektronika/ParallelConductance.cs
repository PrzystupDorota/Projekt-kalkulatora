using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KalkulatorElektronika
{    
        public class ParallelConductance : IConductance
        {
            private double condensator1;
            private double condensator2;
            private double condensatorX;

            public ParallelConductance()
            {
            }

            public double Condensator1
            {
                get
                {
                    if (this.condensatorX - this.condensator2 > 0)
                    {
                        return this.condensatorX - this.condensator2;
                    }

                    MessageBox.Show("Please enter valid values!");
                    return 0;
                }

                set
                {
                    this.condensator1 = value;
                }
            }

            public double Condensator2
            {
                get
                {
                    if (this.condensatorX - this.condensator1 > 0)
                    {
                        return this.condensatorX - this.condensator1;
                    }

                    MessageBox.Show("Please enter valid values!");
                    return 0;
                }

                set
                {
                    this.condensator2 = value;
                }
            }

            public double CondensatorX
            {
                get
                {
                    return this.condensator1 + this.condensator2;
                }

                set
                {
                    this.condensatorX = value;
                }
            }
        }
    }