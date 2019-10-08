using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DogScript : MonoBehaviour
{

    public static DogScript dog = null;
    bool chasing = false;
    NavMeshAgent myAgent;
    public GameObject targetObj;

    Vector3 postar;
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        if(dog == null)
        {
            dog = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (chasing)
        {
            myAgent.SetDestination(targetObj.transform.position);
            if (WithinDistance())
            {
                chasing = false;
                myAgent.speed = 5f;
                postar = GetTarget();

            }                                                       
        }
        else
        {
            myAgent.SetDestination(postar);
        }

       
        
    }

    public void SetBallTarget(GameObject ball)
    {
        targetObj = ball;
        myAgent.speed = 10f;
        chasing = true;
       
    }


    bool WithinDistance()
    {
        if(Vector3.Distance(targetObj.transform.position, transform.position) < 2)
        {
            return true;
        }
        return false;
    }

    Vector3 GetTarget()
    {
        Vector3 br = (transform.position + (Vector3)Random.insideUnitCircle) * 10;
        return br;

        //return Vector3.zero;
    }
}
