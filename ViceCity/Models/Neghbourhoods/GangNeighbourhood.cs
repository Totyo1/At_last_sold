using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var currGun in mainPlayer.GunRepository.Models)
            {
                foreach (var currPlayer in civilPlayers)
                {
                    while (currPlayer.IsAlive && currGun.CanFire)
                    {
                        currPlayer.TakeLifePoints(currGun.Fire());
                    }
                    if (!currGun.CanFire)
                    {
                        break;
                    }
                }
            }

            foreach (var currPlayer in civilPlayers)
            {
                if (!currPlayer.IsAlive)
                {
                    continue;
                }
                foreach (var currGun in currPlayer.GunRepository.Models)
                {
                    while (mainPlayer.IsAlive && currGun.CanFire)
                    {
                    mainPlayer.TakeLifePoints(currGun.Fire());
                    }
                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }
                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }

        }
    }
}
//IGun currGun = null;
//if (mainPlayer.GunRepository.Models.Count != 0)
//{
//    currGun = mainPlayer.GunRepository.Models.First();
//    mainPlayer.GunRepository.Remove(currGun);
//}
//IPlayer currPlayer = null;
//if (civilPlayers.Count != 0)
//{
//    currPlayer = civilPlayers.First();
//}

//while (true)
//{
//    if (currGun == null || (mainPlayer.GunRepository.Models.Count == 0 && !currGun.CanFire))
//    {
//        break;
//    }
//    if (!currGun.CanFire)
//    {
//        currGun = mainPlayer.GunRepository.Models.First();
//        mainPlayer.GunRepository.Remove(currGun);
//    }
//    if (currPlayer == null || (civilPlayers.Count == 0 && !currPlayer.IsAlive))
//    {
//        break;
//    }
//    if (!currPlayer.IsAlive)
//    {
//        currPlayer = civilPlayers.First();
//    }
//    while (currGun.CanFire && currPlayer.IsAlive)
//    {
//        currPlayer.TakeLifePoints(currGun.Fire());
//    }
//    if (!currPlayer.IsAlive)
//    {
//        civilPlayers.Remove(currPlayer);
//    }
//}
//if (currPlayer.IsAlive)
//{
//    while (currPlayer.GunRepository.Models.Count != 0 && civilPlayers.Count != 0)
//    {
//        if (currPlayer.GunRepository.Models.Count == 0)
//        {
//            civilPlayers.Remove(currPlayer);
//            currPlayer = civilPlayers.First();
//        }
//        currGun = currPlayer.GunRepository.Models.First();
//        currPlayer.GunRepository.Remove(currGun);

//        while (mainPlayer.IsAlive && currGun.CanFire)
//        {
//            mainPlayer.TakeLifePoints(currGun.Fire());
//        }
//    }
//}