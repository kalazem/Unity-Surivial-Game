using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        //For ray casting
        //Transform.forward --> length ahead of the ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       // Debug.DrawRay(ray, transform.forward * 20);
        if(Physics.Raycast (ray, out hit, 10))
        {
          //  Debug.Log(hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "PlayerDoor")
            {
                Debug.Log("We are facing the door");
            }
        }
        
    }

     void OnControllerColliderHit(ControllerColliderHit hit)
    {
         //for simple collider detection 
        if (hit.gameObject.tag == "PlayerDoor")
        {
            Debug.Log("Walked into the door");
        }
    }
}
