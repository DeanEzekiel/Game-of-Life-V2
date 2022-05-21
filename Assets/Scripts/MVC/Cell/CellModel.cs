using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_Cell
{
    public class CellModel : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.CellController _controller;

        [SerializeField]
        private CellList_SOModel _cellList;
        #endregion
    }
}