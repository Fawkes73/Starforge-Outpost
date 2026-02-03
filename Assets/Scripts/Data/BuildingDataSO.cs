using System.Collections.Generic;
using UnityEngine;

namespace StarforgeOutpost.Data
{
    [CreateAssetMenu(menuName = "Starforge Outpost/Building Data", fileName = "NewBuildingData")]
    public class BuildingDataSO : ScriptableObject
    {
        public string buildingId;
        public string displayName;
        public GameObject prefab;
        public Vector2Int size = Vector2Int.one;
        public List<ResourceAmount> buildCosts = new List<ResourceAmount>();

        [Header("Resource Generation")]
        public bool generatesResources;
        public ResourceAmount generatedResource;
        public float generationInterval = 5f;

        [Header("Crafting")]
        public bool isCraftingStation;
        public List<RecipeDataSO> availableRecipes = new List<RecipeDataSO>();
    }
}
