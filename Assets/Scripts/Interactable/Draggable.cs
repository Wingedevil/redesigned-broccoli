using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Interactable {
    [RequireComponent(typeof(Collider2D))]
    public class Draggable : MonoBehaviour {
        private void OnMouseDrag() {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            curPosition.z = 0;
            transform.position = curPosition;
        }
        private void OnMouseUp() {
            foreach (DragSnapTo point in InteractableManager.Instance.AnchorPoints) {
                if (Vector3.Distance(point.AnchorPoint.position, transform.position) <= point.DistToSnap) {
                    transform.position = point.AnchorPoint.position;
                    point.Snapped(this.gameObject);
                    break;
                }
            }
        }
    }
}
