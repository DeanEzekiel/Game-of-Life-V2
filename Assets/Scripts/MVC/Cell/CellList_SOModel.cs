using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameOfLife.MVC_Cell
{
    [CreateAssetMenu(fileName = "Cell List Model",
        menuName = "ScriptableObjects/New Cell List Model")]
    public class CellList_SOModel : ScriptableObject
    {
        #region Fields
        private Dictionary<Vector2, CellView> _cells
            = new Dictionary<Vector2, CellView>();

        private static readonly List<Direction> _directions =
            Enum.GetValues(typeof(Direction))
            .Cast<Direction>()
            .ToList();

        private float _dist;
        #endregion

        #region Public API
        public void Clear()
        {
            _cells.Clear();
        }

        public void AddCellForLookup(CellView cell)
        {
            if(cell == null)
            {
                return;
            }

            _cells.Add(cell.GetLocation(), cell);
        }

        public int GetLivingNeighborsCount(CellView cell)
        {
            var neighbors = GetAllNeighbors(cell);
            var livingCount = 0;

            foreach (var neighbor in neighbors)
            {
                if (neighbor.IsAlive)
                {
                    livingCount++;
                }
            }

            return livingCount;
        }

        public int GetLivingCellsCount()
        {
            var livingCount = 0;

            foreach (var cell in _cells.Values)
            {
                if (cell.IsAlive)
                {
                    livingCount++;
                }
            }

            return livingCount;
        }
        #endregion

        #region Implementation
        private List<CellView> GetAllNeighbors(CellView cell)
        {
            var neighbors = new List<CellView>();

            foreach (var direction in _directions)
            {
                var possibleNeighbor = GetPossibleNeighbor(cell, direction);
                if (possibleNeighbor != null)
                {
                    neighbors.Add(possibleNeighbor);
                }
            }

            return neighbors;
        }

        private CellView GetPossibleNeighbor(CellView cell, Direction direction)
        {
            _cells.TryGetValue(
                GetNeighborLocation(cell.GetLocation(), direction),
                out var neighbor);
            return neighbor;
        }

        private Vector2 GetNeighborLocation(Vector2 origin, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new Vector2(origin.x, origin.y + _dist);
                case Direction.East:
                    return new Vector2(origin.x + _dist, origin.y);
                case Direction.West:
                    return new Vector2(origin.x - _dist, origin.y);
                case Direction.South:
                    return new Vector2(origin.x, origin.y - _dist);
                case Direction.NorthEast:
                    return new Vector2(origin.x + _dist, origin.y + _dist);
                case Direction.NorthWest:
                    return new Vector2(origin.x - _dist, origin.y + _dist);
                case Direction.SouthEast:
                    return new Vector2(origin.x + _dist, origin.y - _dist);
                case Direction.SouthWest:
                    return new Vector2(origin.x - _dist, origin.y - _dist);
                default:
                    return Vector2.zero;
            }
        }
        #endregion
    }
}