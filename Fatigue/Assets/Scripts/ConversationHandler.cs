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
    LinkedList ListFather;
    LinkedList ListMother;

    //Ui
    public Text Name;
    public Text DiaResponse;
    public GameObject ConvoHud;
    int count;
    bool MainDone = false;

    void Start()
    {
        //getting json file
        characterinJson = JsonUtility.FromJson<Characters>(jsonFile.text);
        ConvoHud.SetActive(false);
        ListFather = PopulateList(7, "Father");
        ListMother = PopulateList(7, "Mother");


        //List.MoveToIndex(4);
        //Debug.Log(List.DisplayCurrentNode().dialogue);
        //ListMother.Print();
        //ListFather.Print();
    }

    public void ContinueFather()
    {
        ConvoHud.SetActive(true);
        //stop routine
        StopAllCoroutines();       
        if (ListFather.DisplayNextNode() != null)
        {
            count++;
            if (count == 1)
            {
                Name.color = Color.blue;
                Name.text = ListFather.DisplayCurrentNode().MainTag;
                DiaResponse.color = Color.blue;
                StartCoroutine(MainSentence(ListFather.DisplayCurrentNode().response));

            }
            else if (count == 2)
            {
                Name.color = Color.red;
                Name.text = ListFather.DisplayCurrentNode().NpcTag;
                DiaResponse.color = Color.red;
                StartCoroutine(MainSentence(ListFather.DisplayCurrentNode().dialogue));
                ListFather.MoveToNext();
                count = 0;
            }
        }
        else if (ListFather.DisplayNextNode() == null)
        {
            ConvoHud.SetActive(false);
        }
    }
    public void ContinueMother()
    {
        ConvoHud.SetActive(true);
        //stop routine
        StopAllCoroutines();
        if (ListMother.DisplayNextNode() != null)
        {
            count++;
            if (count == 1)
            {
                Name.color = Color.blue;
                Name.text = ListMother.DisplayCurrentNode().MainTag;
                DiaResponse.color = Color.blue;
                StartCoroutine(MainSentence(ListMother.DisplayCurrentNode().response));

            }
            else if (count == 2)
            {
                Name.color = Color.red;
                Name.text = ListMother.DisplayCurrentNode().NpcTag;
                DiaResponse.color = Color.red;
                StartCoroutine(MainSentence(ListMother.DisplayCurrentNode().dialogue));
                ListMother.MoveToNext();
                count = 0;
            }
        }
        else if (ListMother.DisplayNextNode() == null)
        {
            ConvoHud.SetActive(false);
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
            yield return new WaitForSeconds(0.01f);
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