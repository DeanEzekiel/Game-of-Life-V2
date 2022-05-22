using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameOfLife.MVC_UIView
{
    public class UIView : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.UIController _controller;
        #endregion

        #region UI Elements
        [Header("Panels")]
        [SerializeField]
        private GameObject _pnlMainMenu;
        [SerializeField]
        private GameObject _pnlGridSetup;
        [SerializeField]
        private GameObject _pnlPlotInit;
        [SerializeField]
        private GameObject _pnlGeneration;
        [SerializeField]
        private GameObject _pnlGenPlay;
        [SerializeField]
        private GameObject _pnlGenEnd;

        [Header("Main Menu Elements")]
        [SerializeField]
        private Button _btnGridSetup;
        [SerializeField]
        private Button _btnExit;

        [Header("Grid Setup Elements")]
        [SerializeField]
        private Slider _sldRow;
        [SerializeField]
        private Slider _sldColumn;
        [SerializeField]
        private Slider _sldSize;

        [Space]
        [SerializeField]
        private TextMeshProUGUI _txtRow;
        [SerializeField]
        private TextMeshProUGUI _txtColumn;
        [SerializeField]
        private TextMeshProUGUI _txtSize;

        [Space]
        [SerializeField]
        private TMP_Dropdown _ddColor;
        [SerializeField]
        private Image _imgColor;

        [Space]
        [SerializeField]
        private Button _btnPlotCells;

        [Header("Plot Cells Elements")]
        [SerializeField]
        private Button _btnPlay;
        [SerializeField]
        private Button _btnBackToSetup;

        [Header("Generation Info")]
        [SerializeField]
        private TextMeshProUGUI _txtCurrentGen;
        [SerializeField]
        private TextMeshProUGUI _txtActiveCells;

        [Header("State Playing Elements")]
        [SerializeField]
        private Slider _sldSpeed;
        [SerializeField]
        private TextMeshProUGUI _txtSpeed;
        [SerializeField]
        private Button _btnStop;

        [Header("State Ended Elemeents")]
        [SerializeField]
        private Button _btnGridSetup2;
        [SerializeField]
        private Button _btnExit2;
        #endregion

        #region Accessors
        public int ColValue => (int)_sldColumn.value;
        public int RowValue => (int)_sldRow.value;
        public float SizeValue => (float)Math.Round(_sldSize.value, 1);
        public float SpeedValue => (float)Math.Round(_sldSpeed.value, 1);
        #endregion

        #region Public API
        public void ShowMainMenu()
        {
            HidePanelsExcept(_pnlMainMenu);
        }
        public void ShowGridSetup()
        {
            HidePanelsExcept(_pnlGridSetup);
        }
        public void ShowPlotCells()
        {
            HidePanelsExcept(_pnlPlotInit);
        }
        public void ShowStatePlaying()
        {
            HidePanelsExcept(_pnlGeneration);
            _pnlGenPlay.SetActive(true);
            _pnlGenEnd.SetActive(false);
        }
        public void ShowStateEnded()
        {
            HidePanelsExcept(_pnlGeneration);
            _pnlGenPlay.SetActive(false);
            _pnlGenEnd.SetActive(true);
        }

        public void SetGenerationText(string gen, string cells)
        {
            _txtCurrentGen.text = gen;
            _txtActiveCells.text = cells;
        }
        #endregion

        #region Implementation
        private void HidePanelsExcept(GameObject panel)
        {
            _pnlMainMenu.SetActive(false);
            _pnlGridSetup.SetActive(false);
            _pnlPlotInit.SetActive(false);
            _pnlGeneration.SetActive(false);

            panel.SetActive(true);
        }

        private void DDSetColor()
        {
            var value = _ddColor.options[_ddColor.value].text;
            Color color = _controller.TriggerColorChange(value);

            _imgColor.color = color;
        }

        private void SliderColChanged(float value)
        {
            _txtColumn.text = value.ToString();
            _controller.TriggerUpdateGrid();
        }
        private void SliderRowChanged(float value)
        {
            _txtRow.text = value.ToString();
            _controller.TriggerUpdateGrid();
        }
        private void SliderSizeChanged(float value)
        {
            _txtSize.text = value.ToString("F1");
            //_controller.TriggerUpdateGrid();
            _controller.TriggerUpdateCamSize();
        }
        private void SliderSpeedChanged(float value)
        {
            _txtSpeed.text = value.ToString("F1");
            _controller.TriggerUpdateGenSpeed();
        }
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            ShowMainMenu();
            DDSetColor();

            _btnBackToSetup.onClick.AddListener(_controller.OnClickGridSetup);
            _btnExit.onClick.AddListener(_controller.OnClickExitGame);
            _btnExit2.onClick.AddListener(_controller.OnClickExitGame);
            _btnGridSetup.onClick.AddListener(_controller.OnClickGridSetup);
            _btnGridSetup2.onClick.AddListener(_controller.OnClickGridSetup);
            _btnPlay.onClick.AddListener(_controller.OnClickPlay);
            _btnPlotCells.onClick.AddListener(_controller.OnClickPlotCells);
            _btnStop.onClick.AddListener(_controller.OnClickStop);

            _sldColumn.onValueChanged.AddListener(delegate {
                SliderColChanged(_sldColumn.value);
            });
            _sldRow.onValueChanged.AddListener(delegate {
                SliderRowChanged(_sldRow.value);
            });
            _sldSize.onValueChanged.AddListener(delegate {
                SliderSizeChanged(_sldSize.value);
            });
            _sldSpeed.onValueChanged.AddListener(delegate {
                SliderSpeedChanged(_sldSpeed.value);
            });

            _ddColor.onValueChanged.AddListener(delegate {
                DDSetColor();
            });
        }
        #endregion
    }
}