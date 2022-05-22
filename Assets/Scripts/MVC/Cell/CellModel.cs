using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_Cell
{
    public class CellModel : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.CellController _controller;

        [SerializeField]
        public CellList_SOModel CellList;

        [SerializeField]
        private Transform _cellsParent;
        [SerializeField]
        private CellView _cellViewPrefab;
        #endregion

        #region Fields
        //TODO remove SerializeField when UI is done
        [SerializeField]
        private Vector2 _cellSize = new Vector2(1, 1);
        public Vector2 CellSize => _cellSize;

        // color alive can be modified
        public Color ColorAlive { get; private set; } = Color.red;
        public Color ColorDead { get; private set; } = Color.white;
        #endregion

        #region Public API
        public void SaveCellSpecs(Color color)
        {
            ColorAlive = color;
        }

        public void SaveCellSpecs(Vector2 cellSize)
        {
            _cellSize = cellSize;
        }

        public void ClearCells()
        {
            CellList.Clear();

            var childCount = _cellsParent.childCount;
            if (childCount == 0)
            {
                return;
            }

            for (int x = childCount - 1; x >= 0; x--)
            {
                DestroyImmediate(_cellsParent.GetChild(x).gameObject);
            }
        }

        public void SpawnCell(Vector2 position)
        {
            var cell = Instantiate(_cellViewPrefab, _cellsParent);
            cell.gameObject.name = $"Cell ({position.x}, {position.y})";
            cell.transform.position = position;
            cell.transform.localScale = _cellSize;

            cell.Initialize(_controller);

            CellList.AddCellForLookup(cell);
        }

        #endregion
    }
}