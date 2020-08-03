using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactable;
using Managers;

[RequireComponent(typeof(SpriteRenderer))]
public class MasherBlender : KeyMasherReceiver {
    public Sprite[] Cycle;
    public int StageOnFirstCycle = 31;
    public int StageOnNthCycle = 40;
    public int N = 50;
    public GameObject PrefabToSpawn;

    private int spriteIndex = 0;
    private SpriteRenderer spriteRenderer;
    private int n = 0;

    public override void OnCompleteSequence() {
        spriteRenderer.sprite = Cycle[spriteIndex++];
        spriteIndex %= Cycle.Length;
        n++;
        if (n == 1) {
            QuestManager.Instance.UpdateStage(StageOnFirstCycle);
            Instantiate(PrefabToSpawn, transform.position, transform.rotation);
        }
        if (n >= N) {
            QuestManager.Instance.UpdateStage(StageOnNthCycle);
            Instantiate(PrefabToSpawn, transform.position, transform.rotation);
        }
    }

    public override void OnKey(float doneness) {

    }

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

    }
}
