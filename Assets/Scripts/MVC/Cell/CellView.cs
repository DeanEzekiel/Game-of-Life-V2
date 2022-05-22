using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameOfLife.MVC_Cell
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CellView : MonoBehaviour, IPointerClickHandler
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.CellController _controller;
        #endregion

        #region Fields
        public bool IsAlive { get; private set; } = false;
        private bool _nextLife;

        private SpriteRenderer _spriteRenderer;
        #endregion

        #region EventSystems
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Clicked. State is {_controller.CheckGameState()}");
            if (_controller.CheckGameState() == GameState.PlotInitCells)
            {
                FlipLife();
            }
        }
        #endregion

        #region Public API
        public void Initialize(MVC_Controllers.CellController controller)
        {
            _controller = controller;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            // initially set it to dead
            SetCellDead();
        }

        public Vector2 GetLocation()
        {
            return new Vector2(transform.position.x, transform.position.y);
        }

        public void SetCellAlive()
        {
            IsAlive = true;
            _spriteRenderer.color = _controller.CellAliveColor;
        }

        public void SetCellDead()
        {
            IsAlive = false;
            _spriteRenderer.color = _controller.CellDeadColor;
        }

        public void SetNextLife(bool nextLife)
        {
            _nextLife = nextLife;
        }

        public void SetCurrentLife()
        {
            if (_nextLife)
            {
                SetCellAlive();
            }
            else
            {
                SetCellDead();
            }
        }
        #endregion

        #region Implemenation
        private void FlipLife()
        {
            if (IsAlive)
            {
                SetCellDead();
            }
            else
            {
                SetCellAlive();
            }
        }
        #endregion
    }
}