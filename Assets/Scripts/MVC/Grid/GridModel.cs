using System;
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
        [Range(2, 16)]
        private int _gridRows = 10;
        [SerializeField]
        [Range(2, 16)]
        private int _gridCols = 10;
        [SerializeField]
        [Range(0.3f, 1.2f)]
        private float _size = 1;
        #endregion

        #region Accessors
        public int GridRows => _gridRows;
        public int GridCols => _gridCols;
        public float Size => _size;
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
            float minRow = (_gridRows / 2) * _size * -1;
            float maxRow = (_gridRows / 2) * _size;
            float minCol = (_gridCols / 2) * _size * -1;
            float maxCol = (_gridCols / 2) * _size;

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

            Debug.Log($"Row Min {minRow} and Row Max {maxRow}");
            Debug.Log($"Col Min {minCol} and Col Max {maxCol}");

            float tempRow = minRow;
            while ((float)Math.Round(tempRow,2) <= maxRow)
            {
                float tempCol = minCol;
                while ((float)Math.Round(tempCol, 2) <= maxCol)
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