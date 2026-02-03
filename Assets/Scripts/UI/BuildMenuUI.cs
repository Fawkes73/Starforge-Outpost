using System.Collections.Generic;
using UnityEngine;
using StarforgeOutpost.Buildings;
using StarforgeOutpost.Data;

namespace StarforgeOutpost.UI
{
    public class BuildMenuUI : MonoBehaviour
    {
        [SerializeField] private BuildingPlacer buildingPlacer;
        [SerializeField] private List<BuildingDataSO> availableBuildings = new List<BuildingDataSO>();

        public IReadOnlyList<BuildingDataSO> AvailableBuildings => availableBuildings;

        public void SelectBuilding(int index)
        {
            if (buildingPlacer == null || index < 0 || index >= availableBuildings.Count)
            {
                return;
            }

            buildingPlacer.SelectBuilding(availableBuildings[index]);
        }
    }
}
