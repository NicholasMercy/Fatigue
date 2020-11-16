using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourNpc : Npc
{
    public NeighbourNpc()
    {
        Name = "Neighbour";
        FluffText = "Hello there";
        destinationObject = GameObject.FindGameObjectWithTag("Destination 1");

     
    }
 
}
