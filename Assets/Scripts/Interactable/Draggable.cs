using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Interactable {
    [RequireComponent(typeof(Collider2D))]
    public class Draggable : MonoBehaviour {
        public string Key;

        private void OnMouseDrag() {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            curPosition.z = 0;
            transform.position = curPosition;
        }
        private void OnMouseUp() {
            DragSnapTo finalPoint = null;
            foreach (DragSnapTo point in InteractableManager.Instance.AnchorPoints) {
                if (this.Key != point.Key) {
                    continue;
                }
                float nearest = point.DistToSnap; 
                if (Vector3.Distance(point.AnchorPoint.position, transform.position) <= nearest) {
                    finalPoint = point;
                    nearest = Vector3.Distance(point.AnchorPoint.position, transform.position);
                }
            }
            transform.position = finalPoint.AnchorPoint.position;
            finalPoint.Snapped(this.gameObject);
        }
    }
}
