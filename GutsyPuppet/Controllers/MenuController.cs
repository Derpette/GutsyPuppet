using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GutsyPuppet.Model.Repositories.EFRepositories;
using GutsyPuppet.Model.Repositories.Interfaces;
using GutsyPuppet.Models;

namespace GutsyPuppet.Controllers
{
    public class MenuController : Controller
    {
        
        private readonly ITeamRepository _teamRepository;

        public MenuController()
        {
            var contextRepository = new ContextRepository();
            _teamRepository = new TeamRepository(contextRepository);
        }

        // GET: Menu
        public ActionResult Index()
        {
            // Get teams
            var menuViewModel = new MenuViewModel();
            // TODO: Cache this bit
            var visibleTeams = ConfigurationManager.AppSettings["VisibleTeams"].Split(',');
            var teams = _teamRepository.GetTeams().Where(t => visibleTeams.Contains(t.Name) ).Select(t => new MenuViewModel.TeamViewModel
            {
                Id = t.TeamId,
                Name = t.Name
            }).OrderBy(t => t.Name).ToList();
            teams.Insert(0, new MenuViewModel.TeamViewModel
            {
                Id = -1,
                Name = "All users"
            });
            menuViewModel.Teams = teams;
            return PartialView(menuViewModel);
        }
    }
}