/*Auto Create, Don't Edit !!!*/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public partial class DialogueExcelItem : ExcelItemBase
{
	public string groupName;
	public ActionType actionType;
	public string strText;
	public float posX;
	public float posY;
	public string ToGroup;
}

[CreateAssetMenu(fileName = "DialogueExcelData", menuName = "Excel To ScriptableObject/Create DialogueExcelData", order = 1)]
public partial class DialogueExcelData : ExcelDataBase<DialogueExcelItem>
{
}

#if UNITY_EDITOR
public class DialogueAssetAssignment
{
	public static bool CreateAsset(List<Dictionary<string, string>> allItemValueRowList, string excelAssetPath)
	{
		if (allItemValueRowList == null || allItemValueRowList.Count == 0)
			return false;
		int rowCount = allItemValueRowList.Count;
		DialogueExcelItem[] items = new DialogueExcelItem[rowCount];
		for (int i = 0; i < items.Length; i++)
		{
			items[i] = new DialogueExcelItem();
			items[i].id = Convert.ToInt32(allItemValueRowList[i]["id"]);
			items[i].groupName = allItemValueRowList[i]["groupName"];
			items[i].actionType = (ActionType) Enum.Parse(typeof(ActionType), allItemValueRowList[i]["actionType"], true);
			items[i].strText = allItemValueRowList[i]["strText"];
			items[i].posX = Convert.ToSingle(allItemValueRowList[i]["posX"]);
			items[i].posY = Convert.ToSingle(allItemValueRowList[i]["posY"]);
			items[i].ToGroup = allItemValueRowList[i]["ToGroup"];
		}
		DialogueExcelData excelDataAsset = ScriptableObject.CreateInstance<DialogueExcelData>();
		excelDataAsset.items = items;
		if (!Directory.Exists(excelAssetPath))
			Directory.CreateDirectory(excelAssetPath);
		string pullPath = excelAssetPath + "/" + typeof(DialogueExcelData).Name + ".asset";
		UnityEditor.AssetDatabase.DeleteAsset(pullPath);
		UnityEditor.AssetDatabase.CreateAsset(excelDataAsset, pullPath);
		UnityEditor.AssetDatabase.Refresh();
		return true;
	}
}
#endif


