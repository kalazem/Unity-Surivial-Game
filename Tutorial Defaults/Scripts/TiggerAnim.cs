using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerAnim : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
      /**/  gameObject.GetComponent<Animation>().Play("walk");
    }
}
