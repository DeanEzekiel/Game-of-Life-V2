using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_Cell;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class CellController : Controller
    {
        #region MVC
        [SerializeField]
        private CellModel _model;
        [SerializeField]
        private CellView _view;
        #endregion
    }
}