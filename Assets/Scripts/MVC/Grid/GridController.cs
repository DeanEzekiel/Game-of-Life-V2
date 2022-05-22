using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_Grid;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class GridController : ControllerHelper
    {
        #region MVC
        [SerializeField]
        private GridModel _model;
        [SerializeField]
        private GridView _view;
        #endregion

        #region Public API
        [ContextMenu("Setup Grid")]
        public void MenuSetupGrid()
        {
            Controller.Game.SetState(GameState.GridSetup);
            SetupGrid(_model.GridRows, _model.GridCols, _model.Size);
        }

        public void SetupGrid(int rows, int cols, float size)
        {
            if (Controller.Game.State == GameState.GridSetup)
            {
                // refresh the Cell Controller's cells list first
                Controller.Cell.ClearCellList();
                Controller.Cell.SetCellSpecs(size);

                _model.SetupGrid(rows, cols, size);
            }
        }

        public void TriggerSpawnCell(Vector2 position)
        {
            Controller.Cell.SpawnCellOnPos(position);
        }
        #endregion
    }
}