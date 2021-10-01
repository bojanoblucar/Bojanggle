using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bojanggle.Domain.Model.GameAggregate
{
    public class ShuffleResult
    {
        public ShuffleResult(string[] shuffleResult)
        {
            Result = shuffleResult;
        }

        public IReadOnlyList<string> Result { get; }
    }
}
