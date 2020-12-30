using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBossController : MonoBehaviour
{
    public float lookRadius = 1f;
    Transform target;
    NavMeshAgent agent;
    public Transform[] patrollingPoints;
    public static int destinationPoint = 0;
    private bool isChasingEnemy = false;
    private bool isPatrolling = true;
    public bool isBaitAvailable = false;
    private bool isFeeding = false;
    public Transform baitTray;
    private Animation anim;
    private float timeLeft = 2f;
    public bool isDead = false;
    public bool isAttacking =false;
    public bool isAttackTrigger =false;
    public bool isOnWayToFeed = false;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerController.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(isDead);

        if (!isDead)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            float trayDistance = Vector3.Distance(baitTray.position, transform.position);
        //    Debug.Log(agent.remainingDistance);
            

            //Patroling 
            if (!agent.pathPending && agent.remainingDistance <= 7.5f && !isOnWayToFeed)
            {
            //    Debug.Log("not going to next point");
                GoToNextPoint();
            }


            //feeding
           // Debug.Log(trayDistance + " " + "tray distance");
           /* if (isBaitAvailable)
            {
                if (trayDistance <= 3.5f && !isFeeding && !agent.pathPending)
                {
                   // Debug.Log(trayDistance+" "+ "tray distance");
                    GoAndFeed();
                }
            }*/
            if (isFeeding)
            {
                timeLeft -= Time.deltaTime;
                //  Debug.Log("time left is " + " " + timeLeft);

                if (timeLeft <= 0)
                {
                    //    Debug.Log("time left is " + " " + timeLeft);
                    //  GoToNextPoint();
                    isFeeding = false;
                    isBaitAvailable = false;
                    isOnWayToFeed = false;
                    timeLeft = 10f;

                }
            }

            //attacking


        }

       /* if (distance <= lookRadius && !isFeeding )
        {
                Debug.Log("not going to next point1");
                isChasingEnemy = true;
            isPatrolling = false;
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack

                //face target
                FaceTarget();
            }
        }
        else
        {
          Debug.Log("not going to next point2");

            isPatrolling = true;
            isChasingEnemy = false;
        }

        if (isBaitAvailable)
        {
            if (trayDistance <= 15f && !isFeeding)
            {
                GoAndFeed();
            }
        }


        if (isFeeding)
        {
            timeLeft -= Time.deltaTime;
          //  Debug.Log("time left is " + " " + timeLeft);
  
            if (timeLeft <= 0)
            {
            //    Debug.Log("time left is " + " " + timeLeft);
              //  GoToNextPoint();
                isFeeding = false;
                isBaitAvailable = false;
                timeLeft = 10f;

            }
        }

            if (isAttackTrigger == true && isAttacking == false)
            {
                StartCoroutine(Attack());
                //Attack();
                Debug.Log(PlayerHealth.currentHealth);
            }
        }
        
*/
        

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 6f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }

    void GoToNextPoint()
    {
        if(patrollingPoints.Length == 0 )
        {
        
           // Debug.Log("No points");
            return;
        }

        agent.destination = patrollingPoints[destinationPoint].position;

        destinationPoint = (destinationPoint + 1) % patrollingPoints.Length;
    }

    public void PutBait(bool bait)
    {
      //  Debug.Log("Bait Placed in tray from EnemyController");
        isBaitAvailable = bait;
    }

    public void GoAndFeed()
    {
         agent.SetDestination(baitTray.position);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bait"))
        {
            isFeeding = true;
              Debug.Log("is feeding is true");
        } 
        
        if (col.gameObject.CompareTag("BaitTriggerZone"))
        {
            if (isBaitAvailable)
            {
                isOnWayToFeed = true;
                GoAndFeed();
            }
            //  Debug.Log("is feeding is true");
        }

        if (col.gameObject.CompareTag("Player"))
        {
            isAttackTrigger = true;
            Debug.Log("touching player");
            GetComponent<Animation>().Play("Zombie Attack");

        }


    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isAttackTrigger = false;
            Debug.Log("touching player");
            GetComponent<Animation>().Play("Walking");
            //   GoToNextPoint();
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        isAttackTrigger = true;
        yield return new WaitForSeconds(1.1f);
        PlayerHealth.currentHealth -= 5;
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }


    public void Dead(bool dead)
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        isDead = dead;
       
    }


 


}
