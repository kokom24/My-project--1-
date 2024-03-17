using UnityEngine;

[DefaultExecutionOrder(1)]
public class caps1_Larm : MonoBehaviour
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
            // joint0の値を取得してコンソールに出力
            Debug.Log("--------------caps1_Larm.cs--------------");

            // joint0の位置を取得
            Vector3 jointPosition_ob1 = mainScript.GetJoint0();
            // joint1の位置を取得
            Vector3 jointPosition_ob2 = mainScript.GetJoint1();
            // rotationJoint1の値を取得
            Vector3 rotationJoint1 = mainScript.GetRotationJoint1();

            // joint0とjoint1の中点を取得
            Vector3 jointPosition_ob3 = (jointPosition_ob1 + jointPosition_ob2) / 2;
            // joint0とjoint1の中点にGameObjectを移動
            transform.position = jointPosition_ob3;
            // joint0からjoint1への方向ベクトルを取得
            Vector3 directionJoint1 = (jointPosition_ob2 - jointPosition_ob1).normalized;
            // joint0からjoint1への方向を向く回転を計算
            Quaternion rotationQuaternionJoint1 = Quaternion.LookRotation(directionJoint1);
            // 回転をEuler角度に変換して取得
            rotationJoint1 = rotationQuaternionJoint1.eulerAngles;
            // joint0からjoint1への方向を向く回転を設定
            transform.rotation = rotationQuaternionJoint1;
            // rotationJoint1のx,y,z軸に90度ずつ回転
            transform.Rotate(90, 90, 90);
            // 最終的な回転を取得
            rotationJoint1 = transform.rotation.eulerAngles;

            // コンソールに移動後の位置を出力
            Debug.Log("caps1 position: " + jointPosition_ob1);
            Debug.Log("caps1 rotation: " + rotationJoint1);
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
            // joint0の値を取得
            Vector3 jointPosition_ob1 = mainScript.GetJoint0();
            // joint1の値を取得
            Vector3 jointPosition_ob2 = mainScript.GetJoint1();
            // rotationJoint1の値を取得
            Vector3 rotationJoint1 = mainScript.GetRotationJoint1();

            // joint0とjoint1の中点を取得
            Vector3 jointPosition_ob3 = (jointPosition_ob1 + jointPosition_ob2) / 2;
            // joint0とjoint1の中点にGameObjectを移動
            transform.position = jointPosition_ob3;
            // joint0からjoint1への方向ベクトルを取得
            Vector3 directionJoint1 = (jointPosition_ob2 - jointPosition_ob1).normalized;
            // joint0からjoint1への方向を向く回転を計算
            Quaternion rotationQuaternionJoint1 = Quaternion.LookRotation(directionJoint1);
            // 回転をEuler角度に変換して取得
            rotationJoint1 = rotationQuaternionJoint1.eulerAngles;
            // joint0からjoint1への方向を向く回転を設定
            transform.rotation = rotationQuaternionJoint1;
            // rotationJoint1のx,y,z軸に90度ずつ回転
            transform.Rotate(90, 90, 90);
            // 最終的な回転を取得
            rotationJoint1 = transform.rotation.eulerAngles;
        }
    }
}
