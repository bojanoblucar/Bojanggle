using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bojanggle.Domain.Model.GameAggregate
{
    public class Board
    {
        private readonly GameSetup setup;

        public Board(GameSetup setup)
        {
            this.setup = setup;
        }


        public ShuffleResult Shuffle()
        {
            var letters = new List<string>();

            var random = new Random(Guid.NewGuid().GetHashCode());
            foreach (var dice in ShuffleDices())
            {
                var letter = dice.Flip(random);
                letters.Add(letter);
            }

            return new ShuffleResult(letters.ToArray());
        }

        private List<Dice> ShuffleDices()
        {
            var random = new Random();
            var shuffled = setup.Dices.OrderBy(x => random.Next(1, 17)).ToList();
            return shuffled;
        }
    }
}
