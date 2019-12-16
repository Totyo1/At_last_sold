using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private IRepository<IGun> gunRepository;
        private bool isAllive;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.IsAlive = isAllive;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player's name cannot be null or a whitespace!");
                }
                this.name = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (this.lifePoints <= 0)
                {
                    this.isAllive = false;
                }
                else
                {
                    this.isAllive = true;
                }
                return this.isAllive;
            }
            set
            {
                this.isAllive = value;
            }
            
        }

        public int LifePoints
        {
            get => this.lifePoints;
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                this.lifePoints = value;
            }
        }

        public IRepository<IGun> GunRepository
        {
            get => this.gunRepository;
            set { this.gunRepository = value; }
        }

        public void TakeLifePoints(int points)
        {
            this.LifePoints -= points;
        }
    }
}
