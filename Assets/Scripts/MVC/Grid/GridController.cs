using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_Grid;
using UnityEngine;

namespace GameOfLife.MVC_Controllers
{
    public class GridController : Controller
    {
        #region MVC
        [SerializeField]
        private GridModel _model;
        [SerializeField]
        private GridView _view;
        #endregion
    }
}