using System.Collections.Generic;
using UnityEngine;
using StarforgeOutpost.Buildings;
using StarforgeOutpost.Data;

namespace StarforgeOutpost.UI
{
    public class CraftingUI : MonoBehaviour
    {
        [SerializeField] private CraftingStation craftingStation;
        [SerializeField] private List<Color> presetColors = new List<Color>();

        private RecipeDataSO selectedRecipe;
        private Color selectedColor = Color.white;

        public void SetCraftingStation(CraftingStation station)
        {
            craftingStation = station;
        }

        public void SelectRecipe(int index)
        {
            if (craftingStation == null || index < 0 || index >= craftingStation.AvailableRecipes.Count)
            {
                return;
            }

            selectedRecipe = craftingStation.AvailableRecipes[index];
        }

        public void SelectPresetColor(int index)
        {
            if (index < 0 || index >= presetColors.Count)
            {
                return;
            }

            selectedColor = presetColors[index];
        }

        public void CraftSelectedRecipe()
        {
            if (craftingStation == null || selectedRecipe == null)
            {
                return;
            }

            craftingStation.CraftRecipe(selectedRecipe, selectedColor);
        }
    }
}
