using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InteractUIItem : MonoBehaviour
{
    public Button btnInteract;
    public Image imgInteract;
    public RectTransform rtInteract;

    public void Init(DialogueExcelItem diaData,UnityAction action)
    {
        imgInteract.sprite = Resources.Load(diaData.strText, typeof(Sprite)) as Sprite;
        imgInteract.SetNativeSize();

        rtInteract.anchoredPosition = new Vector2(diaData.posX, diaData.posY);

        btnInteract.onClick.RemoveAllListeners();
        btnInteract.onClick.AddListener(delegate ()
        {
            action.Invoke();
        });
    }

}
