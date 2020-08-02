using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtils;

namespace Managers {
    public class SoundManager : Manager<SoundManager> {
        private HashSet<AudioClip> playingClips = new HashSet<AudioClip>();

        public bool CanPlaySoundNoOverlap(AudioClip ac) {
            if (playingClips.Contains(ac)) {
                return false;
            } else {
                playingClips.Add(ac);
                StartCoroutine(Reset(ac));
                return true;
            }
        }

        IEnumerator Reset(AudioClip ac) {
            yield return new WaitForSeconds(ac.length);
            playingClips.Remove(ac);
        }
    }
}