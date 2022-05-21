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
    }
}