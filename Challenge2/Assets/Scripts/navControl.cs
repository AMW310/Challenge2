using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private bool isWalking;
    private Vector3 origin;
    private Vector3 direction;
    private CharacterMovement move;
    private EnemyDetection look;

    private float hitDistance;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        move = target.GetComponent<CharacterMovement>();
        look = this.GetComponent<EnemyDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Renderer>().isVisible)
        {
            if (look.chase)
            {
                Chase();
                isWalking = true;
            }
            else if (!look.chase)
            {
                //Freeze();
                isWalking = false;
            }
        }
        //CheckCast();
    }

    void Chase()
    {
        if (isWalking)
        {
            agent.stoppingDistance = 0f;
            agent.speed = 3f;
            agent.destination = target.transform.position;
        }
        else
        {
            agent.stoppingDistance = 20f;
            agent.velocity = Vector3.zero;
            agent.speed = 0f;
            agent.destination = this.transform.position;
        }

        this.transform.LookAt(target.transform);
    }

    /*
     void Freeze()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    */

    /*void CheckCast()
    {
        RaycastHit hit;
        origin = target.transform.position;
        if ((Physics.SphereCast(origin, 2,target.transform.forward, out hit, 10f)))
        {
            hitDistance = hit.distance;
            Debug.Log(hit.transform.gameObject.name);
            if (this.gameObject.GetComponent<Renderer>().isVisible)
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    Freeze();
                    isWalking = false;
                }
                else
                {
                    Chase();
                    isWalking = true;
                }
            }
            else
            {
                Freeze();
                isWalking = false;
            }
        }
        else
        {
            hitDistance = 15f;
        }
    }*/
}