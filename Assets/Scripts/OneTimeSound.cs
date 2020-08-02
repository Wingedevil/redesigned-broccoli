using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

[RequireComponent(typeof(AudioSource))]
public class OneTimeSound : MonoBehaviour {
    public AudioClip ClipToBePlayed;

    // Start is called before the first frame update
    void Start() {
        AudioSource sauce = GetComponent<AudioSource>();
        sauce.clip = ClipToBePlayed;
        sauce.volume = SoundManager.Instance.CanPlaySoundNoOverlap(ClipToBePlayed) ? 1 : 0;
    }

    // Update is called once per frame
    void Update() {

    }
}
