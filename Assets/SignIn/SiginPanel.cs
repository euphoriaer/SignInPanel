using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SiginPanel : BasePanel
{

   
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void HideMe()
    {
        base.HideMe();
    }

    public override void ShowMe()
    {
        Debug.Log("��ʾ���");
        base.ShowMe();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
