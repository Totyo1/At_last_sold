using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    class Controller : IController
    {
        private Queue<IGun> guns;
        private Dictionary<string, IPlayer> players;
        private MainPlayer mainPlayer;
        private GangNeighbourhood neighbourhood; 
        private const string MainName = "Vercetti";

        public Controller()
        {
            mainPlayer = new MainPlayer();
            this.guns = new Queue<IGun>();
            this.players = new Dictionary<string, IPlayer>();
            this.neighbourhood = new GangNeighbourhood();
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            players.Add(name, player);
            return $"Successfully added civil player: {name}!";
        }


        public string AddGun(string type, string name)
        {
            IGun gun = null;
            switch (type)
            {
                case "Pistol":
                    gun = new Pistol(name);
                    guns.Enqueue(gun);

                    return $"Successfully added {name} of type: {type}";
                case "Rifle":
                    gun = new Rifle(name);
                    guns.Enqueue(gun);

                    return $"Successfully added {name} of type: {type}";
                default:

                    return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            if (!players.ContainsKey(name) && name != MainName)
            {
                return "Civil player with that name doesn't exists!";
            }

            var gun = guns.Dequeue();
            if (name == MainName)
            {
                mainPlayer.GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            players[name].GunRepository.Add(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {players[name].Name}";
        }
        public string Fight()
        {
            var sb = new StringBuilder();
            List<IPlayer> civils = players.Select(p => p.Value).ToList();
            int n = civils.Count;
            neighbourhood.Action(mainPlayer, civils);
            var hps = civils.FindAll(x => x.LifePoints == 50).ToList();

            if (mainPlayer.LifePoints == 100 && hps.Count == n)
            {
                sb.Append("Everything is okay!");
                return sb.ToString();
            }
            sb.AppendLine("A fight happened:")
                .AppendLine($"Tommy live points: {mainPlayer.LifePoints}!")
                .AppendLine($"Tommy has killed: {n - hps.Count} players!")
                .AppendLine($"Left Civil Players: {hps.Count}!");
            return sb.ToString();
        }
    }
}   