namespace Ingredients
{
    public class IngredientSelector
    {
        private Ingredient _selectedIngredient;

        public Ingredient SelectedIngredient => _selectedIngredient;
        
        public bool IsEmpty => _selectedIngredient == null;

        public void Select(Ingredient ingredient)
        {
            _selectedIngredient = ingredient;
        }

        public void Deselect()
        {
            _selectedIngredient = null;
        }
    }
}