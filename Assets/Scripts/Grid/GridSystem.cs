using System.Collections.Generic;
using UnityEngine;

namespace StarforgeOutpost.Grid
{
    public class GridSystem : MonoBehaviour
    {
        [SerializeField] private int width = 10;
        [SerializeField] private int height = 10;
        [SerializeField] private float cellSize = 2f;
        [SerializeField] private Vector3 origin = Vector3.zero;

        private readonly Dictionary<Vector2Int, GameObject> occupiedCells = new Dictionary<Vector2Int, GameObject>();

        public int Width => width;
        public int Height => height;
        public float CellSize => cellSize;

        public Vector2Int WorldToCell(Vector3 worldPosition)
        {
            int x = Mathf.FloorToInt((worldPosition.x - origin.x) / cellSize);
            int y = Mathf.FloorToInt((worldPosition.z - origin.z) / cellSize);
            return new Vector2Int(x, y);
        }

        public Vector3 CellToWorld(Vector2Int cellPosition)
        {
            float x = origin.x + cellPosition.x * cellSize + cellSize * 0.5f;
            float z = origin.z + cellPosition.y * cellSize + cellSize * 0.5f;
            return new Vector3(x, origin.y, z);
        }

        public bool IsWithinBounds(Vector2Int cellPosition)
        {
            return cellPosition.x >= 0 && cellPosition.y >= 0 && cellPosition.x < width && cellPosition.y < height;
        }

        public bool IsCellOccupied(Vector2Int cellPosition)
        {
            return occupiedCells.ContainsKey(cellPosition);
        }

        public bool CanPlace(Vector2Int cellPosition, Vector2Int size)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector2Int checkCell = new Vector2Int(cellPosition.x + x, cellPosition.y + y);
                    if (!IsWithinBounds(checkCell) || IsCellOccupied(checkCell))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void OccupyCells(Vector2Int cellPosition, Vector2Int size, GameObject occupant)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector2Int checkCell = new Vector2Int(cellPosition.x + x, cellPosition.y + y);
                    occupiedCells[checkCell] = occupant;
                }
            }
        }
    }
}
