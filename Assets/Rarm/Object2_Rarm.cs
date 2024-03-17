using UnityEngine;

[DefaultExecutionOrder(20)]
public class Object2_Rarm : MonoBehaviour
{
    // main_Rarmクラスのインスタンスへの参照
    public main_Rarm main_RarmScript;

    void Start()
    {
        // main_Rarmクラスのインスタンスを取得
        main_RarmScript = FindObjectOfType<main_Rarm>();

        // main_RarmScriptがnullでないことを確認
        if (main_RarmScript != null)
        {
            // joint0_Rarmの値を取得してコンソールに出力
            Debug.Log("--------------Object2.cs--------------");

            // joint0_Rarmの位置を取得
            Vector3 jointPosition_ob2 = main_RarmScript.Getjoint1_Rarm();

            // joint0_Rarmの位置にGameObjectを移動
            transform.position = jointPosition_ob2;

            // コンソールに移動後の位置を出力
            Debug.Log("Object2 position: " + jointPosition_ob2);

            // Debug.Log("joint0_Rarm: " + main_RarmScript.Getjoint0_Rarm());
            // Debug.Log("joint1_Rarm: " + main_RarmScript.Getjoint1_Rarm());
            // Debug.Log("joint2_Rarm: " + main_RarmScript.Getjoint2_Rarm());
        }
        else
        {
            Debug.LogError("main_Rarm script not found.");
        }
    }

    void Update()
    {
        // main_RarmScriptがnullでないことを確認
        if (main_RarmScript != null)
        {
            // joint0_Rarmの位置を取得
            Vector3 jointPosition_ob2 = main_RarmScript.Getjoint1_Rarm();

            // joint0_Rarmの位置にGameObjectを移動
            transform.position = jointPosition_ob2;

            // コンソールに移動後の位置を出力
            // Debug.Log("Object2 position: " + jointPosition_ob2);
        }
        else
        {
            // Debug.LogError("main_Rarm script not found.");
        }
    }
}
