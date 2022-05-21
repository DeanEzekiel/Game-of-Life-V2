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
    }
}