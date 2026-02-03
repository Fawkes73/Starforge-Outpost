using UnityEngine;
using StarforgeOutpost.Data;

namespace StarforgeOutpost.Buildings
{
    public abstract class BuildingBase : MonoBehaviour
    {
        [SerializeField] private BuildingDataSO buildingData;
        public BuildingDataSO BuildingData => buildingData;

        public virtual void Initialize(BuildingDataSO data)
        {
            buildingData = data;
        }
    }
}
