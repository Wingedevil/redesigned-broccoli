using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    [RequireComponent(typeof(Collider2D))]
    public class BlockCollider : MonoBehaviour {
        public int[] StageEnabled;
        public float OutlineSize = 15f;

        private Collider2D enableCollider;
        private SpriteRenderer spriteRenderer;

        private void Start() {
            QuestManager.Instance.OnStageUpdate += StageUpdate;

            if (StageEnabled.Length <= 0) {
                return;
            }
            enableCollider = GetComponent<Collider2D>();
            if (TryGetComponent<SpriteRenderer>(out SpriteRenderer sr)) {
                spriteRenderer = sr;
            }
            StageUpdate(0);
        }

        public void StageUpdate(int stage) {
            foreach (int i in StageEnabled) {
                if (i == stage) {
                    enableCollider.enabled = true;
                    if (spriteRenderer != null) {
                        spriteRenderer.material.SetFloat("_OutlineSize", OutlineSize);
                    }
                    return;
                }
            }
            if (enableCollider != null) {
                enableCollider.enabled = false;
                if (spriteRenderer != null) {
                    spriteRenderer.material.SetFloat("_OutlineSize", 0f);
                }
            }
        }
    }
}