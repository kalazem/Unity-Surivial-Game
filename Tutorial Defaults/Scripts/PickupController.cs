using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    public float distance = 10f;
    public Transform equipPosition;
    GameObject currentWeapon;
    bool canGrab;
    public Text textHints;
    private GameObject gameObject;
    private bool CanShoot;
    public AudioClip FiringSound;
    public Camera fpsCam;
    public ParticleSystem muzzkeFlash;
    public GameObject impactEffect;
    public GameObject enemy;
    public static bool isBaited = false;
    private bool isBaitInBag = true;


    /// <summary>
    /// 
    /// </summary>
    /// 
   



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }*/

        if (CanShoot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        if (isBaitInBag)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Bait();
            }
        }
    }



 

/*    private void CheckGrab()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20))
        {
            if(hit.collider.gameObject.tag == "CanGrab")
            {
                 currentWeapon = hit.transform.gameObject;
                canGrab = true;
            }
            else
            {
                canGrab = false;
            }
        }
    }*/

/*    private void PickUp()
    {

        gameObject.transform.parent = equipPosition;
        gameObject.transform.position = equipPosition.position;
        gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        CanShoot = true;

    }*/

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("touching");
        Debug.Log(col.gameObject.tag.Equals("GrabWeapon"));
        Debug.Log(col.gameObject.transform.position);
        if (col.gameObject.CompareTag("GrabWeapon"))
        {
            textHints.SendMessage("ShowHint", "Press E to pick up the gun");
            gameObject = col.gameObject;
            canGrab = true;
        }

        if (col.gameObject.CompareTag("Bait"))
        {
            textHints.SendMessage("ShowHint", "Press G to Place the Bait");
            //isBaited = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        gameObject = null;
        canGrab = false;
    }

    //Use RayCast
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 100f))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            EnemyDie enemyDie = hit.transform.GetComponent<EnemyDie>();

            if (target != null)
            {
                Debug.Log(target.tag);
                Debug.Log("taking damage");
                target.TakeDamage(10f);
            }

            if(enemyDie != null)
            {
                Debug.Log("taking damage");
                enemyDie.transform.SendMessage("DamageEnemey", 10);
            }

           GameObject  gameObject =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.Log(hit.point);
            Destroy(gameObject, 1f);
        }
        if(Inventory.shots > 0)
        {
         GameObject.Find("Pistol").GetComponent<AudioSource>().PlayOneShot(FiringSound);
         Inventory.shots--;
        muzzkeFlash.Play();
        }

    }


    void Bait()
    {

        Debug.Log("Bait Placed in tray from PickController");
        enemy.SendMessage("PutBait", true) ;
        isBaitInBag = true;
    }


    /*  void OnControllerColliderHit(ControllerColliderHit hit)
      {
          //for simple collider detection 
          if (hit.gameObject.tag == "CanGrab")
          {
              Debug.Log("Walked into the door");
          }
      }*/
}
