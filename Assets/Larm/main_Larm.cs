using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class main_Larm : MonoBehaviour
{
    public float L1 = 5f; // リンク1の長さ
    public float L2 = 5f; // リンク2の長さ

    // 関節位置を保持するフィールド
    public Vector3 joint0 { get; private set; }
    public Vector3 joint1 { get; private set; }
    public Vector3 joint2 { get; private set; }

    // 関節の回転を保持するフィールド
    public Vector3 rotationJoint1 { get; private set; }
    public Vector3 rotationJoint2 { get; private set; }

    // 移動速度
    public float moveSpeed = 50f;

    // CSVでないときの初期位置
    void Start()
    {
        float x = 2f;
        float y = 1f;
        float z = 1f;

        CalculateArmAnglesAndPositions(x, y, z);
    }


    public void CalculateArmAnglesAndPositions(float x, float y, float z)
    {
        // theta0の計算
        float theta0 = Mathf.Atan2(x, z);

        // theta2の計算
        float s2 = Mathf.Sqrt(x * x + z * z);
        float D = (x * x + y * y + z * z - L1 * L1 - L2 * L2) / (2 * L1 * L2);
        float theta2 = Mathf.Atan2(-Mathf.Sqrt(1 - D * D), D);

        // theta1の計算
        float theta1 = Mathf.Atan2(y, s2) - Mathf.Atan2(L2 * Mathf.Sin(theta2), L1 + L2 * Mathf.Cos(theta2));

        // 関節位置の計算
        joint0 = new Vector3(10, 1, 1);
        joint1 = new Vector3(
            L1 * Mathf.Sin(theta0) * Mathf.Cos(theta1),
            L1 * Mathf.Sin(theta1),
            L1 * Mathf.Cos(theta0) * Mathf.Cos(theta1)
        );
        joint2 = new Vector3(
            joint1.x + L2 * Mathf.Sin(theta0) * Mathf.Cos(theta1 + theta2),
            joint1.y + L2 * Mathf.Sin(theta1 + theta2),
            joint1.z + L2 * Mathf.Cos(theta0) * Mathf.Cos(theta1 + theta2)
        );

        //debug
        Debug.Log("-----------------Larm-----------------");
        // Debug.Log("joint0: " + joint0);
        // Debug.Log("joint1: " + joint1);
        // Debug.Log("joint2: " + joint2);
    }

    //joint0~2の参照用の関数
    public Vector3 GetJoint0()
    {
        return joint0;
    }
    public Vector3 GetJoint1()
    {
        return joint1;
    }
    public Vector3 GetJoint2()
    {
        return joint2;
    }

    //rotationJoint1,2の参照用の関数
    public Vector3 GetRotationJoint1()
    {
        return rotationJoint1;
    }
    public Vector3 GetRotationJoint2()
    {
        return rotationJoint2;
    }

    void Update()
    {
        // 現在の位置を取得
        Vector3 currentPosition = transform.position;

        // 手先位置をキーボードで移動
        float deltaX = Input.GetAxis("Fire1") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Fire2") * Time.deltaTime * moveSpeed;
        float deltaZ = Input.GetAxis("Fire3") * Time.deltaTime * moveSpeed;

        // //手先位置をジョイスティックで移動
        // float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        // float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        // float deltaZ = Input.GetAxis("Jump") * Time.deltaTime * moveSpeed;

        // 移動量を現在の位置に加算して新しい位置を計算aa
        Vector3 newPosition = currentPosition + new Vector3(deltaX, deltaY, deltaZ);

        // 新しい位置を手先の位置として使用
        CalculateArmAnglesAndPositions(newPosition.x, newPosition.y, newPosition.z);


        //CSVからのデータを使う場合


        // デバッグ情報の出力
        Debug.Log("x: " + newPosition.x + " y: " + newPosition.y + " z: " + newPosition.z);
        Debug.Log("joint0: " + joint0);
        Debug.Log("joint1: " + joint1);
        Debug.Log("joint2: " + joint2);

        // 手先の位置を新しい位置に更新
        transform.position = newPosition;

        //到達不可能な位置に手先を移動させないようにする
        if (joint2.y >= L1 + L2 || joint2.y <= -1*(L1 + L2) || joint2.z >= L1 + L2 || joint2.z <= -1*(L1 + L2) || joint2.x >= L1 + L2 || joint2.x <= -1*(L1 + L2))
        {
            transform.position = currentPosition;
        }

    }


}
