using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quest;

namespace Interactable {
    [RequireComponent(typeof(SpriteRenderer))]
    public class Erasable : MonoBehaviour {
        public float Resistance = 0;
        public GameObject PrefabToSpawn;

        private SpriteRenderer sprite;

        private void Start() {
            sprite = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.TryGetComponent(out Eraser era)) {

                Color tmp = GetComponent<SpriteRenderer>().color;
                tmp.a -= era.Power * (1 - Resistance);
                if (tmp.a > 0) {
                    GetComponent<SpriteRenderer>().color = tmp;
                } else {
                    if (TryGetComponent<ProgressStall>(out ProgressStall stall)) {
                        stall.StopStalling();
                    }
                    Destroy(this.gameObject);
                }

            }
        }

        private void OnCollisionStay2D(Collision2D collision) {
            if (Random.Range(0f, 1f) < 0.01f && collision.collider.TryGetComponent(out Eraser era)) {
                Color tmp = GetComponent<SpriteRenderer>().color;
                tmp.a -= era.Power * (1 - Resistance);
                if (tmp.a > 0) {
                    GetComponent<SpriteRenderer>().color = tmp;
                } else {
                    if (TryGetComponent<ProgressStall>(out ProgressStall stall)) {
                        stall.StopStalling();
                    }
                    Destroy(this.gameObject);
                }

            }
        }
    }
}
