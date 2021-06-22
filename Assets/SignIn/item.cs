using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public string itemName;
    public string itemInfo;
    public string daynumber;

    public Text t_itemInfo;
    public Text t_dayint;
    public Image t_image;
    private Button btn_close;
    public Transform isAlreadyimg;
    public bool isAlready=false;

    // Start is called before the first frame update
    private void Start()
    {
        t_itemInfo = this.gameObject.transform.Find("ItemInfo").GetComponent<Text>();
        t_dayint = this.gameObject.transform.Find("day").GetComponent<Text>();
        btn_close = this.GetComponent<Button>();
        t_image = this.GetComponent<Image>();
    }

    public void init()
    {
        t_itemInfo = this.gameObject.transform.Find("ItemInfo").GetComponent<Text>();
        t_dayint = this.gameObject.transform.Find("day").GetComponent<Text>();
        btn_close = this.GetComponent<Button>();
        t_image = this.GetComponent<Image>();
       
        isAlreadyimg = this.gameObject.transform.Find("isAlready").transform;
    }

    public void AddTrigger(UnityAction action)//传递一个委托交给button绑定
    {
        btn_close.onClick.AddListener(action);
        btn_close.onClick.AddListener(() =>
        {
           
            isAlready = true;
            isAlreadyimg.gameObject.SetActive(isAlready);
        });
    }

    public void initLate()
    {
        t_itemInfo.text = itemInfo;
        t_dayint.text = daynumber;
        t_image.sprite = ResMgr.Getinstate().Load<Sprite>("RPGicons/" + itemName);
        isAlreadyimg = this.gameObject.transform.Find("isAlready").transform;
        if (isAlreadyimg!=null)
        {
            isAlreadyimg.gameObject.SetActive(isAlready);
        }
        else
        {
            Debug.LogError("遮罩表现为空");
        }
        if (isAlready)
        {
            Debug.Log("已签到" + t_dayint.text);
        }
    }
    // Update is called once per frame
    private void Update()
    {
        
    }

    
}