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
        Debug.Log("��Ϸ��ʼ");
        //ʵ����ǩ�����
        //siginPanel = new SiginPanel();
        siginPanel = ResMgr.Getinstate().Load<SiginPanel>("UI/Signin");
        if (UIManager.Getinstate().panelDic.ContainsKey("Signin"))
        {
        }
        else
        {
            UIManager.Getinstate().panelDic.Add("Signin", siginPanel);
        }
        UIManager.Getinstate().ShowPanel<SiginPanel>("Signin", E_UI_Layer.Top, (obj) => //ShowPanel�������м������
        {
            Debug.Log("��ʾ�����ɣ�������������");

            //��ʾ�����󣬼���Json���ݣ���ȡJson�ļ����ڵ�
            string jsonCon = File.ReadAllText(GameMain.jsonPath);
            JsonReader json = new JsonReader(jsonCon);
            var jitems = JsonMapper.ToObject<JsonItems>(json);
            //���ݶ�ȡ��ϣ���ӡһ�£�Ȼ����ص������
            //foreach (var jitem in jitems.m_Jsonitems)
            //{
            //    Debug.Log("��Ʒ����" + jitem.name + "\n" +
            //        "������" + jitem.Info + "\n" +
            //        "������" + jitem.dayNumber);
            //}
            //�������ݼ�������

            Transform grid = obj.transform.Find("Grid").gameObject.transform;
            foreach (var jitem in jitems.m_Jsonitems)
            {
                var item = ResMgr.Getinstate().Load<GameObject>("UI/Item");//ͨ����Դ�����࣬����·������ item prefab
                item.transform.SetParent(grid, false);
                item.transform.localPosition = Vector3.zero;//����item����λ��
            }
            var items = grid.GetComponentsInChildren<item>();//�õ�����item�Ľű�����Json��ֵ
            for (int i = 0; i < items.Length; i++)
            {
                items[i].itemName = jitems.m_Jsonitems[i].name;//��������
                items[i].itemInfo = jitems.m_Jsonitems[i].Info;//����������Ϣ
                items[i].daynumber = jitems.m_Jsonitems[i].dayNumber;//��������
                //items[i].AddTrigger(() =>
                //{
                //    Debug.Log("����ǩ������");
                //    SaveAndClose();
                //    UIManager.Getinstate().HidePanel("Signin");//�������ڽ������ر����
                //});
            }

            siginPanel = obj;
        });
    }

    public void SaveAndClose()
    {
        Debug.Log("�������ݵ�Json");
        GameObject grid = siginPanel.transform.Find("Grid").gameObject;
        var items = grid.transform.GetComponentsInChildren<item>();//�õ�����item�Ľű���Ȼ�����л�ΪJson
        JsonItems jsonItems = new JsonItems();
        foreach (var item in items)
        {
            SigninJson signinJson = new SigninJson();//�����ݸ���Json����
            signinJson.dayNumber = item.daynumber;
            signinJson.Info = item.itemInfo;
            signinJson.name = item.itemName;
            jsonItems.m_Jsonitems.Add(signinJson);//��ӵ�Json�б�
        }

        //���л����� д���ļ�
        string jsonCon = JsonMapper.ToJson(jsonItems);
        jsonCon = Regex.Unescape(jsonCon);
        Debug.Log("Json���������Ϊ" + jsonCon);
        File.WriteAllText(jsonPath, jsonCon);//UTF8���뱣��
    }
}

public class JsonItems
{
    public List<SigninJson> m_Jsonitems = new List<SigninJson>();//json ����ֱ�����л��б�Ҫ��class����
}

public class SigninJson
{
    public string dayNumber;
    public string name;
    public string Info;
}