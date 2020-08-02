using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest {
    public class ProgressLock : MonoBehaviour {
        public float KeyExpected;
        public int[] RequiredStage;
        public int StageOnComplete;
        public bool Unlocked = false;
        public GameObject PrefabToSpawn;
    }
}