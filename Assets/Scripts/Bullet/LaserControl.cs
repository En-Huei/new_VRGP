using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        CloseLaser();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLaser() {
        laser.SetActive(true);
    }

    public void CloseLaser() {
        laser.SetActive(false);
    }
}
