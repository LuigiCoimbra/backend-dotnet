using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Error = (sender, args) =>
                {
                    args.ErrorContext.Handled = true;
                },
            };

            using (var context = new desafioContext())
            {
                var myEntity = context.Users.ToList();
                return JsonConvert.SerializeObject(myEntity, settings);
            }
        }

        [HttpPost]
        public string Post(User user)
        {
            using (var context = new desafioContext())
            {
                var UserEntity = new User()
                {
                    Username = user.Username,
                    Fullname = user.Fullname,
                    Date = user.Date,
                    Active = user.Active,
                    Country = user.Country,
                    Role = user.Role
                };
                var myEntity = context.Users.Add(UserEntity);
                context.SaveChanges();
                return "true";
            }
        }

        [HttpPatch]
        public void Patch(User user)
        {
            using (var context = new desafioContext())
            {
                User UserEntity = context.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                context.Entry(UserEntity).CurrentValues.SetValues(user);

                context.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            using (var context = new desafioContext())
            {
                User UserEntity = context.Users.Where(u => u.Id == id).FirstOrDefault();
                context.Remove(UserEntity);

                context.SaveChanges();
            }
        }
    }
}