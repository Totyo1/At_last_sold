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
        private readonly IList<IGun> guns;
        private readonly Dictionary<string, IPlayer> players;
        private readonly IPlayer mainPlayer;
        private readonly GangNeighbourhood neighbourhood; 
        private const string MainName = "Vercetti";

        public Controller()
        {
            mainPlayer = new MainPlayer();
            this.guns = new List<IGun>();
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
                    break;
                case "Rifle":
                    gun = new Rifle(name);
                    break;
                default:
                    return "Invalid gun type!";
            }
            guns.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            var message = string.Empty;
            if (guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var gun = this.guns.FirstOrDefault();

            if (name == MainName)
            {
                mainPlayer.GunRepository.Add(gun);
                guns.Remove(gun);

                return  $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            if (!players.ContainsKey(name) )
            {
                return "Civil player with that name doesn't exists!";
            }
            else
            {
                players[name].GunRepository.Add(gun);
                guns.Remove(gun);

                return $"Successfully added {gun.Name} to the Civil Player: {players[name].Name}";
            }
            

            return message;
        }
        public string Fight()
        {
            var sb = new StringBuilder();
            List<IPlayer> civils = players.Select(p => p.Value).ToList();
            int totalSumLifePoints = this.players.Values.Sum(p => p.LifePoints);
            neighbourhood.Action(mainPlayer, civils);
            var hps = civils.FindAll(x => x.IsAlive == true).ToList();
            int totalSumLifePointsAfter = this.players.Values.Sum(p => p.LifePoints);

            if (mainPlayer.LifePoints == 100 && totalSumLifePoints == totalSumLifePointsAfter)
            {
                sb.Append("Everything is okay!");

                return sb.ToString();
            }

            sb.AppendLine("A fight happened:")
                .AppendLine($"Tommy live points: {mainPlayer.LifePoints}!")
                .AppendLine($"Tommy has killed: {civils.Count - hps.Count} players!")
                .AppendLine($"Left Civil Players: {hps.Count}!");

            return sb.ToString();
        }
    }
}   