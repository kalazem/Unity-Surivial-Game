using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public static int charge = 0;
    public AudioClip collectSound; //sound effect to play when the player collects a power cell
    // HUD
    public Texture2D[] hudCharge; //will hold textures 
    public RawImage chargeHudGUI;
    // Generator
    public Texture2D[] meterCharge; //will hold textures
    public Renderer meter;
    public static int shots = 5;
    // Start is called before the first frame update
    void Start()
    {
        charge = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void CellPickup()
    {
        HUDon();
        chargeHudGUI.texture = hudCharge[charge+1];
        meter.material.mainTexture = meterCharge[charge+1];
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;
    }
    void HUDon()
    {
        Debug.Log("Hey");

        if (!chargeHudGUI.enabled)
        {
            chargeHudGUI.enabled = true;
        }
    }

}
