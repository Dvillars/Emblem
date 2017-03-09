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
                playerOne.AddUnit(Unit.Find(Request.Form["p1-first-unit"]));
                playerOne.AddUnit(Unit.Find(Request.Form["p1-second-unit"]));
                playerOne.AddUnit(Unit.Find(Request.Form["p1-third-unit"]));
                playerOne.AddUnit(Unit.Find(Request.Form["p1-fourth-unit"]));
                playerOne.AddUnit(Unit.Find(Request.Form["p1-fifth-unit"]));
                playerTwo.AddUnit(Unit.Find(Request.Form["p2-first-unit"]));
                playerTwo.AddUnit(Unit.Find(Request.Form["p2-second-unit"]));
                playerTwo.AddUnit(Unit.Find(Request.Form["p2-third-unit"]));
                playerTwo.AddUnit(Unit.Find(Request.Form["p2-fourth-unit"]));
                playerTwo.AddUnit(Unit.Find(Request.Form["p2-fifth-unit"]));
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


        }
    }
}
