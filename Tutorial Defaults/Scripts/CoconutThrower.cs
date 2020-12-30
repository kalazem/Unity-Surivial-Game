using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class CoconutThrower : MonoBehaviour
{
    public AudioClip throwSound;
    public Rigidbody coconutPreFab;
    public float throwSpeed = 30.0f;

  
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(throwSound);
            Rigidbody newCoconut = Instantiate(coconutPreFab, transform.position, transform.rotation) as Rigidbody;
            newCoconut.name = "coconut";
            newCoconut.velocity = transform.forward * throwSpeed;
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(),
            newCoconut.GetComponent<Collider>(), true);
        }
        
    }
}
