using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    //ui
    public GameObject Father;
    public GameObject Mother;
    public GameObject KitchenArea;

    public static bool walktoAunt;
    public static bool walktoNeighbour;
    public static bool walktoMom;
    public static bool walktoDad;
    public static bool walktoKitchen;

    public NavMeshAgent agent;

    public Vector3 destination;

    private void Start()
    {

        Mother.SetActive(false);
        Father.SetActive(false);
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
       if(walktoAunt == true)
        {
            destination = GameObject.FindGameObjectWithTag("NpcAunt").transform.position;
        }
       else if (walktoMom == true)
        {
            destination = GameObject.FindGameObjectWithTag("NpcNeighbour").transform.position;
        }
        else if (walktoDad == true)
        {
            destination = GameObject.FindGameObjectWithTag("Father").transform.position;
        }
        else if (walktoKitchen == true)
        {
            destination = GameObject.FindGameObjectWithTag("Mom").transform.position;

        }

        agent.SetDestination(destination);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Father")
        {
           
            Controller.walktoDad = false;
        }
        else if (other.tag == "Mother")
        {
           
            Controller.walktoMom = false;
        }
        else if(other.tag == "Kitchen")
        {
           
          
        }
        else if (other.tag == "NpcNeighbour")
        {
            Controller.walktoNeighbour = false;
        }
        else if (other.tag == "NpcAunt")
        {
            NpCController.interaction = true;
            Controller.walktoAunt = false;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Father")
        {

            Father.SetActive(false);
        }
        else if (other.tag == "Mother")
        {
            Mother.SetActive(false);
        }
        else if (other.tag == "Kitchen")
        {
            

        }
        else if (other.tag == "NpcNeighbour")
        {

        }
        else if (other.tag == "NpcAunt")
        {

            NpCController.interaction = false;
        }

    }


}
