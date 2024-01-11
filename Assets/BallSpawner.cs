using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BallSpawn", 2, 6);
    }

  private void BallSpawn() {

        Instantiate(Ball, transform.position, transform.rotation);
    }  
}
