using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_Cell
{
    public class CellView : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.CellController _controller;
        #endregion
    }
}