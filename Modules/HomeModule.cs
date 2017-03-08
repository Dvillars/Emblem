using System.Collections.Generic;
using Nancy;
using System;
using Nancy.ViewEngines.Razor;

namespace SigilOfFlame
{
    public class HomeModule : NancyModule
    {
        public static List<Unit> allUnits = Unit.GetAll();
        public static List<Player> allPlayers = Player.GetAll();
        public static List<Weapon> allWeapons = Weapon.GetAll();

        public static Player playerOne = new Player(Request.Form["player-one-name"]);
        public static Player playerTwo = new Player(Request.Form["player-two-name"]);

        public static Dictionary<string, object> allThings = new Dictionary<string, object>(){
            {"p1", Dictionary<string, object> playerOneInformation = new Dictionary<string, object>(){
                    {"name", playerOne.GetName()},
                    {"units", playerOne.GetUnits()}};
                },
            {"p2", Dictionary<string, object> playerTwoInformation = new Dictionary<string, object>(){
                    {"name", playerTwo.GetName()},
                    {"units", playerTwo.GetUnits()}};
                },
            {"allUnits", allUnits},
            {"allPlayers", allPlayers},
            {"allWeapons", allWeapons}
        };


        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml", allThings];
            };

            Post["/ready-check"] = _ => {

                return View["ready-check.cshtml"]
            };

            Get["/arena"] = _ => {
                return View["arena.cshtml", allthings]
            };
        }
    }
}
