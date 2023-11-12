using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform LaunchPoint;
    public Transform targetPoint;
    private void Start() {
        if(bullet == null){
            Debug.Log("Bullet is null");
            //Exit Game
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    public void Spawn(){
        bullet.transform.position = LaunchPoint.position;
        bullet.transform.rotation = LaunchPoint.rotation;
        bullet.GetComponent<TrackingMissle>().target = targetPoint;
    }
}
