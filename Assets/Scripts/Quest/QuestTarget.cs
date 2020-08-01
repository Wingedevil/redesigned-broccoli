using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest {
    public class QuestTarget : MonoBehaviour {
        public float KeyExpected;
        public int StageOnComplete;
        public bool Unlocked = false;
        public GameObject PrefabToSpawn;
    }
}