using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_Game
{
    public class GameModel : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.GameController _controller;
        #endregion

        #region Fields
        private const float _tick = 1f;

        //TODO remove SerializeField when UI is done
        [SerializeField]
        [Range(0.5f, 10f)]
        [Tooltip("Higher value is faster.")]
        private float _speed = 1f;

        private float _waitTime => (_tick / _speed);
        #endregion

        #region Implementation
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
        #endregion
    }
}