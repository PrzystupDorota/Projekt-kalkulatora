using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorElektronika
{
    public interface IConductance
    {
        double Condensator1 { get; set; }

        double Condensator2 { get; set; }

        double CondensatorX { get; set; }
    }
}
