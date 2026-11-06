namespace Recipe_API.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string DescriptionGrade { get; set; }

        public double Grade { get; set; }

        public string Ingredients { get; set; }

        public string Instructions { get; set; }

        public string Tags { get; set; }

        public Recipe(string name, string imageURL, string descriptionGrade, double grade, string ingredients, string instructions, string tags)
        {
            Name = name;
            ImageURL = imageURL;
            DescriptionGrade = descriptionGrade;
            Grade = grade;
            Ingredients = ingredients;
            Instructions = instructions;
            Tags = tags;
        }
    }
}
