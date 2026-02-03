using UnityEngine;
using StarforgeOutpost.Data;
using StarforgeOutpost.Grid;
using StarforgeOutpost.Inventory;

namespace StarforgeOutpost.Buildings
{
    public class BuildingPlacer : MonoBehaviour
    {
        [SerializeField] private GridSystem gridSystem;
        [SerializeField] private Camera mainCamera;

        public BuildingDataSO SelectedBuilding { get; private set; }

        public void SelectBuilding(BuildingDataSO buildingData)
        {
            SelectedBuilding = buildingData;
        }

        public void TryPlaceSelectedBuilding()
        {
            if (SelectedBuilding == null || gridSystem == null || mainCamera == null)
            {
                return;
            }

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                TryPlaceAtWorldPosition(hit.point, SelectedBuilding);
            }
        }

        public bool TryPlaceAtWorldPosition(Vector3 worldPosition, BuildingDataSO buildingData)
        {
            if (buildingData == null || gridSystem == null)
            {
                return false;
            }

            Vector2Int cellPosition = gridSystem.WorldToCell(worldPosition);
            if (!gridSystem.CanPlace(cellPosition, buildingData.size))
            {
                return false;
            }

            if (!InventorySystem.Instance.HasResources(buildingData.buildCosts))
            {
                return false;
            }

            InventorySystem.Instance.ConsumeResources(buildingData.buildCosts);
            Vector3 spawnPosition = gridSystem.CellToWorld(cellPosition);
            GameObject spawnedBuilding = Instantiate(buildingData.prefab, spawnPosition, Quaternion.identity);

            BuildingBase buildingBase = spawnedBuilding.GetComponent<BuildingBase>();
            if (buildingBase != null)
            {
                buildingBase.Initialize(buildingData);
            }

            gridSystem.OccupyCells(cellPosition, buildingData.size, spawnedBuilding);
            return true;
        }
    }
}
