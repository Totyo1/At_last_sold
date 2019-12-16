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


        public override int Fire()
        {
            if (!CanFire)
            {
                return 0;
            }
            if (BulletsPerBarrel == 0)
            {
                TotalBullets -= initialBulletsPerBarrel;
                BulletsPerBarrel = initialBulletsPerBarrel;
            }
            this.BulletsPerBarrel--;

            return 1;
        }
    }
}
