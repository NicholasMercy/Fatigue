using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomMove : MonoBehaviour
{
    Vector3 StartPosition;
    Vector3 EndPosition;

    public int count;

    float speed = 0.5f;

    public GameObject EndObject;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
       
        EndPosition = EndObject.transform.position;

        count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (NpcMovement.idle == false && count < 1000)
        {
         
         transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
         transform.position = Vector3.Lerp(transform.position, EndPosition, speed * Time.deltaTime);
         
    }
        if (NpcMovement.idle == false && count > 1000 && count < 2000)
        {
           
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            transform.position = Vector3.Lerp(transform.position, StartPosition, speed* Time.deltaTime);

        }
        else if(count > 2000)
        {
            count = 0;

        }
        Debug.Log(transform.position);
    }
}
