using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    public static BulletLauncher instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject bullet;
    public Transform LaunchPoint;
    public Transform targetPoint;
    private void Start()
    {
        if (bullet == null)
        {
            Debug.Log("Bullet is null");
            //Exit Game
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    public void Spawn()
    {
        if (targetPoint != null)
        {
            Debug.Log("Spawn Bullet");
            GameObject newBullet = Instantiate(bullet, LaunchPoint.position, LaunchPoint.rotation);
            newBullet.GetComponent<TrackingMissle>().target = targetPoint;
        }
    }
}
