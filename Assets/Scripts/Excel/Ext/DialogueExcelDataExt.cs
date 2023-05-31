using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DialogueExcelData
{
    public Dictionary<string, List<DialogueExcelItem>> dicDialogue = new Dictionary<string, List<DialogueExcelItem>>();

    public void Init()
    {
        dicDialogue.Clear();

        for(int i = 0; i < items.Length; i++)
        {
            string groupName = items[i].groupName;
            if (!dicDialogue.ContainsKey(groupName))
            {
                List<DialogueExcelItem> listDialogue = new List<DialogueExcelItem>();
                listDialogue.Add(items[i]);
                dicDialogue.Add(groupName, listDialogue);
            }
            else
            {
                dicDialogue[groupName].Add(items[i]);
            }
        }
    }

    public List<DialogueExcelItem> GetDialogueGroup(string groupName)
    {
        if (dicDialogue.ContainsKey(groupName))
        {
            return dicDialogue[groupName];
        }
        return null;
    }
}
