using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleStopper : MonoBehaviour
{
    public float minHeight = 2.0f;
    public float maxHeight = 5.0f;
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
        int particleCount = particleSystem.GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            float height = particles[i].position.y;
            if (height >= minHeight && height <= maxHeight)
            {
                var velocity = particles[i].velocity;
                velocity.y = 0;
                particles[i].velocity = velocity;
            }
        }

        particleSystem.SetParticles(particles, particleCount);
    }
}
