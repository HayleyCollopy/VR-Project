using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [Range(1.0f, 20.0f)]
    public float shootForce = 10.0f;
    public GameObject ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
}
