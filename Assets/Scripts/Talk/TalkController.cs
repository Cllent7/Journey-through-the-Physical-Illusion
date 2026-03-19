using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TalkController : MonoBehaviour
{
    public TalkDataList talkDataList;
    public TalkData[] talkData;
    public Text textname;
    public Text textDes;

    private int chanShu=0;
    private void Start()
    {
        talkData=talkDataList.data.ToArray();
        
        Init();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            InitChanShu();
        }
    }
    public void Init() 
    {
        textname.text=talkData[0].name.ToString();
        textDes.text=talkData[0].talkText.ToString();
        chanShu++;
    }
    public void InitChanShu() 
    {
        if (chanShu < talkData.Length)
        {
            textname.text = talkData[chanShu].name.ToString();
            textDes.text = talkData[chanShu].talkText.ToString();
        }
        chanShu++;
    }
}
