using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_Camera
{
    public class CameraView : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.CameraController _controller;
        #endregion

        #region Fields
        [SerializeField]
        private new Camera camera;
        #endregion

        #region Public API
        public void SetCameraSize(float size)
        {
            camera.orthographicSize = size;
        }
        #endregion
    }
}