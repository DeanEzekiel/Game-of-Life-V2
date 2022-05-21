using System.Collections;
using System.Collections.Generic;
using GameOfLife.MVC_Controllers;
using UnityEngine;

namespace GameOfLife
{
    public class GameControllers : MonoBehaviour
    {
        public GameController Game;
        public GridController Grid;
        public CellController Cell;
        public UIController UI;
    }
}