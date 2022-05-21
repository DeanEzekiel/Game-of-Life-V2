using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_Grid
{
    public class GridModel : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.GridController _controller;
        #endregion
    }
}