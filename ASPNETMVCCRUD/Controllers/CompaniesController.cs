using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASPNETMVCCRUD.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        // Constructor injection - MVCDemoDbContext is injected into the controller
        public CompaniesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        // GET: /Companies
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Retrieve all companies from the database
                var companies = await mvcDemoDbContext.Companies.ToListAsync();
                return View(companies);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                throw;
            }
        }

        // GET: /Companies/Add
        [HttpGet]
        public IActionResult Add()
        {
            try
            {
                return View();// Render the "Add" view to display the form for adding a new company
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                throw;
            }
        }

        // POST: /Companies/Add
        [HttpPost]
        public async Task<IActionResult> Add(AddCompanyViewModel addCompanyRequest)
        {
            try
            {
                // Create a new Company object using the data provided in the addCompanyRequest
                var company = new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = addCompanyRequest.Name,
                    Address = addCompanyRequest.Address,
                    ContactInfo = addCompanyRequest.ContactInfo,
                    NoOfEmployees = addCompanyRequest.NoOfEmployees
                };

                // Add the new company to the database
                await mvcDemoDbContext.Companies.AddAsync(company);
                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index"); // Redirect to the "Index" action after successfully adding the company
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                throw;
            }
        }

        // GET: /Companies/View/{id}
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            try
            {
                // Find the company with the specified id in the database
                var company = await mvcDemoDbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);

                if (company != null)
                {
                    // Create an UpdateCompanyViewModel object and populate it with the company data
                    var viewModel = new UpdateCompanyViewModel()
                    {
                        Id = company.Id,
                        Name = company.Name,
                        Address = company.Address,
                        ContactInfo = company.ContactInfo,
                        NoOfEmployees = company.NoOfEmployees,
                    };

                    // Render the "View" view with the company data
                    return await Task.Run(() => View("View", viewModel));
                }
                // If the company is not found, redirect to the "Index" action
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                throw;
            }
        }

        // POST: /Companies/View
        [HttpPost]
        public async Task<IActionResult> View(UpdateCompanyViewModel model)
        {
            try
            {
                // Find the company with the specified model.Id in the database
                var company = await mvcDemoDbContext.Companies.FindAsync(model.Id);

                if (company != null)
                {
                    // Update the company's properties with the values from the model
                    company.Name = model.Name;
                    company.Address = model.Address;
                    company.ContactInfo = model.ContactInfo;
                    company.NoOfEmployees = model.NoOfEmployees;

                    await mvcDemoDbContext.SaveChangesAsync(); // Save the changes to the database

                    return RedirectToAction("Index"); // Redirect to the "Index" action after successfully updating the company
                }

                return RedirectToAction("Index"); // If the company is not found, redirect to the "Index" action
            }
            catch (Exception ex) 
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                throw;
            }
            
        }

        // POST: /Companies/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateCompanyViewModel model)
        {
            try
            {
                // Find the company with the specified model.Id in the database
                var company = await mvcDemoDbContext.Companies.FindAsync(model.Id);

                if (company != null)
                {
                    mvcDemoDbContext.Companies.Remove(company); // Remove the company from the database
                    await mvcDemoDbContext.SaveChangesAsync(); // Save the changes to the database

                    return RedirectToAction("Index"); // Redirect to the "Index" action after successfully deleting the company
                }
                return RedirectToAction("Index"); // If the company is not found, redirect to the "Index" action
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                throw;
            }

        }
    }
}
