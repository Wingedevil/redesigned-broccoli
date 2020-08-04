using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable {
    public class RevealOnClick : MonoBehaviour {
        public GameObject ShowOnClick;

        public void Start() {
            ShowOnClick.SetActive(false);
        }
        public void Reveal() {
            ShowOnClick.SetActive(true);
        }
    }
}