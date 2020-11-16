using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NpcGenerator 
{
    public Npc Spawn(string type)
    {
        Npc npc;

        npc = Generate(type);

        return npc;
    }

    public abstract Npc Generate(string type);

}
