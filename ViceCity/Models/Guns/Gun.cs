using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;
        private bool canFire;
        private const int initialBulletsPerBarrel = 10;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
            this.CanFire = canFire;

        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }
                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }
                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }
                this.totalBullets = value;
            }
        }

        public bool CanFire
        {
            get
            {
                if (this.BulletsPerBarrel == 0 && this.totalBullets == 0)
                {
                    this.canFire = false;
                }
                else
                {
                    this.canFire = true;
                }
                return this.canFire;
            }
            set
            {
                this.canFire = value; 
            }
        }

        public virtual int Fire()
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
