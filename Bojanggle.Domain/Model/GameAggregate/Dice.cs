﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bojanggle.Domain.Model.GameAggregate
{
    public class Dice
    {
        private readonly Dictionary<int, string> page = new Dictionary<int, string>();

        public Dice(int id, params Letter[] letters)
        {

            for (int i = 0; i < 6; i++)
            {
                page[i] = letters[i].ToString();
            }

            Id = id;
        }


        public int Id { get; set; }

        private string ShowLetter(int sideNumber)
        {
            return page[sideNumber - 1];
        }

        public string Flip(Random random)
        {
            return ShowLetter(random.Next(1, 7));
        }
    }
}
