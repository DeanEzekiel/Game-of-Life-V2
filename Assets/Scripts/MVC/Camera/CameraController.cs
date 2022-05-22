using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_CameraModel;
using GameOfLife.MVC_CameraView;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class CameraController : ControllerHelper
    {
        #region MVC
        [SerializeField]
        private CameraView _view;
        [SerializeField]
        private CameraModel _model;
        #endregion

        #region Public API
        public void AdjustSize(float size)
        {
            // 1 is normal
            // 0.5 is zoomed out
            // 1.5 is zoomed in

            // BUT the camera interprets it invertly

            // deduct 1 so that normal (1) will be 0
            // 0.5 will be -0.5
            // 1.5 will be 0.5
            // multiply by -1 to invert it
            size = (size - 1) * -1;

            float cameraSize = _model.CameraSize + size;

            _view.SetCameraSize(cameraSize);
        }
        #endregion
    }
}