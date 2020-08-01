using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    public class QuestStagnate : MonoBehaviour {
        private void Start() {
            QuestManager.Instance.Stagnate(1);
        }

        private void OnDestroy() {
            QuestManager.Instance.Stagnate(-1);
        }
    }
}