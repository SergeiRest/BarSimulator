using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Ingredients", menuName = "Data/Ingredients")]
    public class IngredientsData : ScriptableObject
    {
        [field:SerializeField] public Ingredient[] Ingredients { get; private set; }
    }

    [System.Serializable]
    public struct Ingredient
    {
        public string Name;
        public Color FillColor;
    }
}