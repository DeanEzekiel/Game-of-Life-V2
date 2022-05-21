using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_UI
{
    public class UIModel : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.UIController _controller;
        #endregion
    }
}