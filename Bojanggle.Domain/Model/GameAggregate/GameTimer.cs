using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bojanggle.Domain.Model.GameAggregate
{
    public class TimerCountdownEventArgs
    {
        public TimerCountdownEventArgs(int remainingTime)
        {
            RemainingTime = remainingTime;
        }

        public int RemainingTime { get; private set; }
    }

    public class GameTimer : ITimer
    {
        int _countdownInSeconds;

        public event EventHandler<TimerCountdownEventArgs> TimeCountdownEvent;
        public event EventHandler CountdownStopped;

        public GameTimer(int countdownInSeconds)
        {
            _countdownInSeconds = countdownInSeconds;
        }

        private Timer _timer;

        private int _remained;

        public void StopCountdown()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);

            CountdownStopped?.Invoke(this, EventArgs.Empty);
        }

        public void StartCountdown()
        {
            if (_timer == null)
                _timer = InitializeTimer();

            _remained = _countdownInSeconds;
            _timer.Change(0, 1000);

        }

        private Timer InitializeTimer()
        {
            return new Timer((status) =>
            {
                _remained -= 1;

                TimeCountdownEvent?.Invoke(this, new TimerCountdownEventArgs(_remained));

                if (_remained < 0)
                {
                    StopCountdown();
                }
            }, null, Timeout.Infinite, Timeout.Infinite);
        }
    }
}
