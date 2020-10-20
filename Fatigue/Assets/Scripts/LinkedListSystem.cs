using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListSystem
{
    public LinkedListSystem next;
    public LinkedListSystem prev;
    public Dialogue Dia;
    public LinkedListSystem(Dialogue dia)
    {
        this.Dia = dia;
        
    }
    public Dialogue DisplayCurrentNode()
    {
        return this.Dia;
    }

    //Check
    public void Print()
    {

        Debug.Log(Dia.dialogue);
        if (next != null)
        {
            next.Print();
        }
    }
    public void PrintBack()
    {
        Debug.Log(Dia.dialogue);
        if (prev != null)
        {
            prev.PrintBack();
        }

    }
}


public class LinkedList : IEnumerable<LinkedListSystem>
{
    LinkedListSystem head;
    LinkedListSystem tail;

    //setting next nodes
    public IEnumerator<LinkedListSystem> GetEnumerator()
    {
        LinkedListSystem current = head;
        while(current != null)
        {
            yield return current;
            current = current.next;

        }

    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();

    }

    //setting previous nodes
    public IEnumerable GetEnumeratorReverse()
    {
        LinkedListSystem current = tail;
        while (current != null)
        {
            yield return current;
            current = current.prev;

        }

    }

   
    public void AddAtEnd(Dialogue dia)
    {
        LinkedListSystem newNode = new LinkedListSystem(dia);

        if (tail == null)
        {
            head = newNode;
            
        }
        else
        {
            //connecting nodes
            newNode.prev = tail;
            tail.next = newNode;
            
        }
        //set new tail
        tail = newNode;

    }

    public void AddAtStart(Dialogue dia)
    {
        LinkedListSystem newNode = new LinkedListSystem(dia);
        newNode.next = head;
        //add check for tail node
        if (head == null)
        {
            tail = newNode;

        }
        else
        {
            head.prev = newNode;

        }
        head = newNode;
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

    public void MoveToPrevious()
    {
        if (head.prev != null)
        {
            head = head.prev;

        }
        return;

    }
    
    //SIMPLE CHECKS
    public Dialogue DisplayNextNode()
    {
        if (head.next != null)
        {
            return head.next.Dia;

        }
        return null;

    }
    public Dialogue DisplayPrevNode()
    {
        if (head.prev != null)
        {
            return head.prev.Dia;

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
    public void PrintBack()
    {
        if (tail != null)
        {
            tail.PrintBack();
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
