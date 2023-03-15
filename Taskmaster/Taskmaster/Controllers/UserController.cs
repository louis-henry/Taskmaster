using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Taskmaster.Data;
using Taskmaster.Models;
using Taskmaster.ViewModels;

namespace Taskmaster.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly TaskmasterContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(TaskmasterContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: Skills
        public IActionResult Skills()
        {
            User user = _context.User
                  .Where(u => u.Email == _userManager.GetUserName(User))
                  .FirstOrDefault();

            var skillUserPairsDb = _context.SkillUserPair
                .Where(s => s.User.UserID == user.UserID)
                .Include(sup => sup.Skill)
                .ThenInclude(s => s.Category);
            var skillManagement = new SkillManagementViewModel()
            {
                Categories = GenerateCategories(),
                Skills = GetUserSkills(skillUserPairsDb)
            };

            return View(skillManagement);
        }

        // POST: Skills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Skills([Bind("ID")] SkillManagementViewModel model)
        {
            User user = _context.User
                  .Where(u => u.Email == _userManager.GetUserName(User))
                  .FirstOrDefault();

            var skillDb = await _context.Skill.FindAsync(model.ID);
            if (skillDb == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            // Check if skill already associated with user.
            var skillUserPairDb = await _context.SkillUserPair.FirstOrDefaultAsync(sup => sup.User.UserID == user.UserID && sup.Skill.ID == model.ID);
            if(skillUserPairDb != null)
            {
                var skillUserPairsDb = _context.SkillUserPair
                    .Where(s => s.User.UserID == user.UserID)
                    .Include(sup => sup.Skill)
                    .ThenInclude(s => s.Category);

                model.Categories = GenerateCategories();
                model.Skills = GetUserSkills(skillUserPairsDb);
                ModelState.AddModelError("ID", "Selected skill already chosen.");

                return View(model);
            }

            // Add skill to User
            _context.SkillUserPair.Add(new SkillUserPair()
            {
                User = user,
                Skill = skillDb
            });
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Skills));
        }

        // GET: DeleteSkill
        public async Task<IActionResult> DeleteSkill(int? id)
        {
            User user = _context.User
                .Where(u => u.Email == _userManager.GetUserName(User))
                .FirstOrDefault();

            if (id == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var SkillUserPairDb = await _context.SkillUserPair
                .Where(s => s.User.UserID == user.UserID && s.Skill.ID == id)
                .FirstOrDefaultAsync();
            if (SkillUserPairDb == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            _context.SkillUserPair.Remove(SkillUserPairDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Skills));
        }

        // GET: Profile
        public IActionResult Profile()
        {
            return View();
        }

        // GET: Search
        public IActionResult Search()
        {
            return View();
        }

        // GET: ManageTasks
        public IActionResult ManageTasks()
        {
            return View();
        }

        // GET: Password
        public IActionResult Password()
        {
            return View();
        }

        // GET: Deactivate
        public IActionResult Deactivate()
        {
            return View();
        }

        // POST: Deactivate
        [HttpPost, ActionName("Deactivate"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed()
        {
            // Set lockout for 100 years (fake deactivation).
            await _userManager.SetLockoutEndDateAsync(await _userManager.GetUserAsync(User), DateTime.Now.AddYears(100));

            return RedirectToAction("Logout", "Secure");
        }

        // GET: Logout
        public IActionResult Logout()
        {
            return View();
        }

        // GET: Main
        public IActionResult Main()
        {
            return View();
        }

        private List<SelectListItem> GenerateCategories()
        {
            var categories = new List<SelectListItem>();
            var categoriesDb = _context.Skill.Where(s => s.Category == null);

            // Define all available skills for selection.
            foreach (var categoryDb in categoriesDb)
            {
                var category = new SelectListGroup()
                {
                    Name = categoryDb.Name
                };

                // Get all skills for this category and create select items.
                var skillsDb = _context.Skill.Where(s => s.Category != null && s.Category.ID == categoryDb.ID);
                foreach (var skillDb in skillsDb)
                {
                    categories.Add(new SelectListItem()
                    {
                        Value = skillDb.ID.ToString(),
                        Text = skillDb.Name,
                        Group = category
                    });
                }
            }

            return categories.OrderBy(s => s.Group.Name).ThenBy(s => s.Text).ToList();
        }

        private IEnumerable<SkillViewModel> GetUserSkills(IQueryable<SkillUserPair> skillUserPairsDb)
        {
            var skills = new List<SkillViewModel>();

            // Populate all current skills ready for display.
            foreach (var SkillUserPairDb in skillUserPairsDb)
            {
                skills.Add(new SkillViewModel()
                {
                    ID = SkillUserPairDb.Skill.ID,
                    Name = SkillUserPairDb.Skill.Name,
                    Description = SkillUserPairDb.Skill.Description,
                    CategoryName = SkillUserPairDb.Skill.Category.Name
                });
            }

            return skills.AsEnumerable();
        }
    }
}
