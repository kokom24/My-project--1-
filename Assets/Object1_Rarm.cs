using UnityEngine;
[DefaultExecutionOrder(10)]
public class Object1_Rarm : MonoBehaviour
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
            Debug.Log("--------------Object1.cs--------------");


            // joint0_Rarmの位置を取得
            Vector3 jointPosition_ob1 = main_RarmScript.Getjoint0_Rarm();

            // joint0_Rarmの位置にGameObjectを移動
            transform.position = jointPosition_ob1;

            // コンソールに移動後の位置を出力
            Debug.Log("Object1 position: " + jointPosition_ob1);          
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
            Vector3 jointPosition_ob1 = main_RarmScript.Getjoint0_Rarm();

            // joint0_Rarmの位置にGameObjectを移動
            transform.position = jointPosition_ob1;

            // コンソールに移動後の位置を出力
            // Debug.Log("Object1 position: " + jointPosition_ob1);          
        }
        else
        {
            // Debug.LogError("main_Rarm script not found.");
        }
    }

    
}
