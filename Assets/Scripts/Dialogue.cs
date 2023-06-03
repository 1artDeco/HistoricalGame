using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum ActionType
{
    SetBG,
    ShowText,
    ShowImage,
    HideText,
    SkipToTalk,
    ClearAllImage
}

public partial class Dialogue : MonoBehaviour
{
    [Header("Background")]
    public Image imgBG;

    [Header("SpeechBox")]
    public GameObject objSpeechBox;
    public TextMeshProUGUI textDisplay;
    public float typingSpeed;
    public Button btnContinue;

    [Header("ImagePrefab")]
    public Transform tfImage;
    public GameObject pfImage;

    [Header("Setting")]
    public string initialGroupName = "Opening";
    //Data
    private List<DialogueExcelItem> listCurDialogue;
    private int curID = 0;

    void Start()
    {
        InitDialogueData();
        if (initialGroupName.Length > 0)
        {
            PublicTool.ClearChildItem(tfImage);
            StartDialogue(initialGroupName);
        }

        btnContinue.onClick.RemoveAllListeners();
        btnContinue.onClick.AddListener(delegate ()
        {
            NextStep();
        });
    }

   public void StartDialogue(string groupName)
    {
        listCurDialogue = dialogueData.GetDialogueGroup(groupName);
        curID = 0;
        NextStep();
    }

     
    public void NextStep()
    {
        if (listCurDialogue == null)
        {
            return;
        }

        if(curID <= listCurDialogue.Count - 1)
        {
            DialogueExcelItem curDia = listCurDialogue[curID];
            curID++;
            switch (curDia.actionType)
            {
                case ActionType.SetBG:
                    imgBG.sprite = Resources.Load(curDia.strText, typeof(Sprite)) as Sprite;
                    NextStep();
                    break;
                case ActionType.ShowText:
                    objSpeechBox.SetActive(true);
                    textDisplay.text = "";
                    StartCoroutine(IE_ShowTextType(curDia.strText));
                    break;
                case ActionType.HideText:
                    objSpeechBox.SetActive(false);
                    NextStep();
                    break;
                case ActionType.ShowImage:
                    GameObject objImage = GameObject.Instantiate(pfImage, tfImage);
                    InteractUIItem itemImage = objImage.GetComponent<InteractUIItem>();
                    itemImage.Init(curDia, delegate ()
                    {
                        if (curDia.ToGroup.Length > 0)
                        {
                            StartDialogue(curDia.ToGroup);
                        }
                    });
                    NextStep();
                    break;
                case ActionType.SkipToTalk:
                    if (curDia.ToGroup.Length > 0)
                    {
                        StartDialogue(curDia.ToGroup);
                    }
                    break;
                case ActionType.ClearAllImage:
                    PublicTool.ClearChildItem(tfImage);
                    NextStep();
                    break;

            }
        }
    }

    public IEnumerator IE_ShowTextType(string text)
    {
        btnContinue.interactable = false;
        foreach (char letter in text.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        btnContinue.interactable = true;
    }
}