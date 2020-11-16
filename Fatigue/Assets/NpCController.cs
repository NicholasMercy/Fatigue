using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpCController : MonoBehaviour
{
    public Camera cam;

    public GameObject destinationObject;

    public Vector3 destination;

    public NavMeshAgent agent;

    public static bool interaction;

    private void Start()
    {
        destination = destinationObject.transform.position;

    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log(interaction);
            if (interaction == false)
            {
                //MOVe OUr Agent
                agent.SetDestination(destination);

            }
            else if (interaction == true)
            {
            agent.SetDestination(this.transform.position);

            }

    }
}
