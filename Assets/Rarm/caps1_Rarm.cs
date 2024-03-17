using UnityEngine;
[DefaultExecutionOrder(1)]
public class caps1_Rarm : MonoBehaviour
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
            Debug.Log("--------------caps1.cs--------------");


            // joint0_Rarmの位置を取得
            Vector3 jointPosition_ob1 = main_RarmScript.Getjoint0_Rarm();
            //joint1_Rarmの位置を取得
            Vector3 jointPosition_ob2 = main_RarmScript.Getjoint1_Rarm();
            //rotationjoint1_Rarmの値を取得
            Vector3 rotationjoint1_Rarm = main_RarmScript.GetRotationjoint1_Rarm();

            //joint0_Rarmとjoint1_Rarmの中点を取得
            Vector3 jointPosition_ob3 = (jointPosition_ob1 + jointPosition_ob2) / 2;
            //joint0_Rarmとjoint1_Rarmの中点にGameObjectを移動
            transform.position = jointPosition_ob3;
            //joint0_Rarmからjoint1_Rarmへの方向ベクトルを取得
            Vector3 directionjoint1_Rarm = (jointPosition_ob2 - jointPosition_ob1).normalized;
            //joint0_Rarmからjoint1_Rarmへの方向を向く回転を計算
            Quaternion rotationQuaternionjoint1_Rarm = Quaternion.LookRotation(directionjoint1_Rarm);
            //回転をEuler角度に変換して取得
            rotationjoint1_Rarm = rotationQuaternionjoint1_Rarm.eulerAngles;
            //joint0_Rarmからjoint1_Rarmへの方向を向く回転を計算
            transform.rotation = rotationQuaternionjoint1_Rarm;
            //rotationjoint1_Rarmのx,y,z軸に90度ずつ回転
            transform.Rotate(90, 90, 90);
            //最終的な回転を取得
            rotationjoint1_Rarm = transform.rotation.eulerAngles;


            // コンソールに移動後の位置を出力
            Debug.Log("caps1 position: " + jointPosition_ob1);
            Debug.Log("caps1 rotation: " + rotationjoint1_Rarm);


            // Debug.Log("joint0_Rarm: " + main_RarmScript.Getjoint0_Rarm());

            // // joint1_Rarmの値を取得してコンソールに出力
            // Debug.Log("joint1_Rarm: " + main_RarmScript.Getjoint1_Rarm());

            // // joint2_Rarmの値を取得してコンソールに出力
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
            //joint0_Rarmの値を取得
            Vector3 jointPosition_ob1 = main_RarmScript.Getjoint0_Rarm();
            //joint1_Rarmの値を取得
            Vector3 jointPosition_ob2 = main_RarmScript.Getjoint1_Rarm();
            //rotationjoint1_Rarmの値を取得
            Vector3 rotationjoint1_Rarm = main_RarmScript.GetRotationjoint1_Rarm();
                        //joint0_Rarmとjoint1_Rarmの中点を取得
            Vector3 jointPosition_ob3 = (jointPosition_ob1 + jointPosition_ob2) / 2;
            //joint0_Rarmとjoint1_Rarmの中点にGameObjectを移動
            transform.position = jointPosition_ob3;
            //joint0_Rarmからjoint1_Rarmへの方向ベクトルを取得
            Vector3 directionjoint1_Rarm = (jointPosition_ob2 - jointPosition_ob1).normalized;
            //joint0_Rarmからjoint1_Rarmへの方向を向く回転を計算
            Quaternion rotationQuaternionjoint1_Rarm = Quaternion.LookRotation(directionjoint1_Rarm);
            //回転をEuler角度に変換して取得
            rotationjoint1_Rarm = rotationQuaternionjoint1_Rarm.eulerAngles;
            //joint0_Rarmからjoint1_Rarmへの方向を向く回転を計算
            transform.rotation = rotationQuaternionjoint1_Rarm;
            //rotationjoint1_Rarmのx,y,z軸に90度ずつ回転
            transform.Rotate(90, 90, 90);
            //最終的な回転を取得
            rotationjoint1_Rarm = transform.rotation.eulerAngles;
        }
        else
        {
            // Debug.LogError("main_Rarm script not found.");
        }
    }
    
}
