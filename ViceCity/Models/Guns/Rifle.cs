using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int BulletsPerShot = 5;

        public Rifle(string name) : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel < BulletsPerShot)
            {
                this.Reload(InitialBulletsPerBarrel);
            }
            return this.DecreaseBullets(BulletsPerShot);
        }
    }
}
