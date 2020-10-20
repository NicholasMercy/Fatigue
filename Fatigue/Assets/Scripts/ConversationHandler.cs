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

    //button objects
    public Button Father;
    public Button Mother;


    //Ui
    public Text Name;
    public Text DiaResponse;
    public GameObject ConvoHud;
    public GameObject closeBtn;

    int count;
    //int populate = 8;

    bool fatherOn = false;
    bool motherOn = false;

    void Start()
    {
        //getting json file
        characterinJson = JsonUtility.FromJson<Characters>(jsonFile.text);
        ConvoHud.SetActive(false);
        ListFather = PopulateList(14, "Father");
        ListMother = PopulateList(9, "Mother");

        //button
        Button father = Father.GetComponent<Button>();
        father.onClick.AddListener(FatherTrue);

        Button mother = Mother.GetComponent<Button>();
        mother.onClick.AddListener(MotherTrue);

        //ListMother.MoveToIndex(4);
        //Debug.Log(List.DisplayCurrentNode().dialogue);
        //ListMother.Print();
        //ListFather.Print();
    }

    public void Continue()
    {
        ConvoHud.SetActive(true);
        //stop routine
        StopAllCoroutines();

        //list assign
        LinkedList Temp = null;
        if (fatherOn == true)
        {
            Temp = ListFather;
        }
        else if (motherOn == true)
        {

            Temp = ListMother;
        }

        //Debug.Log(Temp.DisplayNextNode());
        if (Temp.DisplayCurrentNode().Tag == "Player")
        {
            Name.color = Color.blue;
            Name.text = Temp.DisplayCurrentNode().Tag;
            DiaResponse.color = Color.blue;
            StartCoroutine(MainSentence(Temp.DisplayCurrentNode().dialogue));
            
        }
        else if (Temp.DisplayCurrentNode().Tag == "Father"|| Temp.DisplayCurrentNode().Tag == "Mother")
        {
            Name.color = Color.red;
            Name.text = Temp.DisplayCurrentNode().Tag;
            DiaResponse.color = Color.red;
            StartCoroutine(MainSentence(Temp.DisplayCurrentNode().dialogue));
                     
        }
        if(Temp.DisplayCurrentNode().End == true)
        {
            ConvoHud.SetActive(false);
        }
        Temp.MoveToNext();

    }
    public void Back()
    {
        ConvoHud.SetActive(true);
        //stop routine
        StopAllCoroutines();

        //list assign
        LinkedList Temp = null;
        if (fatherOn == true)
        {
            Temp = ListFather;
        }
        else if (motherOn == true)
        {

            Temp = ListMother;
        }
        Temp.MoveToPrevious();
        //Debug.Log(Temp.DisplayNextNode());
        if (Temp.DisplayCurrentNode().Tag == "Player")
        {
            
            Name.color = Color.blue;
            Name.text = Temp.DisplayCurrentNode().Tag;
            DiaResponse.color = Color.blue;
            StartCoroutine(MainSentence(Temp.DisplayCurrentNode().dialogue));
            

        }
        else if (Temp.DisplayCurrentNode().Tag == "Father" || Temp.DisplayCurrentNode().Tag == "Mother")
        {
          
            Name.color = Color.red;
            Name.text = Temp.DisplayCurrentNode().Tag;
            DiaResponse.color = Color.red;
            StartCoroutine(MainSentence(Temp.DisplayCurrentNode().dialogue));
       
        }
        if (Temp.DisplayCurrentNode().End == true)
        {
            ConvoHud.SetActive(false);
        }

    }


    public void FatherTrue()
    {
        fatherOn = true;
        //Debug.Log("fathjer");
    }
    public void MotherTrue()
    {
        motherOn = true;
        
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
    public string Tag;
    public string dialogue;
    public string[] tree;
    public int reqInv;
    public string secretDia;
    public bool End;


}
[System.Serializable]
//List of Characters (allows for different level list if needed)//
public class Characters
{

    public Dialogue[] Father;
    public Dialogue[] Mother;
}