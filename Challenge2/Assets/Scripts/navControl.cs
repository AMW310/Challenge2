using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private bool isWalking = true;
    public GameObject player;

    private CharacterMovement move;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        move = target.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if ((Physics.Raycast(target.transform.position, target.transform.forward, out hit, 15f)))
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject == this.gameObject)
            {
                Freeze();
            }
            else
            {
                Chase();
            }
        }
        else if (this.gameObject.GetComponent<Renderer>().isVisible == false)
        {
            Freeze();
        }

    }

    void Chase()
    {
        if (isWalking)
            agent.destination = target.transform.position;
        else
        {
            agent.destination = transform.position;
        }

        this.transform.LookAt(target.transform);
    }

    void Freeze()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}