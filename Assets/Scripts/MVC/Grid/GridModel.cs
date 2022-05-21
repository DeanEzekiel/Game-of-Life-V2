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

        #region Fields
        //TODO remove SerializeField when UI is done
        [SerializeField]
        [Range(5, 25)]
        private int _gridRows = 10;
        [SerializeField]
        [Range(5, 25)]
        private int _gridCols = 10;

        private float _size = 1;
        #endregion

        #region Public API
        public void SetupGrid(int rows, int cols, float size)
        {
            _gridRows = rows;
            _gridCols = cols;
            _size = size;
            ConfigureGrid();
        }
        #endregion

        #region Implementation
        private void ConfigureGrid()
        {
            float minRow = (_gridRows / 2) * -1;
            float maxRow = (_gridRows / 2);
            float minCol = (_gridCols / 2) * -1;
            float maxCol = (_gridCols / 2);

            // if rows and cols are divisible by 2,
            // adjust the min and max by half
            if (_gridRows %2 == 0)
            {
                minRow += _size / 2;
                maxRow -= _size / 2;
            }
            if (_gridCols % 2 == 0)
            {
                minCol += _size / 2;
                maxCol -= _size / 2;
            }

            float tempRow = minRow;
            float tempCol = minCol;
            while (tempRow <= maxRow)
            {
                while (tempCol <= maxCol)
                {
                    Vector2 position = new Vector2(tempRow, tempCol);
                    // spawn cell on position based on row and col
                    _controller.TriggerSpawnCell(position);

                    tempCol += _size;
                }
                tempRow += _size;
            }
        }
        #endregion
    }
}