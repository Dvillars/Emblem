using System.Collections.Generic;
using Nancy;
using System;
using Nancy.ViewEngines.Razor;

namespace SigilOfFlame
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
            List<Unit> allUnits = Unit.GetAll();
            return View["index.cshtml", allUnits];
        };
        }
    }
}
