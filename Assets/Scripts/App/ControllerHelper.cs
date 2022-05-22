using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife
{
    public class ControllerHelper : MonoBehaviour
    {
        // This will be inherited by Controller Classes
        // Acts as a helper so calling the Controllers would be shorter

        protected GameControllers Controller => GameMain.Instance.Controllers;
    }
}