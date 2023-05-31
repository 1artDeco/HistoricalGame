using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public partial class Dialogue : MonoBehaviour
{
    [Header("Dialogue")]
    public GameObject objDia;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public Button btnContinue;

    [Header("ImagePrefab")]
    public Transform tfImage;
    public GameObject pfImage;

    public int diaGroupIndex = 0;

    private int curID = 0;
    private List<DialogueStruct> listCur = new List<DialogueStruct>();
    private List<DialogueStruct> listDia_0 = new List<DialogueStruct>();
    private List<DialogueStruct> listDia_1 = new List<DialogueStruct>();


    void Start()
    {
        InitDialogue();
        SetDialogue();

        btnContinue.onClick.RemoveAllListeners();
        btnContinue.onClick.AddListener(delegate ()
        {
            NextStep();
        });

        textDisplay.text = "";
        //StartCoroutine(Type());
    }

    public void SetDialogue()
    {
        switch (diaGroupIndex)
        {
            case 0:
                listCur = new List<DialogueStruct>(listDia_0);
                break;
            case 1:
                listCur = new List<DialogueStruct>(listDia_1);
                break;
        }
    }


    public void NextStep()
    {
        if (listCur == null)
        {
            return;
        }

        if(curID <= listCur.Count - 1)
        {
            DialogueStruct curDia = listCur[curID];
            curID++;
            switch (curDia.type)
            {
                case DiaType.ShowText:
                    objDia.SetActive(true);
                    textDisplay.text = "";
                    StartCoroutine(IE_Type(curDia.text));
                    break;
                case DiaType.HideText:
                    objDia.SetActive(false);
                    NextStep();
                    break;
                case DiaType.ShowImage:
                    GameObject objImage = GameObject.Instantiate(pfImage, tfImage);
                    InteractUIItem itemImage = objImage.GetComponent<InteractUIItem>();
                    itemImage.Init(delegate ()
                    {
                        NextStep();
                    });
                    NextStep();
                    break;
            }
        }
    }

    public IEnumerator IE_Type(string text)
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

public enum DiaType
{
    ShowText,
    ShowImage,
    HideText
}

public class DialogueStruct
{
    public DiaType type;
    public string text;
    public int ID;

    public DialogueStruct(DiaType type,string text)
    {
        this.type = type;
        this.text = text;
    }

    public DialogueStruct(DiaType type,int ID)
    {
        this.type = type;
        this.ID = ID;
    }
}