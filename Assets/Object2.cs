using UnityEngine;

[DefaultExecutionOrder(20)]
public class Object2 : MonoBehaviour
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
            Debug.Log("--------------Object2.cs--------------");

            // joint0の位置を取得
            Vector3 jointPosition_ob2 = mainScript.GetJoint1();

            // joint0の位置にGameObjectを移動
            transform.position = jointPosition_ob2;

            // コンソールに移動後の位置を出力
            Debug.Log("Object2 position: " + jointPosition_ob2);

            // Debug.Log("Joint0: " + mainScript.GetJoint0());
            // Debug.Log("Joint1: " + mainScript.GetJoint1());
            // Debug.Log("Joint2: " + mainScript.GetJoint2());
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
            Vector3 jointPosition_ob2 = mainScript.GetJoint1();

            // joint0の位置にGameObjectを移動
            transform.position = jointPosition_ob2;

            // コンソールに移動後の位置を出力
            // Debug.Log("Object2 position: " + jointPosition_ob2);
        }
        else
        {
            // Debug.LogError("main script not found.");
        }
    }
}
