using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHints : MonoBehaviour
{
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Text>().enabled)
        {
             timer += Time.deltaTime;
            if (timer >= 4)
            {
                gameObject.GetComponent<Text>().enabled = false;
                timer = 0.0f;
            }
        }


    }

    void ShowHint(string message)
    {
        gameObject.GetComponent<Text>().text = message;
        if (!gameObject.GetComponent<Text>().enabled)
        {
            gameObject.GetComponent<Text>().enabled = true;
        }
    }



}
