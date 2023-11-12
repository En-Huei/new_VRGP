using UnityEngine;
using UnityEngine.VFX;

public class ParticleHeightController : MonoBehaviour
{
    public VisualEffect visualEffect;
    public float minHeight = 1.0f; // Default minimum height
    public float maxHeight = 5.0f; // Default maximum height

    void Update()
    {
        // Update the minHeight and maxHeight parameters in the VFX Graph
        visualEffect.SetFloat("MinHeight", minHeight);
        visualEffect.SetFloat("MaxHeight", maxHeight);
    }
}
