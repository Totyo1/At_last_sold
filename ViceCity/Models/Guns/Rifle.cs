using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    class Rifle : Gun
    {
        private const int initialBulletsPerBarrel = 50;
        private const int initialTotalBullets = 500;

        public Rifle(string name) : base(name, initialBulletsPerBarrel, initialTotalBullets)
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
            this.BulletsPerBarrel -= 5;

            return 5;
        }
    }
}
