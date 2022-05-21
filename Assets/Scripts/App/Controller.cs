using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife
{
    public class Controller : MonoBehaviour
    {
        // This will be inherited by Controller Classes
        // Acts as a helper so calling the Controllers would be shorter

        protected GameControllers Controllers => GameMain.Instance.Controllers;
    }
}