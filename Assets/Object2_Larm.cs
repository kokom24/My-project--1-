using UnityEngine;

[DefaultExecutionOrder(20)]
public class Object2_Larm : MonoBehaviour
{
    // main_Larmクラスのインスタンスへの参照
    public main_Larm mainScript;

    void Start()
    {
        // main_Larmクラスのインスタンスを取得
        mainScript = FindObjectOfType<main_Larm>();

        // mainScriptがnullでないことを確認
        if (mainScript != null)
        {
            // joint1の値を取得してコンソールに出力
            Debug.Log("--------------Object2_Rarm.cs--------------");

            // joint1の位置を取得
            Vector3 jointPosition_ob2 = mainScript.GetJoint1();

            // joint1の位置にGameObjectを移動
            transform.position = jointPosition_ob2;

            // コンソールに移動後の位置を出力
            Debug.Log("Object2 position: " + jointPosition_ob2);
        }
        else
        {
            Debug.LogError("main_Larm script not found.");
        }
    }

    void Update()
    {
        // mainScriptがnullでないことを確認
        if (mainScript != null)
        {
            // joint1の位置を取得
            Vector3 jointPosition_ob2 = mainScript.GetJoint1();

            // joint1の位置にGameObjectを移動
            transform.position = jointPosition_ob2;

            // コンソールに移動後の位置を出力
            // Debug.Log("Object2 position: " + jointPosition_ob2);
        }
    }
}
