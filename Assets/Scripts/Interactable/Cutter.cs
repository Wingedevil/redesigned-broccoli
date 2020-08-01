using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable {
    public class Cutter : MonoBehaviour {
        public float Resistance = 0;

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
                    Destroy(this.gameObject);
                }

            }
        }
    }
}
