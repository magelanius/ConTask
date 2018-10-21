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

        public BoardController()
        {
            _context = new ApplicationDbContext();
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
            TableHeaderCell site = new TableHeaderCell();

            return View("../Board/Index", viewModel);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                            new DataColumn("Name", typeof(string)),
                            new DataColumn("Country",typeof(string)) });
                dt.Rows.Add(1, "John Hammond", "United States");
                dt.Rows.Add(2, "Mudassar Khan", "India");
                dt.Rows.Add(3, "Suzanne Mathews", "France");
                dt.Rows.Add(4, "Robert Schidner", "Russia");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        // GET: Board
        public ActionResult Index()
        {
            return View();
        }

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

            if (board.Id == "" || board.Id == null)
            {
                board.Id = Guid.NewGuid().ToString();
                
                var user = UserManager.FindById(User.Identity.GetUserId());
                var right = new BoardRight();
                right.Id = Guid.NewGuid().ToString();
                right.MemberId = user.Id;
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