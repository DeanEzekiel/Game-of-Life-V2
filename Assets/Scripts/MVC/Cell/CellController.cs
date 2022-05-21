using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_Cell;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class CellController : Controller
    {
        #region MVC
        [SerializeField]
        private CellModel _model;
        #endregion

        #region Accessors
        public Color CellAliveColor => _model.ColorAlive;
        public Color CellDeadColor => _model.ColorDead;
        public Vector2 CellSize => _model.CellSize;
        #endregion

        #region Public API
        public void SetCellSpecs(float cellSize)
        {
            var cellSize2D = new Vector2(cellSize, cellSize);
            _model.SaveCellSpecs(cellSize2D);
        }

        public void SetCellSpecs(Color color)
        {
            _model.SaveCellSpecs(color);
        }

        public void ClearCellList()
        {
            _model.ClearCells();
        }

        public void SpawnCellOnPos(Vector2 position)
        {
            _model.SpawnCell(position);
        }

        public int GetLivingCellsCount()
        {
            return _model.CellList.GetLivingCellsCount();
        }

        public GameState CheckGameState()
        {
            return Controllers.Game.State;
        }

        public void SetCellsNextLife()
        {

        }

        public void SetCellsCurrentLife()
        {

        }
        #endregion
    }
}