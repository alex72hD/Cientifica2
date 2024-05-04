using Cientifica.API.Helpers;
using Cientifica.Shared.Entities;
using Cientifica.Shared.Enums;
using System.Diagnostics.Eventing.Reader;

namespace Cientifica.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }



        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
           
            await CheckRolesAsync();
           




        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.investigadores.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }



        private async Task<Investigador> CheckUserAsync(string Nombre, string Afiliacion, string Especialidad , string email, string v)
        {
            var user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {

                user = new Investigador
                {
                    nombre =Nombre,
                    afiliacion = Afiliacion,
                    especialidad = Especialidad,
                    Email = email,
                   

                };

                await _userHelper.AdduserAsync(user, "123456");
                
            }
            return user;
        }

       
    }
}

