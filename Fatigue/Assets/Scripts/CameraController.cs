using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform lookTarget;
    private Vector3 offset;
    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        
        lookTarget = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(lookTarget.tag);
        offset = transform.position - lookTarget.position;
    }

    // Update is called once per frame
    void Update()
    {

        //designate transform
        moveVector = lookTarget.position + offset;
        ////x
        //moveVector.x = 0;
        ////y
        moveVector.y = 50;
        //rotation 
        transform.eulerAngles = new Vector3(90, 0, 0);
        transform.position = moveVector;
    }
}
