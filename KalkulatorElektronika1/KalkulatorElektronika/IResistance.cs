using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorElektronika
{ 
    public interface IResistance
    {        
        double Resistor1 { get; set; }

        double Resistor2 { get; set; }

        double ResistorX { get; set; }
    }
}