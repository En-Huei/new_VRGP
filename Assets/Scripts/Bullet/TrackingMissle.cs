using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMissle : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;
    public float epsilon = 0.001f;

    void Update()
    {
        if (target != null)
        {
            float sqrMagnitude = Vector3.SqrMagnitude(transform.position - target.position);
            if (sqrMagnitude > epsilon)
            {
                float step = speed * Time.deltaTime;

                // Calculate new position and rotation
                Vector3 direction = (target.position - transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(direction);

                // Update position and rotation
                transform.position = Vector3.Lerp(transform.position, target.position, step);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
            }
            else{
                // Arrived
                Destroy(this.gameObject);
            }
        }
    }
}
