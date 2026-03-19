using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="TalkData",menuName ="Inventory/TalkData")]
public class TalkDataList : ScriptableObject
{
    public List<TalkData> data=new List<TalkData>();
   
}
[System.Serializable]
public class TalkData 
{
    public string name;
    public string talkText;

    
}

