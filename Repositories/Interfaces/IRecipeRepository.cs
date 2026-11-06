using Recipe_API.Models;

namespace Recipe_API.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        Recipe Add(Recipe recipe);
        Recipe Delete(int id);
        Recipe Edit(int id, Recipe data);
        IEnumerable<Recipe> GetAll(string? tag);
        Recipe GetById(int id);
    }
}