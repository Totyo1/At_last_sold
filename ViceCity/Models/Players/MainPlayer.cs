using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int InitialLifePoint = 100;
        private const string InitialName = "Tommy Vercetti";

        public MainPlayer() : base(InitialName, InitialLifePoint)
        {

        }
    }
}
