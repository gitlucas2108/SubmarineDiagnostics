using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineDiagnostics.Core.Interfaces
{
    public interface IBinaryRateCalculator
    {
        string Calculate(IEnumerable<string> diagnosticReport);
    }
}
