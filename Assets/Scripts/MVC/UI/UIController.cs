using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_UI;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class UIController : Controller
    {
        #region MVC
        [SerializeField]
        private UIModel _model;
        [SerializeField]
        private UIView _view;
        #endregion

        #region UI Public API
        public void TriggerGridSetupState()
        {
            Controllers.Game.SetState(GameState.GridSetup);
            TriggerUpdateGrid();

            _view.ShowGridSetup();
        }
        public void TriggerUpdateGrid()
        {
            Controllers.Grid.SetupGrid
                (_view.RowValue, _view.ColValue, _view.SizeValue);
        }
        public void TriggerExitGame()
        {
            Controllers.Game.Quit();
        }
        public void TriggerPlotCells()
        {
            Controllers.Game.SetState(GameState.PlotInitCells);
            _view.ShowPlotCells();
        }
        public void TriggerPlay()
        {
            Controllers.Game.SetState(GameState.PlayGeneration);
            _view.ShowStatePlaying();
        }
        public void TriggerStop()
        {
            Controllers.Game.SetState(GameState.EndGeneration);
            ShowStateEnded();
        }
        public void TriggerUpdateGenSpeed()
        {
            Controllers.Game.SetSpeed(_view.SpeedValue);
        }
        public Color TriggerColorChange(string value)
        {
            Color color;
            if (value == ColorOption.RED)
            {
                color = Color.red;
            }
            else if (value == ColorOption.YELLOW)
            {
                color = Color.yellow;
            }
            else if (value == ColorOption.BLUE)
            {
                color = Color.blue;
            }
            else
            {
                color = Color.red;
            }

            Controllers.Cell.SetCellSpecs(color);
            return color;
        }
        // Game Controller can access this to show the end
        // when it reaches 0 active cells
        public void ShowStateEnded()
        {
            _view.ShowStateEnded();
        }

        public void SetGenerationText(string gen, string cells)
        {
            _view.SetGenerationText(gen, cells);
        }
        #endregion
    }
}