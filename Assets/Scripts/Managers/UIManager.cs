using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtils;

namespace Managers
{
    public class UIManager : Manager<UIManager> {
        public GameObject RecipeWindow;
        public GameObject CreditsWindow;

        private void Start() {
            RecipeWindow.SetActive(false);
            CreditsWindow.SetActive(false);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                RecipeWindow.SetActive(false);
                CreditsWindow.SetActive(false);
            }
        }

        public void OnStart() {
            Debug.Log("Game Started");

            // If we have a scene manager, switch scenes here
        }

        public void OnRecipe() {
            Debug.Log("Recipe Opened");
            RecipeWindow.SetActive(true);
        }

        public void OnCredits() {
            Debug.Log("Credits Opened");
            CreditsWindow.SetActive(true);
        }

        public void OnExit() {
            Debug.Log("Game Stopped");
            Application.Quit();
        }
    }
}