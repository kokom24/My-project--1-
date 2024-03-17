using UnityEngine;
[DefaultExecutionOrder(10)]
public class Object1 : MonoBehaviour
{
    // mainクラスのインスタンスへの参照
    public main mainScript;

    void Start()
    {
        // mainクラスのインスタンスを取得
        mainScript = FindObjectOfType<main>();

        // mainScriptがnullでないことを確認
        if (mainScript != null)
        {
            // joint0の値を取得してコンソールに出力
            Debug.Log("--------------Object1.cs--------------");


            // joint0の位置を取得
            Vector3 jointPosition_ob1 = mainScript.GetJoint0();

            // joint0の位置にGameObjectを移動
            transform.position = jointPosition_ob1;

            // コンソールに移動後の位置を出力
            Debug.Log("Object1 position: " + jointPosition_ob1);          
        }
        else
        {
            Debug.LogError("main script not found.");
        }
    }

    void Update()
    {
        // mainScriptがnullでないことを確認
        if (mainScript != null)
        {
            // joint0の位置を取得
            Vector3 jointPosition_ob1 = mainScript.GetJoint0();

            // joint0の位置にGameObjectを移動
            transform.position = jointPosition_ob1;

            // コンソールに移動後の位置を出力
            // Debug.Log("Object1 position: " + jointPosition_ob1);          
        }
        else
        {
            // Debug.LogError("main script not found.");
        }
    }

    
}
