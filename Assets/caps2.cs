using UnityEngine;
[DefaultExecutionOrder(2)]
public class caps2 : MonoBehaviour
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
            Debug.Log("--------------caps2.cs--------------");


            // joint1の位置を取得
            Vector3 jointPosition_ob1 = mainScript.GetJoint1();
            //joint2の位置を取得
            Vector3 jointPosition_ob2 = mainScript.GetJoint2();
            //rotationJoint2の値を取得
            Vector3 rotationJoint2 = mainScript.GetRotationJoint2();

            //joint1とjoint2の中点を取得
            Vector3 jointPosition_ob3 = (jointPosition_ob1 + jointPosition_ob2) / 2;
            //joint1とjoint2の中点にGameObjectを移動
            transform.position = jointPosition_ob3;
            //joint1からjoint2への方向ベクトルを取得
            Vector3 directionJoint1 = (jointPosition_ob2 - jointPosition_ob1).normalized;
            //joint1からjoint2への方向を向く回転を計算
            Quaternion rotationQuaternionJoint1 = Quaternion.LookRotation(directionJoint1);
            //回転をEuler角度に変換して取得
            rotationJoint2 = rotationQuaternionJoint1.eulerAngles;
            //joint1からjoint2への方向を向く回転を計算
            transform.rotation = rotationQuaternionJoint1;
            //rotationJoint1のx,y,z軸に90度ずつ回転
            transform.Rotate(90, 90, 90);
            //最終的な回転を取得
            rotationJoint2 = transform.rotation.eulerAngles;

            // コンソールに移動後の位置を出力
            Debug.Log("caps2 position: " + jointPosition_ob1);
            Debug.Log("caps2 rotation: " + rotationJoint2);


            // Debug.Log("Joint0: " + mainScript.GetJoint0());

            // // joint1の値を取得してコンソールに出力
            // Debug.Log("Joint1: " + mainScript.GetJoint1());

            // // joint2の値を取得してコンソールに出力
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
            // joint1の値を取得してコンソールに出力
            // Debug.Log("--------------caps2.cs--------------");

            // joint1の位置を取得
            Vector3 jointPosition_ob1 = mainScript.GetJoint1();
            //joint2の位置を取得
            Vector3 jointPosition_ob2 = mainScript.GetJoint2();
            //rotationJoint2の値を取得
            Vector3 rotationJoint2 = mainScript.GetRotationJoint2();

            //joint1とjoint2の中点を取得
            Vector3 jointPosition_ob3 = (jointPosition_ob1 + jointPosition_ob2) / 2;
            //joint1とjoint2の中点にGameObjectを移動
            transform.position = jointPosition_ob3;
            //joint1からjoint2への方向ベクトルを取得
            Vector3 directionJoint1 = (jointPosition_ob2 - jointPosition_ob1).normalized;
            //joint1からjoint2への方向を向く回転を計算
            Quaternion rotationQuaternionJoint1 = Quaternion.LookRotation(directionJoint1);
            //回転をEuler角度に変換して取得
            rotationJoint2 = rotationQuaternionJoint1.eulerAngles;
            //joint1からjoint2への方向を向く回転を計算
            transform.rotation = rotationQuaternionJoint1;
            //rotationJoint1のx,y,z軸に90度ずつ回転
            transform.Rotate(90, 90, 90);
            //最終的な回転を取得
            rotationJoint2 = transform.rotation.eulerAngles;

            // コンソールに移動後の位置を出力
            // Debug.Log("caps2 position: " + jointPosition_ob1);
            // Debug.Log("caps2 rotation: " + rotationJoint2);
        }
        else
        {
            // Debug.LogError("main script not found.");
        }
    }
    
}
