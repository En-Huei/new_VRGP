using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public GameObject explosionEffect; // Assign your particle system prefab here

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("get into the function" + other.gameObject.tag);
        Debug.Log(other.gameObject.tag == "Bullet");

        if (other.gameObject.tag == "Bullet") // Make sure your bullet has the tag "Bullet"
        {
            Debug.Log("get into the condition");
            // GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            explosionEffect.GetComponent<ParticleSystem>().Play();

            // Destroy(effect, 5f); // Adjust time as needed for the length of your particle effect

            // Optional: Add additional logic here, like destroying the target
            // Destroy(other.gameObject);
        }
    }
}
