using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Quest;

namespace Interactable {
    [RequireComponent(typeof(Collider2D))]
    public class Clickable : MonoBehaviour {
        private void OnMouseDown() {
            if (TryGetComponent<RotateOnClick>(out RotateOnClick rotate)) {
                rotate.Rotate();
            }
            if (TryGetComponent<RevealOnClick>(out RevealOnClick reveal))
            {
                reveal.Reveal();
            }
            Clicked();
        }
        private void OnDestroy() {
            if (TryGetComponent<SpriteRenderer>(out SpriteRenderer sr)) {
                sr.material.SetFloat("_OutlineSize", 0f);
            }
        }

        private void Clicked() {
            if (TryGetComponent<ProgressLock>(out ProgressLock target)) {
                if (TryGetComponent<ProgressKey>(out ProgressKey key)) {
                    key.Unlock(target);
                }
            } else if (TryGetComponent<ProgressKey>(out ProgressKey key)) {
                if (TryGetComponent<ProgressLock>(out ProgressLock tar)) {
                    key.Unlock(tar);
                }
            }
        }
    }
}
