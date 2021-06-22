using LitJson;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class GameMain : MonoBehaviour
{

    public static string jsonPath = @"F:\unity3D\Signin\Assets\Json\signin.txt";
    public static string jsonCon = "";

    public SiginPanel siginPanel;
    public GameObject father;

    // Start is called before the first frame update
    private void Start()
    {
        //siginPanel = ResMgr.Getinstate().Load<SiginPanel>("UI/Signin");
        //siginPanel.transform.SetParent(father.transform);
        GameStar();
    }

    public void GameStar()
    {
        Debug.Log("游戏开始");
        //实例化签到面板
        //siginPanel = new SiginPanel();
        siginPanel = ResMgr.Getinstate().Load<SiginPanel>("UI/Signin");
        if (UIManager.Getinstate().panelDic.ContainsKey("Signin"))
        {
        }
        else
        {
            UIManager.Getinstate().panelDic.Add("Signin", siginPanel);
        }
        UIManager.Getinstate().ShowPanel<SiginPanel>("Signin", E_UI_Layer.Top, (obj) => //ShowPanel方法中有加载面板
        {
            Debug.Log("显示面板完成：加载物体数据");

            //显示完面板后，加载Json数据，读取Json文件所在地
            string jsonCon = File.ReadAllText(GameMain.jsonPath);
            JsonReader json = new JsonReader(jsonCon);
            var jitems = JsonMapper.ToObject<JsonItems>(json);
            //数据读取完毕，打印一下，然后加载到面板上
            //foreach (var jitem in jitems.m_Jsonitems)
            //{
            //    Debug.Log("物品名：" + jitem.name + "\n" +
            //        "描述名" + jitem.Info + "\n" +
            //        "天数：" + jitem.dayNumber);
            //}
            //根据数据加载天数

            Transform grid = obj.transform.Find("Grid").gameObject.transform;
            foreach (var jitem in jitems.m_Jsonitems)
            {
                var item = ResMgr.Getinstate().Load<GameObject>("UI/Item");//通过资源管理类，根据路径加载 item prefab
                item.transform.SetParent(grid, false);
                item.transform.localPosition = Vector3.zero;//设置item所在位置
            }
            var items = grid.GetComponentsInChildren<item>();//拿到所有item的脚本，从Json赋值
            for (int i = 0; i < items.Length; i++)
            {
                items[i].itemName = jitems.m_Jsonitems[i].name;//设置物体
                items[i].itemInfo = jitems.m_Jsonitems[i].Info;//设置物体信息
                items[i].daynumber = jitems.m_Jsonitems[i].dayNumber;//设置天数
                //items[i].AddTrigger(() =>
                //{
                //    Debug.Log("我是签到功能");
                //    SaveAndClose();
                //    UIManager.Getinstate().HidePanel("Signin");//生命周期结束，关闭面板
                //});
            }

            siginPanel = obj;
        });
    }

    public void SaveAndClose()
    {
        Debug.Log("保存数据到Json");
        GameObject grid = siginPanel.transform.Find("Grid").gameObject;
        var items = grid.transform.GetComponentsInChildren<item>();//拿到所有item的脚本，然后序列化为Json
        JsonItems jsonItems = new JsonItems();
        foreach (var item in items)
        {
            SigninJson signinJson = new SigninJson();//将数据赋予Json对象
            signinJson.dayNumber = item.daynumber;
            signinJson.Info = item.itemInfo;
            signinJson.name = item.itemName;
            jsonItems.m_Jsonitems.Add(signinJson);//添加到Json列表
        }

        //序列化对象 写入文件
        string jsonCon = JsonMapper.ToJson(jsonItems);
        jsonCon = Regex.Unescape(jsonCon);
        Debug.Log("Json保存的数据为" + jsonCon);
        File.WriteAllText(jsonPath, jsonCon);//UTF8编码保存
    }
}

public class JsonItems
{
    public List<SigninJson> m_Jsonitems = new List<SigninJson>();//json 不能直接序列化列表，要用class包裹
}

public class SigninJson
{
    public string dayNumber;
    public string name;
    public string Info;
}