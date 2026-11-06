using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Recipe_API.Models;
using Recipe_API.Repositories;
using Recipe_API.Repository.Interfaces;

namespace Recipe_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController
    {
        private IRecipeRepository _repo;

        public RecipeController(IRecipeRepository repo )
        {
            _repo = repo;
        }

        [EnableCors("AllowAll")]
        [HttpGet]
        public IEnumerable<Recipe> GetRecipes([FromQuery]string? tag = null)
        {
            return _repo.GetAll(tag);
        }

        [EnableCors("AllowAll")]
        [HttpGet("{id}")]
        public Recipe GetRecipeById(int id)
        {
            return _repo.GetById(id);
        }

        [EnableCors("MyWebsite")]
        [HttpPost]
        public Recipe AddRecipe([FromBody] Recipe recipe)
        {
            return _repo.Add(recipe);
        }

        [EnableCors("MyWebsite")]
        [HttpPut("{id}")]
        public Recipe UpdateRecipe([FromBody] Recipe data, int id)
        {
            return _repo.Edit(id, data);
        }

        [EnableCors("MyWebsite")]
        [HttpDelete("{id}")]
        public Recipe DeleteRecipe(int id)
        {
            return _repo.Delete(id);
        }
    }
}
