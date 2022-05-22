using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_Game
{
    public class GameModel : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.GameController _controller;
        #endregion

        #region Fields
        private const float _tick = 1f;

        //TODO remove SerializeField when UI is done
        [SerializeField]
        [Range(0.5f, 10f)]
        [Tooltip("Higher value is faster.")]
        private float _speed = 1f;

        private float WaitTime => (_tick / _speed);

        public int GenNumber { get; private set; } = 0;
        public int ActiveCellsCount { get; private set; } = 0;
        #endregion

        #region Public API
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }


        public IEnumerator C_LoopGeneration()
        {
            GenNumber = 0;
            do
            {
                GenNumber++;
                Debug.Log($"Now on Gen #{GenNumber}");

                ActiveCellsCount = _controller.CheckLivingCellsCount();
                Debug.Log($"Alive Cells Count: {ActiveCellsCount}");

                _controller.TriggerUIGenText(GenNumber, ActiveCellsCount);

                _controller.TriggerSetCellsNextLife();
                yield return new WaitForSeconds(WaitTime);
                _controller.TriggerStartCellsNewLife();
            } while (ActiveCellsCount > 0);

            if (ActiveCellsCount == 0)
            {
                _controller.SetState(GameState.EndGeneration);
            }
        }

        public void StartGeneration()
        {
            StartCoroutine(C_LoopGeneration());
        }

        public void StopGeneration()
        {
            StopAllCoroutines();
        }
        #endregion
    }
}