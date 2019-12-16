using ViceCity.Core;
using ViceCity.Core.Contracts;
using System;
using ViceCity.Models.Guns;
using ViceCity.Models.Players;
using ViceCity.Repositories.Contracts;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
