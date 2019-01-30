using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerf_Machine_Gun : MonoBehaviour
{
    public AudioClip NerfMachineGun;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void run()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(Resources.Load<AudioClip>("audio/Nerf_Machine_Gun"));
    }
}
