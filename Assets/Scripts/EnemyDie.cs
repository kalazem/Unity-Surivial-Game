using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject TheEnemy;
    public int StatusCheck;

    public void DamageEnemey(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }


    void Update()
    {
        if(EnemyHealth <= 0 && StatusCheck ==0)
        {
            gameObject.transform.SendMessage("Dead", true);
            StatusCheck = 2;
            //  TheEnemy.GetComponent<Animation>().Stop(); 
            TheEnemy.GetComponent<Animation>().Play("Falling Back Death");
           // Dying();
         }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator Dying()
    {
        yield return new WaitForSeconds(3f);
    }
}
