﻿using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using System.Linq;

namespace ViceCity.Repositories.Contracts
{
    class GunRepository : IRepository<IGun>
    {
        public readonly IDictionary<string, IGun> guns;

        public IReadOnlyCollection<IGun> Models => this.guns.Values.ToList().AsReadOnly();

        public GunRepository()
        {
            this.guns = new Dictionary<string, IGun>();
        }
        
        public void Add(IGun model)
        {
            if (!this.guns.ContainsKey(model.Name))
            {
            this.guns.Add(model.Name, model);
            }
            
        }
        
        public IGun Find(string name)
        {
            return this.guns[name];
        }
        
        public bool Remove(IGun model)
        {
            if (!guns.ContainsKey(model.Name))
            {
                return false;
            }
            this.guns.Remove(model.Name);
            return true;
        }
    }
}