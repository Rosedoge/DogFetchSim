using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DogScript : MonoBehaviour
{

    public static DogScript dog = null;
    NavMeshAgent myAgent;
    public GameObject targetObj;
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
        myAgent.SetDestination(targetObj.transform.position);
    }

    public void SetBallTarget(GameObject ball)
    {
        targetObj = ball;
       
    }
}
