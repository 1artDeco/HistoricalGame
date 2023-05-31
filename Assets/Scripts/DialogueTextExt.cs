using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dialogue
{
    public void InitDialogue()
    {
        listDia_0.Clear();
        listDia_0.Add(new DialogueStruct(DiaType.ShowText, "ME: It¡¯s the last day of August. With the coming of autumn, the weather is getting colder."));
        listDia_0.Add(new DialogueStruct(DiaType.ShowText, "ME: Since magazines are selling well today, I can close this newsstand early."));
        listDia_0.Add(new DialogueStruct(DiaType.ShowText, "ME: Oh, young lady, which magazine are you looking for?"));
        listDia_0.Add(new DialogueStruct(DiaType.ShowText, "School girl: Children¡¯s Literature, please."));
        listDia_0.Add(new DialogueStruct(DiaType.ShowText, "ME: Here you go."));
        listDia_0.Add(new DialogueStruct(DiaType.ShowText, "School girl: Thank you!"));
        listDia_0.Add(new DialogueStruct(DiaType.HideText, ""));

        listDia_1.Clear();
        listDia_1.Add(new DialogueStruct(DiaType.ShowText, ""));
    }



}


/*    IEnumerator Type()
    {
        //index = 0;
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }*/

/*    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }*/