using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_GridView
{
    public class GridView : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.GridController _controller;
        #endregion
    }
}