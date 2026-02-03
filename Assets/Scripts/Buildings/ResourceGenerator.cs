using UnityEngine;
using StarforgeOutpost.Data;
using StarforgeOutpost.Inventory;

namespace StarforgeOutpost.Buildings
{
    public class ResourceGenerator : BuildingBase
    {
        private float timer;

        private void Update()
        {
            BuildingDataSO data = BuildingData;
            if (data == null || !data.generatesResources)
            {
                return;
            }

            timer += Time.deltaTime;
            if (timer >= data.generationInterval)
            {
                timer = 0f;
                InventorySystem.Instance.AddResource(data.generatedResource.item, data.generatedResource.amount);
            }
        }
    }
}
