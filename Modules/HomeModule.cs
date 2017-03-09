using System.Collections.Generic;
using Nancy;
using System;
using Nancy.ViewEngines.Razor;
using SigilOfFlame.Objects;

namespace SigilOfFlame
{
    public class HomeModule : NancyModule
    {
        public static List<Unit> allUnits = Unit.GetAll();
        public static List<Player> allPlayers = Player.GetAll();
        public static List<Weapon> allWeapons = Weapon.GetAll();




        public HomeModule()
        {
            Get["/"] = _ => {
                Dictionary<string, object> allThings = new Dictionary<string, object>(){
                    {"allUnits", allUnits},
                    {"allPlayers", allPlayers},
                    {"allWeapons", allWeapons}
                };
                return View["index.cshtml", allThings];
            };

            Post["/"] = _ => {

                Player playerOne = new Player(Request.Form["player-one-name"]);
                Player playerTwo = new Player(Request.Form["player-two-name"]);
                playerOne.Save();
                playerTwo.Save();
                Dictionary<string, object> allThings = new Dictionary<string, object>(){
                    {"p1-name", playerOne.GetName()},
                    {"p2-name", playerTwo.GetName()},
                    {"p1-units", playerOne.GetUnits()},
                    {"p2-units", playerTwo.GetUnits()},
                    {"allUnits", allUnits},
                    {"allPlayers", allPlayers},
                    {"allWeapons", allWeapons}
                };

                return View["ready-check.cshtml", allThings];
            };

            Get["/arena"] = _ => {
                return View["arena.cshtml"];

            };
        }
    }
}
