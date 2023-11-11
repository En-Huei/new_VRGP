using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform projectileOrigin; // Starting point of the projectile
    public Vector3 projectileDirection; // Direction of the projectile
    public float projectileRange = 25.0f; // Range of the projectile

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(projectileOrigin.position, projectileDirection, out hit, projectileRange))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Hit by the projectile!");
                // Handle the hit here
            }
        }
    }

}
