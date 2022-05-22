using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_SFXModel;
using GameOfLife.MVC_SFXView;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class SFXController : ControllerHelper
    {
        #region MVC
        [SerializeField]
        private SFXModel _model;
        [SerializeField]
        private SFXView _view;
        #endregion

        #region Public API
        public void PlayButtonClick()
        {
            _view.PlayClip(_model.AudioButton);
        }
        public void PlayCellClick()
        {
            _view.PlayClip(_model.AudioClickCell);
        }
        public void PlayNextGen()
        {
            _view.PlayClip(_model.AudioNextGen);
        }
        #endregion
    }
}