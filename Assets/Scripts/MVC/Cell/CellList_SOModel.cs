using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.MVC_CellView;
using UnityEngine;

namespace GameOfLife.MVC_CellModelView
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

        private float _dist = 1;
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

        public void SetCellsNextLife()
        {
            foreach (var cell in _cells.Values)
            {
                var livingNeighborsCount = GetLivingNeighborsCount(cell);

                if (cell.IsAlive &&
                    (livingNeighborsCount < 2 || livingNeighborsCount > 3))
                {
                    // Any live cell with fewer than two live neighbours dies
                    // Any live cell with more than three live neighbours dies
                    cell.SetNextLife(!cell.IsAlive);
                }
                else if (!cell.IsAlive && livingNeighborsCount == 3)
                {
                    // Any dead cell with exactly three live neighbours
                    // becomes a live cell
                    cell.SetNextLife(!cell.IsAlive);
                }
                else
                {
                    // Any live cell with two or three live neighbours
                    // lives on to the next generation.
                    // (or can be interpreted as all else retains their status
                    // as the ones that FLIP status has already been covered.)
                    cell.SetNextLife(cell.IsAlive);
                }
            }
        }

        public void StartCellsNewLife()
        {
            foreach (var cell in _cells.Values)
            {
                cell.SetCurrentLife();
            }
        }

        public void SetDistance(float distance)
        {
            _dist = distance;
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