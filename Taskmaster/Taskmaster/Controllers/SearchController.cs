using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskmaster.Data;
using Taskmaster.Shared;
using Taskmaster.ViewModels;

namespace Taskmaster.Controllers
{
    public class SearchController : Controller
    {
        private readonly TaskmasterContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SearchController(TaskmasterContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        // GET: Search
        public IActionResult Index()
        {
            var viewModel = new SearchViewModel() 
            { 
                Term = "", 
                Profiles = 0, 
                Tasks = 0, 
                Categories = GenerateCategories()
            };

            return View(viewModel);
        }

        // GET: Search/Results
        public IActionResult Results(string term, string postCode, string _presenceLevel,
            DateTime? startDate, DateTime? endtDate, string _taskType, int? _category)
        {
            var viewModel = new SearchViewModel()
            {
                Term = term,
                Profiles = 0,
                Tasks = 0,
                Categories = GenerateCategories()
            };

            var results = new List<SearchResultViewModel>();
            term = term == null ? string.Empty : term.ToLower();
            

            //checking whether postcode has been selected in advance search or not AND CONVER INT TO STRING TO CHECK
            // WITH PROFILE POSTCODE WHICH IS STRING IN OUR CASE
            string _postCode = postCode == null ? string.Empty : postCode.ToString();

            // Search through all public profiles.
            foreach (var profile in _context.User.Where(u => u.PublicProfile).Include(u => u.Skills).ThenInclude(sup => sup.Skill).ThenInclude(s => s.Category))
            {
                // Default valid result to false.
                var valid = false;

                // Check appropriate fields for search term.
                if (profile.Name.ToLower().Contains(term) ||
                    (profile.City != null && profile.City.ToLower().Contains(term)) ||
                    (profile.State != null && profile.State.ToLower().Contains(term)) ||
                    (profile.Postcode != null && profile.Postcode.ToLower().Contains(term)))
                {
                    valid = true;
                }

                //if any match has been found and if user input any post code in advance search then checking
                //any match with postcode.
                if (valid && !string.IsNullOrEmpty(_postCode))
                {
                    valid = false;
                    if (profile.Postcode != null && profile.Postcode.ToLower() == _postCode.ToLower()) valid = true;
                }

                // If any associated skills belong to the chosen category, count as a valid result
                if(_category != null)
                {
                    valid = false;
                    foreach(var skill in profile.Skills)
                    {
                        if(skill.Skill.Category.ID == _category)
                        {
                            valid = true;
                        }
                    }
                }
                
                // If final result is valid, ad to results list.
                if (valid)
                {
                    results.Add(new SearchResultViewModel()
                    {
                        Id = profile.UserID,
                        Type = ResultType.Profile,
                        Title = profile.Name,
                        Email = profile.Email,
                        ImagePath = "~/images/admin/user.png",
                        Description = string.IsNullOrEmpty(profile.Description) ? $"Hi there! My name is {profile.Name} and I am looking forward to working with you, so contact me through my profile!" : profile.Description,
                        Price = ""
                    });
                    viewModel.Profiles++;
                }
            }

            // Search through all tasks.
            foreach (var task in _context.Task.Where(t => !t.Completed).Include(t => t.Owner).Include(t => t.Skills).ThenInclude(stp => stp.skill).ThenInclude(s => s.Category))
            {
                // Default valid result to false.
                var valid = false;

                // Check appropriate fields for search term.
                if (task.Name.ToLower().Contains(term) ||
                    task.Description.ToLower().Contains(term))
                {
                    valid = true;
                }

                //check presence level of task with user input in advance sreach 
                if (valid && !string.IsNullOrEmpty(_presenceLevel))
                {
                    valid = false;
                    if(task.PresenceLevel.ToString() == _presenceLevel)
                    {
                        valid = true;
                    }
                }
                if(valid && !string.IsNullOrEmpty(_taskType))
                {
                    valid = false;
                    if (task.Type.ToString() == _taskType)
                    {
                        valid = true;
                    }
                }
                //check for any task that has start date after stardate that user input in advance search.
                if(valid && task.StartDate !=null && startDate != null){
                    valid = false;
                    if (DateTime.Compare((DateTime)startDate,(DateTime)task.StartDate) < 0)
                    {
                        valid = true;
                    }
                }

                if (valid && task.EndDate != null && endtDate != null)
                {
                    valid = false;
                    if (DateTime.Compare((DateTime)task.EndDate,(DateTime)endtDate) < 0)
                    {
                        valid = true;
                    }
                }

                // If any associated skills belong to the chosen category, count as a valid result
                if (_category != null)
                {
                    valid = false;
                    foreach (var skill in task.Skills)
                    {
                        if (skill.skill.Category.ID == _category)
                        {
                            valid = true;
                        }
                    }
                }

                // If final result is valid, ad to results list.
                if (valid)
                {
                    results.Add(new SearchResultViewModel()
                    {
                        Id = task.ID,
                        Type = task.Type == TaskType.Bounty ? ResultType.Bounty : (task.Type == TaskType.Tender ? ResultType.Tender : ResultType.Fixed),
                        Title = task.Name,
                        Email = task.Owner.Email,
                        ImagePath = "~/images/results/fixed.png",
                        Description = task.Description,
                        Price = $"${task.Payment}"
                    });
                    viewModel.Tasks++;
                }
            }

            viewModel.Results = results.AsEnumerable();

            return View(viewModel);
        }

        // GET: Search/Task/<id>
        public IActionResult Task(int id)
        {
            var task = _context.Task.Where(t => t.ID == id).Include(t => t.Owner).FirstOrDefault();

            if (task == null)
            {
                return RedirectToPage("~/");
            }

            var viewModel = new TaskViewModel()
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

            // Add skills collection to viewModel.
            var categories = new List<CategoryViewModel>();
            var skillTaskPairs = _context.SkillTaskPair.Where(stp => stp.Task.ID == id).Include(stp => stp.skill).ThenInclude(s => s.Category);
            foreach (var skillTaskPair in skillTaskPairs)
            {
                var found = false;
                foreach(var category in categories)
                {
                    // Category already create, add skill to category.
                    if(category.ID == skillTaskPair.skill.Category.ID)
                    {
                        var tempSkills = category.Skills.ToList();
                        tempSkills.Add(new SkillViewModel()
                        {
                            ID = skillTaskPair.skill.ID,
                            Name = skillTaskPair.skill.Name,
                            Description = skillTaskPair.skill.Description,
                            CategoryName = skillTaskPair.skill.Category.Name
                        });
                        category.Skills = tempSkills.AsEnumerable();
                        found = true;
                    }
                }

                // Category doesn't exist, create and add skill to new category.
                if(!found)
                {
                    categories.Add(new CategoryViewModel()
                    {
                        ID = skillTaskPair.skill.Category.ID,
                        Name = skillTaskPair.skill.Category.Name,
                        Description = skillTaskPair.skill.Category.Description,
                        Skills = new List<SkillViewModel>() 
                        { 
                            new SkillViewModel()
                            {
                                ID = skillTaskPair.skill.ID,
                                Name = skillTaskPair.skill.Name,
                                Description = skillTaskPair.skill.Description,
                                CategoryName = skillTaskPair.skill.Category.Name
                            }
                        }.AsEnumerable()
                    });
                }
            }
            viewModel.Categories = categories.AsEnumerable();

            // TODO: Add attachmment collection to viewModel.

            return View(viewModel);
        }

        // GET: Search/Profile/<id>
        public IActionResult Profile(int id)
        {
            var profile = _context.User.Where(u => u.UserID == id).Include(u => u.ProfilePicture).Include(u => u.Skills).FirstOrDefault();

            if (profile == null)
            {
                return RedirectToPage("~/");
            }

            var viewModel = new ProfileViewModel()
            {
                UserID = profile.UserID,
                Name = profile.Name,
                Address = profile.Address,
                City = profile.City,
                State = profile.State,
                Postcode = profile.Postcode,
                Phone = profile.Phone,
                Email = profile.Email,
                Description = profile.Description
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
            viewModel.Categories = categories.AsEnumerable();

            return View(viewModel);
        }

        private IEnumerable<KeyValuePair<string, int>> GenerateCategories()
        {
            var categories = new Dictionary<string, int>();
            var categoriesDb = _context.Skill.Where(s => s.Category == null);

            foreach(var categoryDb in categoriesDb)
            {
                categories.Add(categoryDb.Name, categoryDb.ID);
            }

            return categories.AsEnumerable();
        }
    }
}
