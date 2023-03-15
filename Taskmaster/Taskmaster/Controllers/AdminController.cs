using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Taskmaster.Data;
using Taskmaster.Models;
using Taskmaster.Shared;
using Taskmaster.ViewModels;

namespace Taskmaster.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly TaskmasterContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(TaskmasterContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin
        public IActionResult Index()
        {
            User user = _context.User
                .Where(u => u.Email == _userManager.GetUserName(User))
                .FirstOrDefault();

            var admin = new AdminViewModel();
            var topUser = new User();
            var taskCount = 0;
            var tasksDb = _context.Task.Where(t => !t.Completed);
            var usersDb = _context.User.Include(u => u.Tasks);

            // Create dictionary of number of tasks per price range.
            var tasksPerPayment = new Dictionary<string, int>();
            tasksPerPayment.Add("$0 - $100", 0);
            tasksPerPayment.Add("$100 - $250", 0);
            tasksPerPayment.Add("$250 - $500", 0);
            tasksPerPayment.Add("$500 - $1000", 0);
            tasksPerPayment.Add("$1000 - $2000", 0);
            tasksPerPayment.Add("Over $2000", 0);
            foreach (var taskDb in tasksDb)
            {
                if (taskDb.Payment <= 100)
                {
                    tasksPerPayment["$0 - $100"]++;
                }
                else if (taskDb.Payment <= 250)
                {
                    tasksPerPayment["$100 - $250"]++;
                }
                else if (taskDb.Payment <= 500)
                {
                    tasksPerPayment["$250 - $500"]++;
                }
                else if (taskDb.Payment <= 1000)
                {
                    tasksPerPayment["$500 - $1000"]++;
                }
                else if (taskDb.Payment <= 2000)
                {
                    tasksPerPayment["$1000 - $2000"]++;
                }
                else
                {
                    tasksPerPayment["Over $2000"]++;
                }
            }

            // Determine size of largest bar.
            var maxBar = 0;
            foreach (var bar in tasksPerPayment)
            {
                if (bar.Value > maxBar)
                {
                    maxBar = bar.Value;
                }
            }
            maxBar = int.Parse((Math.Round((((double)maxBar / 50) + 0.049) * 10) * 5).ToString());

            // Generate compatible data for bar graph.
            var xAxis = new List<BarViewModel>();
            foreach (var bar in tasksPerPayment)
            {
                var percent = ((double)bar.Value / maxBar) * 100;
                xAxis.Add(new BarViewModel()
                {
                    Title = bar.Key,
                    Value = percent.ToString(),
                    Tooltip = bar.Value.ToString()
                });
            }
            admin.Xaxis = xAxis.AsEnumerable();

            // Generate y axis of bar graph.
            var yAxis = new List<string>();
            yAxis.Add(maxBar.ToString());
            yAxis.Add((maxBar * 0.8).ToString());
            yAxis.Add((maxBar * 0.6).ToString());
            yAxis.Add((maxBar * 0.4).ToString());
            yAxis.Add((maxBar * 0.2).ToString());
            yAxis.Add("0");
            admin.Yaxis = yAxis.AsEnumerable();

            // Generate data for most active tasks for a user.
            foreach(var userDb in usersDb)
            {
                if(userDb.Tasks.Count(t => !t.Completed) > taskCount)
                {
                    taskCount = userDb.Tasks.Count(t => !t.Completed);
                    topUser = userDb;
                }
            }
            admin.ActiveTasks = new AdminPanelViewModel()
            {
                ID = topUser.UserID,
                Name = topUser.Name,
                Email = topUser.Email,
                Value = taskCount
            };

            // Generate data for most tasks completed for a user.
            taskCount = 0;
            foreach (var userDb in usersDb)
            {
                if (userDb.Tasks.Count(t => t.Completed) > taskCount)
                {
                    taskCount = userDb.Tasks.Count(t => t.Completed);
                    topUser = userDb;
                }
            }
            admin.CompletedTasks = new AdminPanelViewModel()
            {
                ID = topUser.UserID,
                Name = topUser.Name,
                Email = topUser.Email,
                Value = taskCount
            };

            // Generate data for most tasks completed for the current user.
            admin.YourTasks = new AdminPanelViewModel()
            {
                ID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Value = user.Tasks.Count(t => !t.Completed)
            };

            return View(admin);
        }

        // GET: Admin/Users
        public async Task<IActionResult> Users()
        {
            var users = new List<UserViewModel>();
            var usersDb = _context.User.Where(u => u.Email.ToLower() != "administrator@taskmaster.com.au").Include(u => u.AspUser);

            foreach (var userDb in usersDb)
            {
                users.Add(new UserViewModel()
                {
                    UserID = userDb.UserID,
                    Name = userDb.Name,
                    Address = userDb.Address,
                    City = userDb.City,
                    State = userDb.State,
                    Postcode = userDb.Postcode,
                    Phone = userDb.Phone,
                    Email = userDb.Email,
                    Description = userDb.Description,
                    PublicProfile = userDb.PublicProfile,
                    Active = userDb.AspUser.LockoutEnd == null,
                    Administrator = await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(userDb.AspUser.Id), "Admin"),
                    Permanent = await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(userDb.AspUser.Id), "Permanent")
                });
            }

            return View(users.AsEnumerable());
        }

        // GET: Admin/UserDetails/<id>
        public async Task<IActionResult> UserDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var userDb = await _context.User.Include(u => u.AspUser).FirstOrDefaultAsync(m => m.UserID == id);
            if (userDb == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var user = new UserViewModel()
            {
                UserID = userDb.UserID,
                Name = userDb.Name,
                Address = userDb.Address,
                City = userDb.City,
                State = userDb.State,
                Postcode = userDb.Postcode,
                Phone = userDb.Phone,
                Email = userDb.Email,
                Description = userDb.Description,
                PublicProfile = userDb.PublicProfile,
                Active = userDb.AspUser.LockoutEnd == null,
                Administrator = await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(userDb.AspUser.Id), "Admin"),
                Permanent = await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(userDb.AspUser.Id), "Permanent")
            };

            // Add skills collection to viewModel.
            var categories = new List<CategoryViewModel>();
            var skillUserPairs = _context.SkillUserPair.Where(sup => sup.User.UserID == id).Include(sup => sup.Skill).ThenInclude(s => s.Category);
            foreach (var skillTaskPair in skillUserPairs)
            {
                var found = false;
                foreach (var category in categories)
                {
                    // Category already create, add skill to category.
                    if (category.ID == skillTaskPair.Skill.Category.ID)
                    {
                        var tempSkills = category.Skills.ToList();
                        tempSkills.Add(new SkillViewModel()
                        {
                            ID = skillTaskPair.Skill.ID,
                            Name = skillTaskPair.Skill.Name,
                            Description = skillTaskPair.Skill.Description,
                            CategoryName = skillTaskPair.Skill.Category.Name
                        });
                        category.Skills = tempSkills.AsEnumerable();
                        found = true;
                    }
                }

                // Category doesn't exist, create and add skill to new category.
                if (!found)
                {
                    categories.Add(new CategoryViewModel()
                    {
                        ID = skillTaskPair.Skill.Category.ID,
                        Name = skillTaskPair.Skill.Category.Name,
                        Description = skillTaskPair.Skill.Category.Description,
                        Skills = new List<SkillViewModel>()
                        {
                            new SkillViewModel()
                            {
                                ID = skillTaskPair.Skill.ID,
                                Name = skillTaskPair.Skill.Name,
                                Description = skillTaskPair.Skill.Description,
                                CategoryName = skillTaskPair.Skill.Category.Name
                            }
                        }.AsEnumerable()
                    });
                }
            }
            user.Categories = categories.AsEnumerable();

            return View(user);
        }

        // GET: Admin/DeactivateUser/<id>
        public async Task<IActionResult> DeactivateUser(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Users));
            }

            var user = await _context.User.Where(u => u.UserID == id).Include(u => u.AspUser).FirstOrDefaultAsync();
            if (user == null)
            {
                return RedirectToAction(nameof(Users));
            }

            // Set lockout for 100 years (fake deactivation).
            await _userManager.SetLockoutEndDateAsync(await _userManager.FindByIdAsync(user.AspUser.Id), DateTime.Now.AddYears(100));

            return RedirectToAction(nameof(Users));
        }

        // GET: Admin/ActivateUser/<id>
        public async Task<IActionResult> ActivateUser(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Users));
            }

            var user = await _context.User.Where(u => u.UserID == id).Include(u => u.AspUser).FirstOrDefaultAsync();
            if (user == null)
            {
                return RedirectToAction(nameof(Users));
            }

            // Set lockout to null (fake activation).
            await _userManager.SetLockoutEndDateAsync(await _userManager.FindByIdAsync(user.AspUser.Id), null);

            return RedirectToAction(nameof(Users));
        }

        // GET: Admin/UpgradeUser/<id>
        public async Task<IActionResult> UpgradeUser(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Users));
            }

            var user = await _context.User.Where(u => u.UserID == id).Include(u => u.AspUser).FirstOrDefaultAsync();
            if (user == null)
            {
                return RedirectToAction(nameof(Users));
            }

            // Add user to Admin role.
            await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(user.AspUser.Id), "Admin");

            return RedirectToAction(nameof(Users));
        }

        // GET: Admin/DowngradeUser/<id>
        public async Task<IActionResult> DowngradeUser(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Users));
            }

            var user = await _context.User.Where(u => u.UserID == id).Include(u => u.AspUser).FirstOrDefaultAsync();
            if (user == null)
            {
                return RedirectToAction(nameof(Users));
            }

            // Remove user from Admin role.
            await _userManager.RemoveFromRoleAsync(await _userManager.FindByIdAsync(user.AspUser.Id), "Admin");

            return RedirectToAction(nameof(Users));
        }

        // GET: Admin/Skills
        public IActionResult Skills()
        {
            var categories = new List<CategoryViewModel>();
            var categoriesDb = _context.Skill.Where(s => s.Category == null);

            // Cycle through each category and create a view model.
            foreach (var categoryDb in categoriesDb)
            {
                var category = new CategoryViewModel()
                {
                    ID = categoryDb.ID,
                    Name = categoryDb.Name,
                    Description = categoryDb.Description
                };

                // Get all skills for this category and create view models.
                var skillsDb = _context.Skill.Where(s => s.Category != null && s.Category.ID == categoryDb.ID);
                var skills = new List<SkillViewModel>();
                foreach (var skillDb in skillsDb)
                {
                    skills.Add(new SkillViewModel()
                    {
                        ID = skillDb.ID,
                        Name = skillDb.Name,
                        Description = skillDb.Description
                    });
                }
                category.Skills = skills.AsEnumerable();
                categories.Add(category);
            }

            return View(categories.AsEnumerable());
        }

        // GET: Skills/AddCategory
        public IActionResult AddCategory()
        {
            return View();
        }

        // POST: Skills/AddCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory([Bind("Name,Description")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var skillDb = new Skill()
                {
                    Name = category.Name,
                    Description = category.Description
                };
                _context.Add(skillDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Skills));
            }
            return View(category);
        }

        // GET: Skills/EditCategory/<id>
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var skillDb = await _context.Skill.FindAsync(id);
            if (skillDb == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var category = new CategoryViewModel()
            {
                ID = skillDb.ID,
                Name = skillDb.Name,
                Description = skillDb.Description
            };

            return View(category);
        }

        // POST: Skills/EditCategory/<id>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, [Bind("ID,Name,Description")] CategoryViewModel category)
        {
            if (id != category.ID)
            {
                return RedirectToAction(nameof(Skills));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var skillDb = await _context.Skill.FindAsync(id);
                    skillDb.Name = category.Name;
                    skillDb.Description = category.Description;
                    _context.Update(skillDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(category.ID))
                    {
                        return RedirectToAction(nameof(Skills));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Skills));
            }
            return View(category);
        }

        // GET: Skills/DeleteCategory/<id>
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var categoryDb = await _context.Skill.FirstOrDefaultAsync(m => m.ID == id);
            if (categoryDb == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var category = new CategoryViewModel()
            {
                ID = categoryDb.ID,
                Name = categoryDb.Name,
                Description = categoryDb.Description
            };

            return View(category);
        }

        // POST: Skills/DeleteCategory/<id>
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoryConfirmed(int id)
        {
            var categoryDb = await _context.Skill.FindAsync(id);
            var skillsDb = _context.Skill.Where(s => s.Category != null && s.Category.ID == id);

            // Remove all associated skills, including links to profiles and tasks.
            foreach (var skillDb in skillsDb)
            {
                // Remove each link to a task.
                var skillTaskPairs = _context.SkillTaskPair.Where(stp => stp.skill.ID == skillDb.ID);
                foreach (var skillTaskPair in skillTaskPairs)
                {
                    _context.SkillTaskPair.Remove(skillTaskPair);
                }

                // Remove each link to a user.
                var skillUserPairs = _context.SkillUserPair.Where(sup => sup.Skill.ID == skillDb.ID);
                foreach (var skillUserPair in skillUserPairs)
                {
                    _context.SkillUserPair.Remove(skillUserPair);
                }

                // Remove the skill.
                _context.Skill.Remove(skillDb);
            }

            _context.Skill.Remove(categoryDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Skills));
        }

        // GET: Skills/AddSkill/<id>
        public async Task<IActionResult> AddSkill(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var skillDb = await _context.Skill.FindAsync(id);
            if (skillDb == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var skill = new SkillViewModel()
            {
                CategoryName = skillDb.Name
            };

            return View(skill);
        }

        // POST: Skills/AddSkill/<id>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSkill(int id, [Bind("Name,Description")] SkillViewModel skill)
        {
            if (ModelState.IsValid)
            {
                var skillDb = new Skill()
                {
                    Name = skill.Name,
                    Description = skill.Description,
                    Category = await _context.Skill.FindAsync(id)
                };
                _context.Add(skillDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Skills));
            }
            return View(skill);
        }

        // GET: Skills/EditSkill/<id>
        public async Task<IActionResult> EditSkill(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var skillDb = await _context.Skill.Where(s => s.ID == id).Include(s => s.Category).FirstOrDefaultAsync();
            if (skillDb == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var skill = new SkillViewModel()
            {
                ID = skillDb.ID,
                Name = skillDb.Name,
                Description = skillDb.Description,
                CategoryName = skillDb.Category.Name
            };

            return View(skill);
        }

        // POST: Skills/EditSkill/<id>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSkill(int id, [Bind("ID,Name,Description")] SkillViewModel skill)
        {
            if (id != skill.ID)
            {
                return RedirectToAction(nameof(Skills));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var skillDb = await _context.Skill.FindAsync(id);
                    skillDb.Name = skill.Name;
                    skillDb.Description = skill.Description;
                    _context.Update(skillDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.ID))
                    {
                        return RedirectToAction(nameof(Skills));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Skills));
            }
            return View(skill);
        }

        // GET: Skills/DeleteSkill/<id>
        public async Task<IActionResult> DeleteSkill(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var skillDb = await _context.Skill.Where(s => s.ID == id).Include(s => s.Category).FirstOrDefaultAsync();
            if (skillDb == null)
            {
                return RedirectToAction(nameof(Skills));
            }

            var skill = new SkillViewModel()
            {
                ID = skillDb.ID,
                Name = skillDb.Name,
                Description = skillDb.Description,
                CategoryName = skillDb.Category.Name
            };

            return View(skill);
        }

        // POST: Skills/DeleteSkill/<id>
        [HttpPost, ActionName("DeleteSkill")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSkillConfirmed(int id)
        {
            var skillDb = await _context.Skill.FindAsync(id);

            // Remove each link to a task.
            var skillTaskPairs = _context.SkillTaskPair.Where(stp => stp.skill.ID == skillDb.ID);
            foreach (var skillTaskPair in skillTaskPairs)
            {
                _context.SkillTaskPair.Remove(skillTaskPair);
            }

            // Remove each link to a user.
            var skillUserPairs = _context.SkillUserPair.Where(sup => sup.Skill.ID == skillDb.ID);
            foreach (var skillUserPair in skillUserPairs)
            {
                _context.SkillUserPair.Remove(skillUserPair);
            }

            // Remove the skill.
            _context.Skill.Remove(skillDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Skills));
        }

        // GET: Admin/AnalyticTaskCurrent
        public IActionResult AnalyticTaskCurrent()
        {
            var analytics = new AnalyticsViewModel();
            var tasksDb = _context.Task.Where(t => !t.Completed);
            var serializer = new JsonSerializer();

            // Create dictionary of number of tasks per price range.
            var tasksPerPaymentDictionary = new Dictionary<string, int>();
            tasksPerPaymentDictionary.Add("$0 - $100", 0);
            tasksPerPaymentDictionary.Add("$100 - $250", 0);
            tasksPerPaymentDictionary.Add("$250 - $500", 0);
            tasksPerPaymentDictionary.Add("$500 - $1000", 0);
            tasksPerPaymentDictionary.Add("$1000 - $2000", 0);
            tasksPerPaymentDictionary.Add("Over $2000", 0);
            foreach (var taskDb in tasksDb)
            {
                if (taskDb.Payment <= 100)
                {
                    tasksPerPaymentDictionary["$0 - $100"]++;
                }
                else if (taskDb.Payment <= 250)
                {
                    tasksPerPaymentDictionary["$100 - $250"]++;
                }
                else if (taskDb.Payment <= 500)
                {
                    tasksPerPaymentDictionary["$250 - $500"]++;
                }
                else if (taskDb.Payment <= 1000)
                {
                    tasksPerPaymentDictionary["$500 - $1000"]++;
                }
                else if (taskDb.Payment <= 2000)
                {
                    tasksPerPaymentDictionary["$1000 - $2000"]++;
                }
                else
                {
                    tasksPerPaymentDictionary["Over $2000"]++;
                }
            }
            var tasksPerPaymentRange = new List<PieViewModel>();
            foreach (var taskPerPayment in tasksPerPaymentDictionary)
            {
                tasksPerPaymentRange.Add(new PieViewModel()
                {
                    title = taskPerPayment.Key,
                    value = (int)Math.Round(((double)taskPerPayment.Value / tasksDb.Count()) * 100),
                    color = GetPiechartColour(taskPerPayment.Key)
                });
            }
            analytics.TasksPerPaymentRange = tasksPerPaymentRange.AsEnumerable();
            var stringWriter = new StringWriter();
            using (var writer = new JsonTextWriter(stringWriter))
            {
                writer.QuoteName = false;
                serializer.Serialize(writer, tasksPerPaymentRange);
            }
            analytics.TasksPerPaymentRangeJson = stringWriter.ToString();

            // Create dictionary of number of tasks per type.
            var tasksPerTypeDictionary = new Dictionary<string, int>();
            tasksPerTypeDictionary.Add("Fixed Price", 0);
            tasksPerTypeDictionary.Add("Bounty", 0);
            tasksPerTypeDictionary.Add("Tender", 0);
            foreach (var taskDb in tasksDb)
            {
                if (taskDb.Type == TaskType.Fixed)
                {
                    tasksPerTypeDictionary["Fixed Price"]++;
                }
                if (taskDb.Type == TaskType.Bounty)
                {
                    tasksPerTypeDictionary["Bounty"]++;
                }
                if (taskDb.Type == TaskType.Tender)
                {
                    tasksPerTypeDictionary["Tender"]++;
                }
            }
            var tasksPerType = new List<PieViewModel>();
            foreach (var taskPerType in tasksPerTypeDictionary)
            {
                tasksPerType.Add(new PieViewModel()
                {
                    title = taskPerType.Key,
                    value = (int)Math.Round(((double)taskPerType.Value / tasksDb.Count()) * 100),
                    color = GetPiechartColour(taskPerType.Key)
                });
            }
            analytics.TaskPerType = tasksPerType.AsEnumerable();
            stringWriter = new StringWriter();
            using (var writer = new JsonTextWriter(stringWriter))
            {
                writer.QuoteName = false;
                serializer.Serialize(writer, tasksPerType);
            }
            analytics.TaskPerTypeJson = stringWriter.ToString();

            // Create dictionary of number of tasks per presence.
            var tasksPerPresenceDictionary = new Dictionary<string, int>();
            tasksPerPresenceDictionary.Add("From Home", 0);
            tasksPerPresenceDictionary.Add("Travel Required", 0);
            foreach (var taskDb in tasksDb)
            {
                if (taskDb.PresenceLevel == PresenceLevel.Home)
                {
                    tasksPerPresenceDictionary["From Home"]++;
                }
                if (taskDb.PresenceLevel == PresenceLevel.Away)
                {
                    tasksPerPresenceDictionary["Travel Required"]++;
                }
            }
            var tasksPerPresence = new List<PieViewModel>();
            foreach (var taskPerPresence in tasksPerPresenceDictionary)
            {
                tasksPerPresence.Add(new PieViewModel()
                {
                    title = taskPerPresence.Key,
                    value = (int)Math.Round(((double)taskPerPresence.Value / tasksDb.Count()) * 100),
                    color = GetPiechartColour(taskPerPresence.Key)
                });
            }
            analytics.TasksPerPresence = tasksPerPresence.AsEnumerable();
            stringWriter = new StringWriter();
            using (var writer = new JsonTextWriter(stringWriter))
            {
                writer.QuoteName = false;
                serializer.Serialize(writer, tasksPerPresence);
            }
            analytics.TasksPerPresenceJson = stringWriter.ToString();

            return View(analytics);
        }

        private bool SkillExists(int id)
        {
            return _context.Skill.Any(e => e.ID == id);
        }

        private string GetPiechartColour(string title)
        {
            var colour = "#000000";
            switch(title)
            {
                // Colours for Tasks Per Payment Range.
                case "$0 - $100":
                    colour = "#f77f00";
                    break;
                case "$100 - $250":
                    colour = "#fcbf49";
                    break;
                case "$250 - $500":
                    colour = "#d62828";
                    break;
                case "$500 - $1000":
                    colour = "#6930c3";
                    break;
                case "$1000 - $2000":
                    colour = "#06d6a0";
                    break;
                case "Over $2000":
                    colour = "#118ab2";
                    break;
                // Colours for Tasks Per Type.
                case "Fixed Price":
                    colour = "#e76f51";
                    break;
                case "Bounty":
                    colour = "#2a9d8f";
                    break;
                case "Tender":
                    colour = "#264653";
                    break;
                // Colours for Tasks Per Prescence.
                case "From Home":
                    colour = "#e63946";
                    break;
                case "Travel Required":
                    colour = "#1d3557";
                    break;
            }

            return colour;
        }
    }
}
