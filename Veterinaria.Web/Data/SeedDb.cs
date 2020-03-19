using System;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Web.Data.Entities;
using Veterinaria.Web.Helppers;

namespace Veterinaria.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext context, 
            IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("1010", "carlos", "marin", "carlos827@yahoo.com", "643774426", "Calle", "Admin");
            var customer = await CheckUserAsync("2020", "carlos", "marin", "carlos827@hotmail.com", "643774426", "Calle", "Customer");

            await CheckPetTypesAsync();
            await CheckServiceTypesAsync();
            await CheckOwnersAsync(customer);
            await CheckManagerAsync(manager);
            await CheckPetsAsync();
            await CheckAgendasAsync();
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
        }
        private async Task<User> CheckUserAsync(
            string document
            , string firstName
            , string lastName
            , string email
            , string Phone
            , string Address
            , string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = Phone,
                    Address = Address,
                    Document = document
                };
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }
            return user;
        }
        private async Task CheckPetTypesAsync()
        {
            if (!_dataContext.PetTypes.Any())
            {
                _dataContext.PetTypes.Add(new PetType { Name = "Perro" });
                _dataContext.PetTypes.Add(new PetType { Name = "Geto" });
                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckServiceTypesAsync()
        {
            if (!_dataContext.ServiceTypes.Any())
            {
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Consulta" });
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Urgencia" });
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Vacunación" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPetsAsync()
        {
            var owner = _dataContext.Owners.FirstOrDefault();
            var petType = _dataContext.PetTypes.FirstOrDefault();
            if (!_dataContext.Pets.Any())
            {
                AddPet("Otto", owner, petType, "Shih tzu");
                AddPet("Killer", owner, petType, "Dobermann");
                await _dataContext.SaveChangesAsync();
            }
        }



        private async Task CheckOwnersAsync(User user)
        {
            if (!_dataContext.Owners.Any())
            {
                _dataContext.Owners.Add(new Owner { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        //private void AddOwner(string document, string firstName, string lastName, string fixedPhone, string cellPhone, string address)
        //{
        //    _dataContext.Owners.Add(new Owner
        //    {
        //        Address = address,
        //        CellPhone = cellPhone,
        //        Document = document,
        //        FirstName = firstName,
        //        FixedPhone = fixedPhone,
        //        LastName = lastName
        //    });
        //}

        private async Task CheckManagerAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddPet(string name, Owner owner, PetType petType, string race)
        {
            _dataContext.Pets.Add(new Pet
            {
                Born = DateTime.Now.AddYears(-2),
                Name = name,
                Owner = owner,
                PetType = petType,
                Race = race
            });
        }

        private async Task CheckAgendasAsync()
        {
            if (!_dataContext.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                var finalDate = initialDate.AddYears(1);
                while (initialDate < finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate < finalDate2)
                        {
                            _dataContext.Agendas.Add(new Agenda
                            {
                                Date = initialDate.ToUniversalTime(),
                                IsAvailable = true
                            });

                            initialDate = initialDate.AddMinutes(30);
                        }

                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                }

                await _dataContext.SaveChangesAsync();
            }
        }
    }
}


