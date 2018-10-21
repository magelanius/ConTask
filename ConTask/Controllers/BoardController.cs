using ConTask.Models;
using ConTask.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace ConTask.Controllers
{
    public class BoardController : Controller
    {

        private ApplicationDbContext _context;
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private Board CurrentBoard { get; set; }
        MainTableViewModel viewModel;

        public BoardController()
        {
            _context = new ApplicationDbContext();
            viewModel = LoadTableViewModel();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this._context));
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new BoardFormViewModel();
            return View("New", viewModel);
        }
        public ActionResult Test()
        {
            var viewModel = _context.Boards.ToList();


            return View("../Board/Index", viewModel);
        }

        // GET: Board
        public ActionResult Index()
        {
            return View("Index", viewModel);
        }
        // builder??
        // then pass it to NGon so you have an access to data from js. Js can easily build the table
        //then create the same for saving and dont forget about validation etc
        public MainTableViewModel LoadTableViewModel()
        {
            MainTableViewModel viewModel = new MainTableViewModel();
            var user = UserManager.FindById(User.Identity.GetUserId());

            var boardsOfUser = _context.BoardRights.
                Where(x => x.UserId == user.Id).
                Select(x => x.BoardId);

            foreach (var item in boardsOfUser)
            {
                viewModel.Boards.Add(_context.Boards.FirstOrDefault(x => x.Id == item));
            }
            CurrentBoard = viewModel.Boards[0];
            viewModel.Projects = _context.Projects.Where(x => x.BoardId == CurrentBoard.Id).ToList();

            viewModel.BoardColumns = _context.BoardColumns.Where(x => x.BoardId == CurrentBoard.Id).ToList();

            foreach (var item in viewModel.Projects)
            {
                viewModel.ProjectTasks.AddRange(_context.ProjectTasks.
                    Where(x => x.ProjectId == item.Id).
                    ToList());
            }

            foreach (var task in viewModel.ProjectTasks)
            {
                viewModel.BoardRows.AddRange(_context.BoardRows.
                    Where(x => x.TaskId == task.Id).ToList());
            }

            return viewModel;
        }

        //public ActionResult BoardSelected
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Board board)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new BoardFormViewModel(board);

            //    return View("MovieForm", viewModel);
            //}

            if (board.Id == 0)
            {


                var user = UserManager.FindById(User.Identity.GetUserId());
                var right = new BoardRight();

                right.UserId = user.Id;
                right.BoardId = board.Id;
                right.StatusId = 0;

                _context.Boards.Add(board);
                _context.BoardRights.Add(right);

            }
            else
            {
                //var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                //movieInDb.Name = movie.Name;
                //movieInDb.GenreId = movie.GenreId;
                //movieInDb.NumberInStock = movie.NumberInStock;
                //movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}