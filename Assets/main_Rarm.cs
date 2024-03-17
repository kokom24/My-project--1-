using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class main_Rarm : MonoBehaviour
{
    public float L1 = 5f; // リンク1の長さ
    public float L2 = 5f; // リンク2の長さ

    // 関節位置を保持するフィールド
    public Vector3 joint0_Rarm { get; private set; }
    public Vector3 joint1_Rarm { get; private set; }
    public Vector3 joint2_Rarm { get; private set; }

    // 関節の回転を保持するフィールド
    public Vector3 rotationjoint1_Rarm { get; private set; }
    public Vector3 rotationjoint2_Rarm { get; private set; }

    // 移動速度
    public float moveSpeed = 0.1f;

    // ベースの位置（joint0_Rarm）
    private Vector3 basePosition;

    // 最大到達点の球の半径
    private float maxReachRadius = 5f;

    // 到達不可能な位置
    private Vector3 invalidPosition;

    // CSVでないときの初期位置
    void Start()
    {
        float x = 2f;
        float y = 5f;
        float z = 10f;

        // ベースの位置を設定
        basePosition = new Vector3(x, y, z);

        // ベースの位置でのアームの計算
        CalculateArmAnglesAndPositions(basePosition.x, basePosition.y, basePosition.z);
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
        joint0_Rarm = new Vector3(1, 1, 1);
        joint1_Rarm = new Vector3(
            L1 * Mathf.Sin(theta0) * Mathf.Cos(theta1),
            L1 * Mathf.Sin(theta1),
            L1 * Mathf.Cos(theta0) * Mathf.Cos(theta1)
        );
        joint2_Rarm = new Vector3(
            joint1_Rarm.x + L2 * Mathf.Sin(theta0) * Mathf.Cos(theta1 + theta2),
            joint1_Rarm.y + L2 * Mathf.Sin(theta1 + theta2),
            joint1_Rarm.z + L2 * Mathf.Cos(theta0) * Mathf.Cos(theta1 + theta2)
        );

        
        // 到達不可能な位置を計算
        invalidPosition = basePosition + maxReachRadius * Vector3.one;

        //debug
        Debug.Log("-----------------START-----------------");
        // Debug.Log("joint0_Rarm: " + joint0_Rarm);
        // Debug.Log("joint1_Rarm: " + joint1_Rarm);
        // Debug.Log("joint2_Rarm: " + joint2_Rarm);
    }

    //joint0_Rarm~2の参照用の関数
    public Vector3 Getjoint0_Rarm()
    {
        return joint0_Rarm;
    }
    public Vector3 Getjoint1_Rarm()
    {
        return joint1_Rarm;
    }
    public Vector3 Getjoint2_Rarm()
    {
        return joint2_Rarm;
    }

    //rotationjoint1_Rarm,2の参照用の関数
    public Vector3 GetRotationjoint1_Rarm()
    {
        return rotationjoint1_Rarm;
    }
    public Vector3 GetRotationjoint2_Rarm()
    {
        return rotationjoint2_Rarm;
    }

    // 手先の位置が到達不可能な場合、キーボード入力を無視する
    void Update()
    {
        // 到達不可能な位置にいる場合、キーボード入力を無視
        if (Vector3.Distance(joint2_Rarm, invalidPosition) < maxReachRadius)
            return;

        // 現在の位置を取得
        Vector3 currentPosition = transform.position;

        // キーボード入力による移動量を計算
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float deltaZ = Input.GetAxis("Jump") * Time.deltaTime * moveSpeed;

        // 新しい位置を計算
        Vector3 newPosition = currentPosition + new Vector3(deltaX, deltaY, deltaZ);

        // 新しい位置を手先の位置として使用
        CalculateArmAnglesAndPositions(newPosition.x, newPosition.y, newPosition.z);

        // デバッグ情報の出力
        Debug.Log("x: " + newPosition.x + " y: " + newPosition.y + " z: " + newPosition.z);
        Debug.Log("joint0_Rarm: " + joint0_Rarm);
        Debug.Log("joint1_Rarm: " + joint1_Rarm);
        Debug.Log("joint2_Rarm: " + joint2_Rarm);

        // 手先の位置を更新
        transform.position = newPosition;
    }


}
