using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CDW2Project.FetchModel;
using CDW2Project.Models;
using CDW2Project.Services;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;
using ModelDatabase.EF;
using ModelDatabase.Handle_EF;

namespace CDW2Project.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class WatchArticleController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<UserAccount> _signInManager;
        public WatchArticleController(UserManager<UserAccount> userManager,
            ApplicationDbContext context,
            IMapper mapper,
            SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index(string id)
        {
            ArticleManager articleManager = new ArticleManager(_context);
            WatchArticleViewModel model = new WatchArticleViewModel();
            var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
            model.currentUserId = getUser.Id;
            model.roles = await _userManager.GetRolesAsync(getUser);
            var getArticle = await articleManager.GetArticleWithComment(id);
            if (getArticle != null)
            {
                model.article = getArticle;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "ErrorSite");
            }
        }
        public async Task<IActionResult> UpdateLikeOfArticle([FromBody] PostLikeModel model)
        {
            if (ModelState.IsValid)
            {
                Article ar = new Article();
                ar.Like = model.like += 1;
                ar.AriticleId = model.articleId;
                ArticleManager articleManager = new ArticleManager(_context);
                var result = await articleManager.UpdateLikeArticle(ar);
                if (result)
                {
                    return Json(new { like = ar.Like});
                }else
                {
                    return BadRequest("Paramaters passed is not invalid");
                }
            }
            return BadRequest("Paramaters passed is not invalid");
        }
        [HttpGet]
        public async Task<IActionResult> GetLikeOfArticle(string id)
        {
            ArticleManager articleManager = new ArticleManager(_context);
            var result = await articleManager.GetLikeArticle(id);
            if(result != null)
            {
                return Json(new {like = result});
            }
            return Json(new { like = 0});
        }
        [HttpPost]
        public async Task<IActionResult> PostCommentUser([FromBody] PostUpdateCommentModel model)
        {
            var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
            Comment comment = new Comment();
            MD5Service md5 = new MD5Service();
            var createCommentId = md5.GetHashId();
            comment.CommentId = createCommentId;
            comment.Date = DateTime.Now;
            comment.CommentUserAccountId = getUser.Id;
            comment.CommentArticleId = model.articleId;
            comment.Content = model.comment;
            CommentManager commentManager = new CommentManager(_context);
            bool result = await commentManager.InsertComment(comment);
            if (result)
            {
                return Json(new { add = true ,content = model.comment,user = getUser,commentId = createCommentId });
            }
            return BadRequest("Some things wrong");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComment(string id)
        {
            CommentManager commentManager = new CommentManager(_context);
            bool result = await commentManager.DeleteComment(id);
            if (result)
            {
                return Json(new { delete = true });
            }
            return BadRequest("System got some troubles");
        }
        public async Task<IActionResult> UpdateComment([FromBody] PostUpdateComment model)
        {
            CommentManager commentManager = new CommentManager(_context);
            Comment comment = new Comment();
            comment.CommentId = model.commentId;
            comment.Content = model.content;
            bool result = await commentManager.UpdateComment(comment);
            if (result)
            {
                return Json(new { update = result });
            }
            return BadRequest("Something is wrong");
        }
    }
}
