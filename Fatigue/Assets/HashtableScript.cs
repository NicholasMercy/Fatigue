using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashtableScript : MonoBehaviour
{

    static int Table_Size = 10;

    //struct for Inventory Details
    struct Item
    {
        public string name;
        public int id;
        //rest will be added some other time
    }
    Item[] Hash_table = new Item[Table_Size];
    Item Empty = new Item();
   

    int hash(string name)
    {
        int length = name.Length;
        int hash_value = 0;
        for (int i = 0; i < length; i++)
        {
            hash_value += name[i];
            hash_value = (hash_value * name[i]) % Table_Size;
        }
        return hash_value;
    }

    void intialTable()
    {
        
        for (int i =0; i <Table_Size; i++)
        {
            Hash_table[i] = Empty;
         
        }
    }

    void PrintTable()
    {
        for(int i = 0; i <Table_Size; i++)
        {
            if (Hash_table[i].name == null)
            {
                Debug.Log(i + " Null");

            }
            else
            {
                Debug.Log(i + " "+ Hash_table[i].name);
            }
        }
    }

    bool Hash_table_insert(Item item)
    {
        int index = hash(item.name);
        if(Hash_table[index].name != null)
        {
            index = hash(item.name) * hash(item.name) % Table_Size;
            Debug.Log(index);
        }
        Hash_table[index] = item;
        return true;
    }

    Item hash_table_lookup(string name)
    {
        int index = hash(name);
        if(Hash_table[index].name != null)
        {           
            return Hash_table[index];
        }
        return Empty;
    }

    Item RemoveItem(string name)
    {
        int index = hash(name);
        if (Hash_table[index].name != null)
        {
            Item tmp = Hash_table[index];
            Hash_table[index] = Empty;
            return tmp;
        }
        return Empty;
    }



    private void Start()
    {
        intialTable();

        //Item bottle = new Item();
        //bottle.name = "Rum";
        //bottle.id = 5;

        //Item Scndbottle = new Item();
        //Scndbottle.name = "Rum";
        //Scndbottle.id = 5;

        //Hash_table_insert(bottle);
        //Hash_table_insert(Scndbottle);

        //RemoveItem("Rum");
        PrintTable();

        
        if(hash_table_lookup("Rum").name != null)
        {
            Debug.Log(hash_table_lookup("Rum") + " found ");

        }
       else
        {
            Debug.Log(" not found ");
        }   
   
        

        


        //    Debug.Log("Function working  " + hash("Nick"));
        //    Debug.Log("Function working  " + hash("Nicholas"));
        //
    }
}
