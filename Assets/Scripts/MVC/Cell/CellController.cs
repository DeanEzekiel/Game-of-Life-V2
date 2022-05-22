using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_CellModel;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class CellController : ControllerHelper
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
        [ContextMenu("Plot Init Cells")]
        public void PlotCells()
        {
            Controller.Game.SetState(GameState.PlotInitCells);
        }

        public void SetCellSpecs(float cellSize)
        {
            var cellSize2D = new Vector2(cellSize, cellSize);
            _model.SaveCellSpecs(cellSize2D);
            _model.CellList.SetDistance(cellSize);
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
            return Controller.Game.State;
        }

        public void SetCellsNextLife()
        {
            _model.CellList.SetCellsNextLife();
        }

        public void StartCellsNewLife()
        {
            _model.CellList.StartCellsNewLife();
        }

        public void TriggerCellClickSFX()
        {
            Controller.SFX.PlayCellClick();
        }
        #endregion
    }
}