
using System.Diagnostics.Eventing.Reader;
using Recipe_API.Models;
using Recipe_API.Repository.Interfaces;

namespace Recipe_API.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private int _nextId;
        
        private List<Recipe> _recipes = new();

        public RecipeRepository(bool includeData = true)
        {
            if (includeData)
            {
                Add(new Recipe(
                "Classic Margherita Pizza",
                "https://example.com/images/margherita.jpg",
                "Simple and fresh",
                4.7,
                "Pizza dough, tomato sauce, fresh mozzarella, fresh basil, olive oil, salt",
                "Stretch dough, spread sauce, add mozzarella, bake at high heat until golden, finish with basil and olive oil.",
                "Dinner"));

                Add(new Recipe(
                "Spaghetti Carbonara",
                "https://example.com/images/carbonara.jpg",
                "Creamy, peppery, comforting",
                4.8,
                "Spaghetti, eggs, Pecorino Romano, guanciale (or pancetta), black pepper, salt",
                "Cook pasta. Fry guanciale until crisp. Whisk eggs and cheese, combine quickly off-heat with pasta and fat, season with pepper.",
                "Dinner"));

                Add(new Recipe(
                "Chicken Tikka Masala",
                "https://example.com/images/tikka_masala.jpg",
                "Spiced and creamy",
                4.6,
                "Chicken, yogurt, tomatoes, cream, garam masala, garlic, ginger, cumin, coriander, turmeric",
                "Marinate chicken, grill or broil, simmer in spiced tomato-cream sauce until cooked through. Serve with rice or naan.",
                "Dinner"));

                Add(new Recipe(
                "Avocado Toast with Poached Egg",
                "https://example.com/images/avocado_toast.jpg",
                "Bright and nutritious",
                4.3,
                "Bread, ripe avocado, lemon, chili flakes, eggs, salt, pepper",
                "Toast bread, mash avocado with lemon and salt, spread on toast, top with poached egg and chili flakes.",
                "Breakfast"));

                Add(new Recipe(
                "Beef Stir-Fry with Vegetables",
                "https://example.com/images/beef_stirfry.jpg",
                "Fast weeknight favorite",
                4.5,
                "Beef strips, soy sauce, garlic, ginger, broccoli, bell pepper, sesame oil, cornstarch",
                "Marinate beef briefly, stir-fry on high heat with vegetables, finish with sauce thickened with cornstarch.",
                "Dinner"));

                Add(new Recipe(
                "Lemon Garlic Roasted Salmon",
                "https://example.com/images/roasted_salmon.jpg",
                "Lemony and flaky",
                4.7,
                "Salmon fillets, lemon, garlic, olive oil, dill, salt, pepper",
                "Season salmon, roast at 200°C/400°F for 12-15 minutes until just cooked, garnish with lemon and dill.",
                "Dinner"));

                Add(new Recipe(
                "Chocolate Chip Cookies",
                "https://example.com/images/cookies.jpg",
                "Classic chewy cookies",
                4.9,
                "Butter, sugar, brown sugar, eggs, vanilla, flour, baking soda, salt, chocolate chips",
                "Cream butter and sugars, add eggs and vanilla, fold in dry ingredients and chocolate chips, bake until edges set.",
                "Dessert"));

                Add(new Recipe(
                "Quinoa Salad with Roasted Vegetables",
                "https://example.com/images/quinoa_salad.jpg",
                "Nutty and colorful",
                4.2,
                "Quinoa, zucchini, cherry tomatoes, red onion, feta, olive oil, lemon, herbs",
                "Roast vegetables, cook quinoa, toss together with dressing and feta.",
                "Lunch"));
            }
        }

        public IEnumerable<Recipe> GetAll(string? tag = null)
        {
            if(tag != null)
            {
                return _recipes.FindAll(r => tag == r.Tags);
            }
            return _recipes;
        }

        public Recipe Add(Recipe recipe)
        {
            recipe.Id = _nextId++;

            _recipes.Add(recipe);
            return recipe;
        }

        public Recipe GetById(int id)
        {
            Recipe recipe = _recipes.First(r => r.Id == id);

            return recipe;
        }

        public Recipe Edit(int id, Recipe data)
        {
            Recipe recipe = GetById(id);

            recipe.Name = data.Name;
            recipe.ImageURL = data.ImageURL;
            recipe.DescriptionGrade = data.DescriptionGrade;
            recipe.Grade = data.Grade;
            recipe.Ingredients = data.Ingredients;
            recipe.Instructions = data.Instructions;
            recipe.Tags = data.Tags;

            return recipe;
        }

        public Recipe Delete(int id)
        {
            Recipe recipe = GetById(id);

            _recipes.Remove(recipe);

            return recipe;
        }
    }
}
