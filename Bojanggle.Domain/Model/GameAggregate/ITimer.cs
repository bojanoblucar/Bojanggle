using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bojanggle.Domain.Model.GameAggregate
{
    public interface ITimer
    {
        void StartCountdown();
        void StopCountdown();

        event EventHandler CountdownStopped;
    }
}
