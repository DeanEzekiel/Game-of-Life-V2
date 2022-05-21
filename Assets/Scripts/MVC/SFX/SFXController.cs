using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_SFX;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class SFXController : Controller
    {
        #region MVC
        [SerializeField]
        private SFXModel _model;
        [SerializeField]
        private SFXView _view;
        #endregion
    }
}