using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
using Zenject;

namespace Ingredients
{
    public class IngredientsContainer
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();

        private string _saveKey = "SavedIngredients";

        [Inject]
        private void Construct(IngredientsData _data)
        {
            if (PlayerPrefs.HasKey(_saveKey))
            {
                string key = PlayerPrefs.GetString(_saveKey);
                _ingredients = ListWrapper.FromJson<Ingredient>(key);
            }
            else
            {
                for (int i = 0; i < _data.Ingredients.Length; i++)
                {
                    Ingredient ingredient = new Ingredient()
                    {
                        Color = _data.Ingredients[i].FillColor,
                        Count = 100,
                        Name = _data.Ingredients[i].Name
                    };
                    _ingredients.Add(ingredient);
                }

                string json = ListWrapper.ToJson(_ingredients);
                PlayerPrefs.SetString(_saveKey, json);
            }
        }

        public Ingredient Get(string name)
        {
            return _ingredients.First(ingredient => ingredient.Name == name);
        }
    }


    public static class ListWrapper
    {
        public static string ToJson<T>(List<T> list)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = list;
            Debug.Log(wrapper.Items[0]);
            return JsonUtility.ToJson(wrapper);
        }

        public static List<T> FromJson<T>(string value)
        {
            var wrapper = JsonUtility.FromJson<Wrapper<T>>(value);
            return wrapper.Items;
        }
    }
    
    [Serializable]
    public class Wrapper<T>
    {
        public List<T> Items;
    }
}