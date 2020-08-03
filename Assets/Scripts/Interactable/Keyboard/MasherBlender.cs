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
    public AudioClip[] clips;

    private int spriteIndex = 0;
    private AudioSource sauce;
    private SpriteRenderer spriteRenderer;
    private int n = 0;
    private bool pressed = false;
    private int phase = 0; // 0-mute, 1-start, 2-mid, 3-end

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sauce = GetComponent<AudioSource>();
    }

    private void Next() {
        if (pressed) {
            pressed = false;
            switch (phase) {
                case 0:
                case 3:
                    phase = 1;
                    break;
                case 1:
                case 2:
                    phase = 2;
                    break;
            }
        } else {
            switch (phase) {
                case 0:
                case 3:
                    phase = 0;
                    break;
                case 1:
                case 2:
                    phase = 3;
                    break;
            }
        }
        if (phase != 0) {
            sauce.clip = clips[phase];
            sauce.Play();
            Invoke("Next", clips[phase].length);
        }
    }

    public override void OnCompleteSequence() {
        spriteRenderer.sprite = Cycle[spriteIndex++];
        spriteIndex %= Cycle.Length;
        pressed = true;
        if (phase == 0) {
            Next();
        }
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
}
