using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_UI;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class UIController : Controller
    {
        #region MVC
        [SerializeField]
        private UIModel _model;
        [SerializeField]
        private UIView _view;
        #endregion
    }
}