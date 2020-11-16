using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc
{
    public string Name { get; set; }
    public string FluffText { get; set; }
    public GameObject destinationObject;
    public Vector3 destination;

}
