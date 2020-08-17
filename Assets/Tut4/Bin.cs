using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Player")
            {
                Destroy(col.gameObject);
                Debug.Log("You Collected 1 Rubbish");
            }
        }
}
