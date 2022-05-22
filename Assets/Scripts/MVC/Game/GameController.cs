using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_Game;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class GameController : ControllerHelper
    {
        #region MVC
        [SerializeField]
        private GameModel _model;
        [SerializeField]
        private GameView _view;
        #endregion

        #region Fields
        public GameState State { get; private set; } = GameState.Start;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            State = GameState.Start;
        }
        #endregion

        #region Public API
        public void SetSpeed(float speed)
        {
            _model.SetSpeed(speed);
        }
        public void SetState(GameState state)
        {
            State = state;

            if (State == GameState.PlayGeneration)
            {
                StartGeneration();
            }
            else if (State == GameState.EndGeneration)
            {
                StopGeneration();
                // TODO Activate UI Options to
                // Start from Grid Setup || Plot Cells || Quit Game Of Life
            }
        }

        public int CheckLivingCellsCount()
        {
            return Controller.Cell.GetLivingCellsCount();
        }

        public void TriggerSetCellsNextLife()
        {
            Controller.Cell.SetCellsNextLife();
        }

        public void TriggerStartCellsNewLife()
        {
            Controller.Cell.StartCellsNewLife();
        }

        public void TriggerUIGenText(int gen, int cells)
        {
            Controller.UI.SetGenerationText(gen.ToString(), cells.ToString());
            TriggerNextGenSFX();
        }

        public void Quit()
        {
            //End Game
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
#else
            Application.Quit();
#endif
        }

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Resume()
        {
            Time.timeScale = 1;
        }

        #endregion

        #region Implementation
        [ContextMenu("Play Generation")]
        private void StartGeneration()
        {
            _model.StartGeneration();
        }

        [ContextMenu("Stop Generation")]
        private void StopGenState()
        {
            SetState(GameState.EndGeneration);
        }

        private void StopGeneration()
        {
            _model.StopGeneration();
            Controller.UI.ShowStateEnded();
        }
        #endregion

        #region Sound Implementation
        private void TriggerNextGenSFX()
        {
            Controller.SFX.PlayNextGen();
        }
        #endregion
    }
}