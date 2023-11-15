using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private Rigidbody rb;
    private bool isWalking;
    private Vector3 origin;
    private Vector3 direction;
    private CharacterMovement move;
    private EnemyDetection look;

    private float hitDistance;
    private bool awake;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        move = target.GetComponent<CharacterMovement>();
        look = this.GetComponent<EnemyDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(agent.velocity);
        if (this.gameObject.GetComponent<Renderer>().isVisible)
        {
            if (look.chase)
            {
                if (!awake)
                {
                    StartCoroutine(Wake());
                }
                else if (awake)
                {
                    Chase();

                }
                isWalking = true;
            }
            else if (!look.chase)
            {
                //Freeze();
                Chase();
                isWalking = false;
            }
        }
        //CheckCast();
    }

    IEnumerator Wake()
    {
        transform.LookAt(target.transform);
        yield return new WaitForSeconds(3f);
        Chase();
    }
    void Chase()
    {
        awake = true;

        if (isWalking)
        {
            
            agent.stoppingDistance = 0f;
            agent.speed = 3f;
            agent.destination = target.transform.position;
            agent.isStopped = false;
        }
        else
        {
            agent.stoppingDistance = 20f;
            agent.velocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            agent.speed = 0f;
            agent.SetDestination(transform.position);
            //agent.destination = this.transform.position;
            agent.isStopped = true;
        }
        transform.LookAt(target.transform);
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