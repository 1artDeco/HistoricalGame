using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dialogue
{
    private DialogueExcelData dialogueData;

    public void InitDialogueData()
    {
        dialogueData = ExcelManager.Instance.GetExcelData<DialogueExcelData, DialogueExcelItem>();
        dialogueData.Init();
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