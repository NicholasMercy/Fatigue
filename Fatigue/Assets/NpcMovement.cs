using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    //fetching animator
    Animator NpcAnimator;
    public static bool walk;
    public static bool idle;


    // Start is called before the first frame update
    void Start()
    {
        NpcAnimator = gameObject.GetComponent<Animator>();
        walk = true;
        idle = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(walk == true)
        {

            NpcAnimator.SetBool("Walk", true);
            NpcAnimator.SetBool("Idle", false);
        }
        if (idle == true)
        {

            NpcAnimator.SetBool("Walk", false);
            NpcAnimator.SetBool("Idle", true);
        }
    }
}
