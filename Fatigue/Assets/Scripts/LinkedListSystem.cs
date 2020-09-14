using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListSystem
{
    public LinkedListSystem next;
    public Dialogue Dia;
    public LinkedListSystem(Dialogue dia)
    {
        this.Dia = dia;

    }
    public Dialogue DisplayCurrentNode()
    {
        return this.Dia;
    }

    public void Print()
    {

        Debug.Log(Dia.NpcTag);
        if (next != null)
        {
            next.Print();
        }
    }
}
public class LinkedList
{
    LinkedListSystem head;

    public void AddAtEnd(Dialogue dia)
    {
        if (head == null)
        {
            head = new LinkedListSystem(dia);
            return;
        }

        LinkedListSystem current = head;
        while (current.next != null)
        {
            current = current.next;
        }
        current.next = new LinkedListSystem(dia);
    }

    public void AddAtStart(Dialogue dia)
    {
        LinkedListSystem newhead = new LinkedListSystem(dia);
        newhead.next = head;
        head = newhead;
    }

    public void DeleteValue(Dialogue dia)
    {
        if (head == null) return;
        if (head.Dia == dia)
        {
            head = head.next;
            return;
        }

        LinkedListSystem current = head;
        while (current.next != null)
        {
            if (current.next.Dia == dia)
            {
                current.next = current.next.next;
                return;
            }
            current = current.next;
        }

    }

    public void MoveToIndex(int id)
    {
        if (head == null) return;
        if (head.Dia.id == id)
        {
            return;
        }

        LinkedListSystem current = head;
        while (current.next != null)
        {
            if (current.next.Dia.id == id)
            {
                head = current.next;
                return;
            }
            current = current.next;
        }
    }

    public void MoveToNext()
    {

        if (head.next != null)
        {
            head = head.next;

        }
        return;
    }

    public Dialogue DisplayNextNode()
    {
        if (head.next != null)
        {
            return head.next.Dia;

        }
        return null;

    }
    public void Print()
    {
        if (head != null)
        {
            head.Print();
        }
    }

    public Dialogue DisplayCurrentNode()
    {
        if (head != null)
        {
            return head.DisplayCurrentNode();

        }
        return null;
    }


}
