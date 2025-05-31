using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {
        private Player _player;

        public Game()
        {
            _player = new Player();
        }
    }

    public class User
    {
        private int _name;

        public int Score { get; set; }
        public int GetScore()
        {
            return Score;
        }
    }

    public class Player : User
    {
        public string GetInfo()
        {
            return GetScore().ToString();
        }
    }

    public class Computer : User
    {
        public string GetInfo()
        {
            return GetScore().ToString();
        }
    }
}
