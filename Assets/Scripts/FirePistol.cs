using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject Gun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public bool isFiring = false;
    public float TargetDistance;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isFiring)
            {
                StartCoroutine(FiringPistol());
            }
        }
    }

    IEnumerator FiringPistol()
    {
        isFiring = true;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            TargetDistance = hit.distance;
            EnemyDie enemyDie = hit.transform.GetComponent<EnemyDie>();
            if (enemyDie != null)
            {
                Debug.Log("taking damage");
                enemyDie.transform.SendMessage("DamageEnemey", 10);
            }
        }
        Gun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnimation");
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);
        isFiring = false;
    }
}
