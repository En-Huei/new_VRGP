using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using BNG;

public class BattleManager : MonoBehaviour
{
    int frame = 0;

    public int GunLevel = 0;
    public int GrantedClipsCount = 5;
    public int TargetKilledCount = 5;
    public int CurrentKilledCount = 0;
    public int CumulativeKilledCount = 0;

    public UnityEvent onKillEnemy;
    public UnityEvent onShoot;
    public UnityEvent onPressBButton;
    public UnityEvent onLevelUp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frame++;

        if (CurrentKilledCount >= TargetKilledCount) {
            LevelUp();
        }
        
        if (InputBridge.Instance.BButton && frame >= 20) {
            if (onPressBButton != null) {
                onPressBButton.Invoke();
            }
            frame = 0;
        }

        if (Input.GetKeyDown(KeyCode.P) && frame >= 20) {
            if (onPressBButton != null) {
                onPressBButton.Invoke();
            }
            frame = 0;
        }
    }

    public void EnemyKilled() {
        if (onKillEnemy != null) {
            CurrentKilledCount++;
            CumulativeKilledCount++;
            onKillEnemy.Invoke();
        }
    }

    public void Shoot() {
        if (onShoot != null) {
            onShoot.Invoke();
        }
    }

    public void LevelUp() {
        if (onLevelUp != null) {
            GunLevel++;
            GrantedClipsCount = GrantedClipsCount * 2;
            TargetKilledCount = TargetKilledCount * 2;
            CurrentKilledCount = 0;
            onLevelUp.Invoke();
        }
    }
}
