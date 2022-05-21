using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_Game
{
    public class GameView : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.GameController _controller;
        #endregion
    }
}