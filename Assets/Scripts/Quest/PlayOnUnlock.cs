using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest {
    [RequireComponent(typeof(AudioSource))]
    public class PlayOnUnlock : MonoBehaviour {
        public AudioClip clip;

        private AudioSource sauce;

        private void Start() {
            sauce = GetComponent<AudioSource>();
        }

        public void Play() {
            sauce.clip = clip;
            sauce.Play();
        }
    }
}