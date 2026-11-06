using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Recipe_API.Models;
using Recipe_API.Repository.Interfaces;

namespace Recipe_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [EnableCors("AllowAll")]
        [HttpGet]
        public IEnumerable<User> GetRecipes()
        {
            return _repo.GetAll();
        }

        [EnableCors("AllowAll")]
        [HttpGet("{id}")]
        public User GetRecipeById(int id)
        {
            return _repo.GetById(id);
        }

        [HttpPost]
        public User AddRecipe([FromBody] User user)
        {
            return _repo.Add(user);
        }

        [HttpPut("{id}")]
        public User UpdateRecipe([FromBody] User data, int id)
        {
            return _repo.Edit(id, data);
        }

        [HttpDelete("{id}")]
        public User DeleteRecipe(int id)
        {
            return _repo.Delete(id);
        }
    }
}
