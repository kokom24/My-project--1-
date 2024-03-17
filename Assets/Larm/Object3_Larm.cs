using UnityEngine;

[DefaultExecutionOrder(30)]
public class Object3_Larm : MonoBehaviour
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
            // joint2の値を取得してコンソールに出力
            Debug.Log("--------------Object3_Rarm.cs--------------");

            // joint2の位置を取得
            Vector3 jointPosition_ob3 = mainScript.GetJoint2();

            // joint2の位置にGameObjectを移動
            transform.position = jointPosition_ob3;

            // コンソールに移動後の位置を出力
            Debug.Log("Object3 position: " + jointPosition_ob3);
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
            // joint2の位置を取得
            Vector3 jointPosition_ob3 = mainScript.GetJoint2();

            // joint2の位置にGameObjectを移動
            transform.position = jointPosition_ob3;

            // コンソールに移動後の位置を出力
            // Debug.Log("Object3 position: " + jointPosition_ob3);
        }
    }
}
