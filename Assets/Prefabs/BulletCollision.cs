using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    void OnTriggerEnter2D(Collider2D col)
    {
        
        Player.IsFired = false;

        if (col.tag == "Ball")
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            col.GetComponent<Ball>().Split();
        }
    }
}
