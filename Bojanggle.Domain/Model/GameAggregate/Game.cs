using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bojanggle.Domain.Model.GameAggregate
{
    public enum GameStatus
    {
        Initialized,
        InPlay,
        Finished
    }

    public class Game
    {
        private readonly Board _board;

        private readonly ITimer _gameTimer;

        public ShuffleResult CurrentShuffle { get; private set; }

        public GameStatus Status { get; set; }

        public Game(ITimer gameTimer)
        {
            _board = new Board(new GameSetup());
            _gameTimer = gameTimer;
            _gameTimer.CountdownStopped += _gameTimer_CountdownStopped;

            Status = GameStatus.Initialized;
        }

        private void _gameTimer_CountdownStopped(object sender, EventArgs e)
        {
            Status = GameStatus.Finished;
        }

        public void StartNew()
        {
            CurrentShuffle = _board.Shuffle();
            _gameTimer.StartCountdown();

            Status = GameStatus.InPlay;
        }
    }
}
