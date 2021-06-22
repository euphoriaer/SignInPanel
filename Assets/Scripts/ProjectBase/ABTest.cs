using UnityEngine;

namespace Assets.Scripts.ProjectBase
{
    public class ABTest : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            ////未封装的方法 加载AB包
            //AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "model");
            ////加载AB包的资源
            //GameObject obj = ab.LoadAsset<GameObject>("Cube");
            //Instantiate(obj);

            // ABManager.Instance.Test();
            //封装方法
            //ABManager.Instance.LoadRes("model", "Cube");
            //ABManager.Instance.LoadRes<GameObject>("model", "Cube");
            //ABManager.Instance.LoadResAsync("model", "Cube", successOne);
            ABManager.Instance.LoadResAsync<GameObject>("model", "Cube", successTwo);

            //GameObject obj = ABManager.Instance.LoadRes<GameObject>("myasset", "Cube");
            //obj.transform.position = Vector3.zero;
            //ABManager.Instance.MyLoadAsset<GameObject>(Application.dataPath + "/Download/UI/Button", "Button", "Button");
        }

        private void successOne(object arg0)
        {
            Debug.Log("异步加载");
        }

        private void successTwo(object arg0)
        {
            Debug.Log("异步加载2");
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}