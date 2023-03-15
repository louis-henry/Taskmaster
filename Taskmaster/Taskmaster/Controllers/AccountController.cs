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
//using Task = Taskmaster.Models.Task;

namespace Taskmaster.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly TaskmasterContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(TaskmasterContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Profile
        public IActionResult Profile()
        {
            User user = _context.User
                 .Where(u => u.Email == _userManager.GetUserName(User))
                 .FirstOrDefault();
            var _user = CastingProfileViewModel(user);

            

            return View(_user);
        }

        // POST: Profile
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _context.User
                    .Where(u => u.Email == _userManager.GetUserName(User))
                    .FirstOrDefault();

                user.Name = model.Name;
                user.Email = model.Email;
                user.Address = model.Address;
                user.City = model.City;
                user.Postcode = model.Postcode;
                user.State = model.State;
                user.Phone = model.Phone;
                user.PublicProfile = model.PublicProfile;
                user.Description = model.Description;

                _context.User.Update(user);

                await _context.SaveChangesAsync();
            
                return View(CastingProfileViewModel(user));
            }
            return View(model);
        }

        // GET: AddTask
        public IActionResult AddTask()
        {
            User user = _context.User
             .Where(u => u.Email == _userManager.GetUserName(User))
                 .FirstOrDefault();
            var task = new TaskViewModel()
            {
                PresenceLevel = Shared.PresenceLevel.None,
                Type = Shared.TaskType.None,
                CategoriesSelect = new List<SelectListItem>()
            };
            task.CategoriesSelect.Add(new SelectListItem()
            {
                Text = "Select most relevant skill required",
                Value = "0"
            });
            task.CategoriesSelect.AddRange(GenerateCategories());

            return View(task);
        }

        // POST: AddTask
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTask(TaskViewModel model)
        {
            // Generate all selectable skills for drop-down.
            model.CategoriesSelect = new List<SelectListItem>();
            model.CategoriesSelect.Add(new SelectListItem()
            {
                Text = "Select most relevant skill required",
                Value = "0"
            });
            model.CategoriesSelect.AddRange(GenerateCategories());

            if (ModelState.IsValid)
            {
                // Ensure primary skill selection is valid
                var skill = await _context.Skill.FindAsync(model.PrimarySkillId);
                if (skill == null)
                {
                    ModelState.AddModelError("PrimarySkillId", "A valid primary skill is required.");
                    return View(model);
                }

                User user = _context.User
                     .Where(u => u.Email == _userManager.GetUserName(User))
                     .FirstOrDefault();

                Models.Task task = new Models.Task()
                {
                    Type = model.Type,
                    Name = model.Name,
                    Description = model.Description,
                    Postcode = model.Postcode,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    PresenceLevel = model.PresenceLevel,
                    Payment = model.Payment,
                    Owner = user
                };
                _context.Task.Add(task);

                // Create connection from task to primary skill
                _context.SkillTaskPair.Add(new SkillTaskPair()
                {
                    Task = task,
                    skill = skill
                });

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Tasks));
            }
            return View(model);
        }

        // GET: Tasks
        public IActionResult Tasks()
        {
            User user = _context.User
               .Where(u => u.AspUser.Id == _userManager.GetUserId(User))
               .Include(u => u.Tasks)
               .FirstOrDefault();

            return View(user.Tasks);
        }

        // GET: EditTask/<id>
        public IActionResult EditTask(int? ID)
        {
            if(ID == null)
            {
                return RedirectToAction(nameof(Tasks));
            }
            var task = _context.Task.Where(t => t.ID == ID).Include(t => t.Owner).FirstOrDefault();
            if(task == null)
            {
                return RedirectToAction(nameof(Tasks));
            }

            return View(CastingTaskModel(task));

        }

        // POST: EditTask/<id>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTask(int? ID, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                if (ID == null)
                {
                    return RedirectToAction(nameof(Tasks));
                }
                var _task = _context.Task.Where(t => t.ID == task.ID).FirstOrDefault();
                if (task == null)
                {
                    return RedirectToAction(nameof(Tasks));
                }

                _task.Type = task.Type;
                _task.Name = task.Name;
                _task.Description = task.Description;
                _task.Postcode = task.Postcode;
                _task.StartDate = task.StartDate;
                _task.EndDate = task.EndDate;
                _task.PresenceLevel = task.PresenceLevel;
                _task.Payment = task.Payment;

                _context.Task.Update(_task);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Tasks));
            }
         
            return View(task);
        }

        // GET: EditTaskSkills/<id>
        public async Task<IActionResult> EditTaskSkills(int? ID)
        {
            if (ID == null)
            {
                return RedirectToAction(nameof(Tasks));
            }
            var task = _context.Task.Where(t => t.ID == ID).Include(t => t.Owner).FirstOrDefault();
            if (task == null)
            {
                return RedirectToAction(nameof(Tasks));
            }

            var skillTaskPairsDb = _context.SkillTaskPair
                .Where(s => s.Task.ID == ID)
                .Include(stp => stp.skill)
                .ThenInclude(s => s.Category);
            var taskSkills = new TaskSkillsViewModel()
            {
                ID = task.ID,
                Type = task.Type,
                Name = task.Name,
                Description = task.Description,
                Postcode = task.Postcode,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                PresenceLevel = task.PresenceLevel,
                Payment = task.Payment,
                Categories = GenerateCategories(),
                Skills = GetTaskSkills(skillTaskPairsDb)
            };

            return View(taskSkills);
        }

        // POST: EditTaskSkills/<id>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTaskSkills(int? ID, TaskSkillsViewModel model)
        {
            var skillDb = await _context.Skill.FindAsync(model.SelectedSkillId);
            if (skillDb == null)
            {
                return RedirectToAction(nameof(EditTaskSkills), model.ID);
            }

            // Check if skill already associated with task.
            var skillTaskPairDb = await _context.SkillTaskPair.FirstOrDefaultAsync(stp => stp.Task.ID == ID && stp.skill.ID == model.SelectedSkillId);
            if (skillTaskPairDb != null)
            {
                var task = _context.Task.Where(t => t.ID == ID).Include(t => t.Owner).FirstOrDefault();
                if (task == null)
                {
                    return RedirectToAction(nameof(Tasks));
                }
                var skillTaskPairsDb = _context.SkillTaskPair
                    .Where(s => s.Task.ID == ID)
                    .Include(stp => stp.skill)
                    .ThenInclude(s => s.Category);
                model.ID = task.ID;
                model.Type = task.Type;
                model.Name = task.Name;
                model.Description = task.Description;
                model.Postcode = task.Postcode;
                model.StartDate = task.StartDate;
                model.EndDate = task.EndDate;
                model.PresenceLevel = task.PresenceLevel;
                model.Payment = task.Payment;
                model.Categories = GenerateCategories();
                model.Skills = GetTaskSkills(skillTaskPairsDb);
                ModelState.AddModelError("SelectedSkillId", "Selected skill already chosen.");

                return View(model);
            }

            // Add skill to User
            _context.SkillTaskPair.Add(new SkillTaskPair()
            {
                Task = await _context.Task.FindAsync(model.ID),
                skill = skillDb
            });
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EditTaskSkills), new { id = model.ID });
        }

        // GET: DeleteTaskSkill/<id>?skillID=<Skill ID>
        public async Task<IActionResult> DeleteTaskSkill(int? ID, int? skillID)
        {
            if (ID == null)
            {
                return RedirectToAction(nameof(Tasks));
            }

            if (skillID == null)
            {
                return RedirectToAction(nameof(EditTaskSkills), new { id = ID });
            }

            var skillTaskPairDb = await _context.SkillTaskPair
                .Where(s => s.Task.ID == ID && s.skill.ID == skillID)
                .FirstOrDefaultAsync();
            if (skillTaskPairDb == null)
            {
                return RedirectToAction(nameof(EditTaskSkills), new { id = ID });
            }

            _context.SkillTaskPair.Remove(skillTaskPairDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EditTaskSkills), new { id = ID });
        }

        // GET: DeleteTaskAsync/<id>
        public async Task<IActionResult> DeleteTaskAsync(int? ID)
        {
            if (ID == null)
            {
                return RedirectToAction(nameof(Tasks));
            }

            var task = _context.Task.Where(t => t.ID == ID).Include(t => t.Owner).FirstOrDefault();

            if (task == null)
            {
                return RedirectToAction(nameof(Tasks));
            }

            // Ensure all associated skills are removed.
            var skillTaskPairs = _context.SkillTaskPair.Where(stp => stp.Task.ID == ID);
            foreach(var skillTaskPair in skillTaskPairs)
            {
                _context.SkillTaskPair.Remove(skillTaskPair);
            }

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Tasks));
        }

        // GET: CompleteTask/<id>
        public async Task<IActionResult> CompleteTask(int? ID)
        {
            if (ID == null)
            {
                return RedirectToAction(nameof(Tasks));
            }

            var task = _context.Task.Where(t => t.ID == ID).FirstOrDefault();

            if (task == null)
            {
                return RedirectToAction(nameof(Tasks));
            }

            // Flag task as completed.
            task.Completed = true;

            _context.Task.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Tasks));
        }

        private ProfileViewModel CastingProfileViewModel(User user)
        {
            ProfileViewModel _userInstance = new ProfileViewModel()
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                City = user.City,
                Postcode = user.Postcode,
                State = user.State,
                Phone = user.Phone,
                PublicProfile = user.PublicProfile,
                Description = user.Description
            };

            return _userInstance;
        }

        private TaskViewModel CastingTaskModel(Models.Task task)
        {
            TaskViewModel _task = new TaskViewModel()
            {
                Type = task.Type,
                Name = task.Name,
                Description = task.Description,
                Postcode = task.Postcode,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                PresenceLevel = task.PresenceLevel,
                Payment = task.Payment,
                Complete = task.Completed,
                Owner = new ProfileViewModel()
                {
                    UserID = task.Owner.UserID,
                    Name = task.Owner.Name,
                    Address = task.Owner.Address,
                    City = task.Owner.City,
                    State = task.Owner.State,
                    Postcode = task.Owner.Postcode,
                    Phone = task.Owner.Phone,
                    Email = task.Owner.Email,
                    Description = task.Owner.Description
                }
            };

            return _task;
        }

        private List<SelectListItem> GenerateCategories()
        {
            var categoriesSelect = new List<SelectListItem>();

            // Define all available skills for selection.
            var categoriesDb = _context.Skill.Where(s => s.Category == null);
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
                    categoriesSelect.Add(new SelectListItem()
                    {
                        Value = skillDb.ID.ToString(),
                        Text = skillDb.Name,
                        Group = category
                    });
                }
            }

            return categoriesSelect.OrderBy(s => s.Group.Name).ThenBy(s => s.Text).ToList();
        }

        private IEnumerable<SkillViewModel> GetTaskSkills(IQueryable<SkillTaskPair> skillTaskPairsDb)
        {
            var skills = new List<SkillViewModel>();

            // Populate all current skills ready for display.
            foreach (var SkillTaskPairDb in skillTaskPairsDb)
            {
                skills.Add(new SkillViewModel()
                {
                    ID = SkillTaskPairDb.skill.ID,
                    Name = SkillTaskPairDb.skill.Name,
                    Description = SkillTaskPairDb.skill.Description,
                    CategoryName = SkillTaskPairDb.skill.Category.Name
                });
            }

            return skills.AsEnumerable();
        }
    }
}
