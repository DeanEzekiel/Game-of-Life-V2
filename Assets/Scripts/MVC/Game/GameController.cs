using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_Game;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class GameController : Controller
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
            return Controllers.Cell.GetLivingCellsCount();
        }

        public void TriggerSetCellsNextLife()
        {
            Controllers.Cell.SetCellsNextLife();
        }

        public void TriggerStartCellsNewLife()
        {
            Controllers.Cell.StartCellsNewLife();
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
        private void StartGeneration()
        {
            StartCoroutine(_model.C_LoopGeneration());
        }

        private void StopGeneration()
        {
            _model.StopAllCoroutines();
        }
        #endregion
    }
}