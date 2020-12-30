using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TriggerZone : MonoBehaviour
{
    public AudioClip lockedSound;
    public Light doorLight;
    public Text textHints;


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
       // if (col.gameObject.tag == "Player")
       if(Inventory.charge == 4)
        {
            transform.Find("door").SendMessage("DoorCheck");
            if (GameObject.Find("chargeUI"))
            {
                Destroy(GameObject.Find("chargeUI"));
                doorLight.color = Color.green;
                //doorLight.color = Color.green;
            }
            
        }
        else if (Inventory.charge > 0 && Inventory.charge < 4)
        {
            textHints.SendMessage("ShowHint",
            "This door won’t budge.. guess it needs fully charging - maybe more power cells will help...");

            transform.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
        }

        else
        {
            transform.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
            col.gameObject.SendMessage("HUDon");
            /*textHints.SendMessage("ShowHint", "This door seems locked.. maybe that generator needs power...");*/

        }
    }

}
