using UnityEngine;
using UnityEngine.UI;

public class SiginPanel : BasePanel
{
    public Button closeButton;

    private void Awake()
    {
        closeButton = this.gameObject.transform.Find("close").GetComponent<Button>();
        //closeButton.onClick.AddListener(HidePanel);
    }

    private void HidePanel()
    {
        UIManager.Getinstate().HidePanel("Signin");
    }

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
        Debug.Log("œ‘ æ√Ê∞Â");
        closeButton = this.gameObject.transform.Find("close").GetComponent<Button>();
        if (closeButton == null)
        {
            Debug.Log("buttonClose" +
                "ø’");
        }
        base.ShowMe();
    }

    private void HideActive()
    {
        GameObject obj = this.gameObject;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}