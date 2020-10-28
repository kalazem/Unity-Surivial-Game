using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10);
        if(Physics.Raycast (transform.position, transform.forward, out hit, 10))
        {
            if(hit.collider.gameObject.tag == "PlayerDoor")
            {
                Debug.Log("We are facing the door");
            }
        }
        
    }

     void OnControllerColliderHit(ControllerColliderHit hit)
    {
 
        if (hit.gameObject.tag == "PlayerDoor")
        {
            Debug.Log("Walked into the door");
        }
    }
}
