using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int BulletsPerShot = 1;

        public Pistol(string name) : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
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
