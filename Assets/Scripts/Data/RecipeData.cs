using Recipes.Menu;
using Scripts.Reservoirs;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "RecipeData", menuName = "Data/Recipes")]
    public class RecipeData : ScriptableObject
    {
        public Recipe[] Recipes;
    }

    [System.Serializable]
    public struct Recipe
    {
        public Scripts.Reservoirs.Interactables.Size Size;
        public string Name;
        public string[] Ingridients;
        public ReservoirType ReservoirType;
        public int StagesCount => Ingridients.Length;
    }
}