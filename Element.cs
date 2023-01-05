using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMC_NoName01
{
    class Element
    {
        int atomicNumber;
        private string element;
        private string symbol;
        private double mass;

        public int AtomicNumber
        {
            get => atomicNumber;
        }

        public string ElementName
        {
            get => element;
        }

        public string ElementSymbol
        {
            get => symbol;
        }

        public double AtomicMass
        {
            get => mass;
        }

        public Element(int atomicnumber,string name,string Symbols, double elementMass)
        {
            atomicNumber = atomicnumber;
            element = name;
            symbol = Symbols;
            mass = elementMass;
        }
    }
}
