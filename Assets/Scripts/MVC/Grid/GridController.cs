using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_Grid;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class GridController : Controller
    {
        #region MVC
        [SerializeField]
        private GridModel _model;
        [SerializeField]
        private GridView _view;
        #endregion

        #region Public API
        public void SetupGrid(int rows, int cols, float size)
        {
            if (Controllers.Game.State == GameState.GridSetup)
            {
                // refresh the Cell Controller's cells list first
                Controllers.Cell.ClearCellList();
                Controllers.Cell.SetCellSpecs(size);

                _model.SetupGrid(rows, cols, size);
            }
        }

        public void TriggerSpawnCell(Vector2 position)
        {
            Controllers.Cell.SpawnCellOnPos(position);
        }
        #endregion
    }
}