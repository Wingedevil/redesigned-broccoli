using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtils;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class AudioManager : Manager<AudioManager> {
        private void Start() {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}