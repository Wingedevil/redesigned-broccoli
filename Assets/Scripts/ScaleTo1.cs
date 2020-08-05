using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactable;
using Managers;

public class ScaleTo1 : MonoBehaviour {
    public int StageOnComplete;
    public float ScaleMult;
    private void Update() {
        transform.localScale *= ScaleMult;
        if (transform.localScale.x - 1 <= float.Epsilon) {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Invoke("HelpMe", 0.2f);
        }
    }

    private void HelpMe() {
        CancelInvoke();
        QuestManager.Instance.UpdateStage(StageOnComplete);
    }
}
