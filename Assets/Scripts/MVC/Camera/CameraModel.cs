using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_Camera
{
    public class CameraModel : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.CameraController _controller;
        #endregion

        #region Fields
        [SerializeField]
        private float _cameraSize = 9f;
        #endregion

        #region Accessors
        public float CameraSize => _cameraSize;
        #endregion
    }
}