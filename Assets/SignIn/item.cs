using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public string itemName;
    public string itemInfo;
    public string daynumber;

    private Text t_itemInfo;
    private Text t_dayint;
    private Image t_image;
    private Button btn_close;
    // Start is called before the first frame update
    private void Start()
    {
        t_itemInfo = this.gameObject.transform.Find("ItemInfo").GetComponent<Text>();
        t_dayint = this.gameObject.transform.Find("day").GetComponent<Text>();
        btn_close= this.GetComponent<Button>();
        t_image = this.GetComponent<Image>();
        
    }

    public void AddTrigger(UnityAction action)//����һ��ί�н���button��
    {
        btn_close.onClick.AddListener(action);
    }

    // Update is called once per frame
    private void Update()
    {
        t_itemInfo.text = itemInfo;
        t_dayint.text = daynumber;
        t_image.sprite = ResMgr.Getinstate().Load<Sprite>("RPGicons/" + itemName);
    }
    
}