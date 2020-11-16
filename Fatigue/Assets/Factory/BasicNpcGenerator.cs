using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNpcGenerator : NpcGenerator
{
    public override Npc Generate(string type)
    {
        if (type == "Neighbour")
        {
            return new NeighbourNpc();
        }
        //else if (type == "Aunt")
        //{
        //    return new AuntNpc();
        //}
        else
        {
            return null;
        }

    }

}
