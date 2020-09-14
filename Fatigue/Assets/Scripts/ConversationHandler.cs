using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationHandler : MonoBehaviour
{
    //Declerations
    public TextAsset jsonFile;
    Characters characterinJson;
    LinkedList List;

    //Ui
    public Text Name;
    public Text DiaResponse;
    int count;
    bool MainDone = false;

    void Start()
    {
        //getting json file
        characterinJson = JsonUtility.FromJson<Characters>(jsonFile.text);

        List = PopulateList(7, "Mother");
        //List.MoveToIndex(4);
        //Debug.Log(List.DisplayCurrentNode().dialogue);
        List.Print();
    }

    public void Continue()
    {
        //stop routine
        StopAllCoroutines();
        //stop dialouge when ended
        if (List.DisplayNextNode() != null)
        {
            count++;
            if (count == 1)
            {
                Name.color = Color.blue;
                Name.text = List.DisplayCurrentNode().MainTag;
                DiaResponse.color = Color.blue;
                StartCoroutine(MainSentence(List.DisplayCurrentNode().response));

            }
            else if (count == 2)
            {
                Name.color = Color.red;
                Name.text = List.DisplayCurrentNode().NpcTag;
                DiaResponse.color = Color.red;
                StartCoroutine(MainSentence(List.DisplayCurrentNode().dialogue));
                List.MoveToNext();
                count = 0;
            }
        }



    }

    public LinkedList PopulateList(int index, string Person)
    {
        LinkedList List = new LinkedList();
        int count = 0;
        if(Person == "Mother")
        {
            while (count <= index - 1)
            {
                List.AddAtEnd(characterinJson.Mother[count]);
                count++;
            }
            return List;
        }
        else if(Person == "Father")
        {
            while (count <= index - 1)
            {
                List.AddAtEnd(characterinJson.Father[count]);
                count++;
            }
            return List;

        }
       else
        {
            return null;
        }
       
    }

    IEnumerator MainSentence(string sentence)
    {
        DiaResponse.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DiaResponse.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}

//Character Traits
[System.Serializable]
public class Dialogue
{
    public int id;
    public string NpcTag;
    public string MainTag;
    public string response;
    public string dialogue;
    public string[] tree;
    public int reqInv;
    public string secretDia;


}
[System.Serializable]
//List of Characters (allows for different level list if needed)//
public class Characters
{

    public Dialogue[] Father;
    public Dialogue[] Mother;
}