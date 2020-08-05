using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    public class PlayOnErase : MonoBehaviour {
        public AudioClip clip;
        public void Play() {
            var go = new GameObject();
            var sauce = go.AddComponent<AudioSource>();
            sauce.clip = clip;
            sauce.Play();
        }
    }
}