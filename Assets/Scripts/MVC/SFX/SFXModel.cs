using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_SFX
{
    public class SFXModel : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.SFXController _controller;
        #endregion
    }
}