using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScritableObjectLoad : AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            //�@IndexOf�̈�����"/(�ǂݍ��܂������t�@�C����)"�Ƃ���B
            if (str.IndexOf("/item.csv") != -1)
            {
                Debug.Log("CSV�t�@�C����������!!!");
                //�@Asset��������ǂݍ��ށiResources�ł͂Ȃ��̂Œ��Ӂj
                TextAsset textasset = AssetDatabase.LoadAssetAtPath<TextAsset>(str);
                //�@������ScriptableObject�t�@�C����ǂݍ��ށB�Ȃ��ꍇ�͐V���ɍ��B
                string assetfile = str.Replace(".csv", ".asset");
                ItemDataBase _itemDataBase = AssetDatabase.LoadAssetAtPath<ItemDataBase>(assetfile);
                if (_itemDataBase == null)
                {
                    _itemDataBase = new ItemDataBase();
                    AssetDatabase.CreateAsset(_itemDataBase, assetfile);
                }

                _itemDataBase.itemDatas = CSVSerializer.Deserialize<ItemData>(textasset.text);
                EditorUtility.SetDirty(_itemDataBase);
                AssetDatabase.SaveAssets();
            }
        }
    }
}
