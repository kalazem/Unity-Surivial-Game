using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public static int currentHealth = 20;
    public int internalHealth;

    void Update()
    {
        internalHealth = currentHealth;
    }
}
