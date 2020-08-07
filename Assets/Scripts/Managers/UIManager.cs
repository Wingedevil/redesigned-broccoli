using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtils;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class UIManager : Manager<UIManager> {
        public string SceneToLoad;

        public void OnStart() {
            Debug.Log("Game Started");

            SceneManager.LoadScene(SceneToLoad);
        }

        public void OnRecipe() {
            Debug.Log("Recipe Opened");
            Application.OpenURL("https://www.nyonyacooking.com/recipes/singapore-style-chilli-crab~Bk6QdvoPf9Z7");
        }       

        public void OnExit() {
            Debug.Log("Game Stopped");
            Application.Quit();
        }   

        
    }
}