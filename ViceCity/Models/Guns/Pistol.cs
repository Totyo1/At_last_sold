using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int initialBulletsPerBarrel = 10;
        private const int initialTotalBullets = 100;

        public Pistol(string name) : base(name, initialBulletsPerBarrel, initialTotalBullets)
        {

        }
    }
}
