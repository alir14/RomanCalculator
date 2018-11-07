using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculatorFramework.Interface
{
    public interface INumberDataSet
    {
        string GetRomanVaue(int index);

        int GetIntegerVaue(string RomanValue);
    }
}
