using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HashtableScript : MonoBehaviour
{

    static int Table_Size = 10;
    public List<GameObject> InteractibleObjects;

    public static Vector3 destination;

    public GameObject Father;
    public GameObject Mother;
    public GameObject KitchenArea;

    //struct for Inventory Details
    struct Item
    {
        public string name;
        public int id;
        //rest will be added some other time
    }
    Item[] Hash_table = new Item[Table_Size];
    Item Empty = new Item();

    //Parse 
    public Text input;
    public Text Output;

    delegate string ParseCommand(string[] parameters);

    Dictionary<string, string> Descriptions = new Dictionary<string, string>();
    Hashtable Commands;

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

        Commands = new Hashtable();

        //parse Description
        Descriptions.Add("rum", "A FULL BOTTLE OF RUM");
        Descriptions.Add("vodka", "A FULL BOTTLE OF VODKA");
        Descriptions.Add("glass", "A EMPTY GLASS");

        //hashtable for commands
        Commands.Add("look", "1");
        Commands.Add("use", "2");
        Commands.Add("pickup", "3");
        Commands.Add("walk", "4");
        Commands.Add("talk", "5");

        //inventory 
        intialTable();
        //Items
       

        Item Scndbottle = new Item();
        Scndbottle.name = "Vodka";
        Scndbottle.id = 2;

        Item Glass = new Item();
        Glass.name = "Glass";
        Glass.id = 3;




        //PrintTable();

        // //search
        //// if(hash_table_lookup("Rum").name != null)
        //// {
        ////     Debug.Log(hash_table_lookup("Rum") + " found ");

        //// }
        ////else
        //// {
        ////     Debug.Log(" not found ");
        //// }   

    }


    //Parse
    public void CustomParse()
    {

        string[] words = GetWords(input.text); ;
        if (Commands.ContainsKey(words[0]))
        {
            if (Commands[words[0]].ToString() == "1")
            {
                Output.text = Look(words);
                //Debug.Log("working");

            }
            else if (Commands[words[0]].ToString() == "2")
            {
                Output.text = Use(words);
            }
            else if (Commands[words[0]].ToString() == "3")
            {
                Output.text = PickUp(words);
            }
            else if (Commands[words[0]].ToString() == "4")
            {
                Output.text = (WalkTo(words));
            }
            else if (Commands[words[0]].ToString() == "5")
            {
                Output.text = (TalkTo(words));
            }

        }

        string[] GetWords(string s)
        {
            s = s.Trim().ToLower();
            return s.Split(' ');

        }
    }
    string Look(string[] words)
    {

        string output = "";
        string lookAtObject;
       
        if (words[1] == "at")
        {
            lookAtObject = words[2];
          
        }
        else
        {
            lookAtObject = words[1];
           
        }
        string descriptions;
        Descriptions.TryGetValue(lookAtObject, out descriptions);
        output += descriptions;
        if(descriptions =="")
        {
            output = "that item is not infront of you";
            return output;
        }
        else
        {
            return output;
        }
        
    }
    string Use(string[] words)
    {
        string output = "";
        string useObject = words[1];

        if (words[2] == "and")
        {
            return output = "you can not do that";
        }

        if (hash_table_lookup(useObject).name != null)
        {
            string targetObject;

            if (words[2] == "on")
            {
                targetObject = words[3];
            }
            else
            {
                targetObject = words[2];
            }

            output += "You use the " + useObject + " on the " + targetObject;

            //Another Dictionary of Use Methods
            if (targetObject == "glass" && useObject == "rum")
            {                
                output = " You pour rum into the glass";
            }
            if (targetObject == "glass" && useObject == "vodka")
            {
               
                output = " You pour vodka into the glass";
            }

            return output;

        }
        else
        {
            return output = "you do not have the item needed";
        }



    }
    string PickUp(string[] words)
    {
        string output = "";
        string pickupObject = words[1];
        Debug.Log(words[1]);
        string descriptions;
        Descriptions.TryGetValue(pickupObject, out descriptions);

        output += "you add " + pickupObject + " to your inventory";
        Debug.Log(output);
        
        //adding to custom hash table
        if(pickupObject == "rum")
        {
            Item bottle = new Item();
            bottle.name = "rum";
            bottle.id = 1;
            Hash_table_insert(bottle);
        }
        else if(pickupObject == "vodka")
        {
            Item Scndbottle = new Item();
            Scndbottle.name = "vodka";
            Scndbottle.id = 2;
            Hash_table_insert(Scndbottle);
        }
        else if (pickupObject == "glass")
        {
            Item Glass = new Item();
            Glass.name = "glass";
            Glass.id = 3;
            Hash_table_insert(Glass);
        }
      
        Descriptions.Remove(pickupObject);
        return output;


    }

    string WalkTo(string[] words)
    {

        string output = "hi there";
      
        if (words[1] == "to")
        {
            if(words[2] == "aunt")
            {
                Controller.walktoAunt = true;
                output = "you move to your aunt";
                return output;
                
            }
            else if (words[2] == "father")
            {
                Controller.walktoDad = true;
                output = "you move to your father";
                return output;
            }
            else if (words[2] == "mother")
            {
                Controller.walktoMom = true;
                output = "you move to your mother";
                return output;
            }
            else if (words[2] == "neighbour")
            {
                Controller.walktoNeighbour = true;
                output = "you move to your neighbour";
                return output;
            }
        }
       





        else
        {
            output = "repeat that";
            return output;
        }
        return output;


    }

    string TalkTo(string[] words)
    {

        string output = "hi there";

        if (words[1] == "to")
        {
            if (words[2] == "aunt")
            {             

                output = "you talking to your aunt";
                return output;

            }
            else if (words[2] == "father")
            {
                Father.SetActive(true);
                output = "you talking to your father";
                return output;
            }
            else if (words[2] == "mother")
            {
                Mother.SetActive(true);
                output = "you talking to your mother";
                return output;
            }
            else if (words[2] == "neighbour")
            {
               
                output = "you talking to your neighbour";
                return output;
            }
        }

        else
        {
            output = "repeat that";
            return output;
        }
        return output;


    }
}
