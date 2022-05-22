using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.MVC_SFXView
{
    [RequireComponent(typeof(AudioSource))]
    public class SFXView : MonoBehaviour
    {
        #region MVC
        [SerializeField]
        private MVC_Controllers.SFXController _controller;
        #endregion

        #region Fields
        private AudioSource _audioSource;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        #endregion

        #region Public API
        public void PlayClip(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
        #endregion
    }
}