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
                StartCoroutine(Reset(ac, ac.length));
                return true;
            }
        }

        public bool CanPlaySoundWithDelay(AudioClip ac, float time) {
            if (playingClips.Contains(ac)) {
                return false;
            } else {
                playingClips.Add(ac);
                StartCoroutine(Reset(ac, time));
                return true;
            }
        }

        IEnumerator Reset(AudioClip ac, float time) {
            yield return new WaitForSeconds(time);
            playingClips.Remove(ac);
        }
    }
}