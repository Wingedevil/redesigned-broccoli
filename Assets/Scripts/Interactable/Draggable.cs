using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Interactable {
    [RequireComponent(typeof(Collider2D))]
    public class Draggable : MonoBehaviour {
        public string Key;

        private void OnMouseDown() {
            if (TryGetComponent<RotateOnDrag>(out RotateOnDrag rotate)) {
                rotate.Rotate();
            }
        }
        private void OnMouseDrag() {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            curPosition.z = 0;
            transform.position = curPosition;
        }
        private void OnMouseUp() {
            SnapToNearest();
            GrabFromNearest();

            if (TryGetComponent<RotateOnDrag>(out RotateOnDrag rotate)) {
                rotate.Unrotate();
            }
        }
        private void OnDestroy() {
            if (TryGetComponent<SpriteRenderer>(out SpriteRenderer sr)) {
                sr.material.SetFloat("_OutlineSize", 0f);
            }
        }

        private void SnapToNearest() {
            DragSnapTo toSnap = null;
            float nearestSnap = float.PositiveInfinity;

            foreach (DragSnapTo point in InteractableManager.Instance.AnchorPoints) {
                if (this.Key != point.Key) {
                    continue;
                }
                float dist = Vector3.Distance(point.AnchorPoint.position, transform.position);
                if (dist <= point.DistToSnap && dist <= nearestSnap) {
                    toSnap = point;
                    nearestSnap = dist;
                }
            }
            if (toSnap != null) {
                transform.parent = toSnap.AnchorPoint;
                transform.localPosition = Vector3.zero;
                toSnap.Snapped(this.gameObject);
            }
        }

        private void GrabFromNearest() {
            Grabbable toGrab = null;
            float nearestGrab = float.PositiveInfinity;
            
            foreach (Grabbable point in InteractableManager.Instance.GrabPoints)
            {
                if (this.Key != point.Key) {
                    continue;
                }
                float dist = Vector3.Distance(point.transform.position, transform.position);
                if (dist <= point.DistToGrab && dist <= nearestGrab) {
                    toGrab = point;
                    nearestGrab = dist;
                }
            }
            if (toGrab != null) {
                toGrab.transform.parent = toGrab.SnapPoint;
                toGrab.transform.localPosition = Vector3.zero;
                toGrab.Grabbed(this.gameObject);
            }
        }
    }
}
