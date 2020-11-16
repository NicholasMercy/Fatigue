using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public GameObject mapCube;
    public GameObject npcNeighbour;

    public GameObject npcAunt;

    // Start is called before the first frame update
    void Start()
    {
        BasicNpcGenerator b = new BasicNpcGenerator();
        Npc e = b.Spawn("Neighbour");
        GameObject g = Instantiate(npcNeighbour, new Vector3(2f, 1f, 2f), Quaternion.identity);

        Npc e2 = b.Spawn("Aunt");
        GameObject g2 = Instantiate(npcAunt, new Vector3(5f, 1f, 2f), Quaternion.identity);



    }

  
}
