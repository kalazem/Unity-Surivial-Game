using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitTrigger : MonoBehaviour
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

        if (col.gameObject.CompareTag("Mutant"))
        {
            Debug.Log("it is mutant");
        }
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("it is Player");
        }
    }
}
