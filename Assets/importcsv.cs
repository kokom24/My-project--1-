using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    void Start()
    {
        string path = "Assets/Resources/test.csv"; // CSVファイルのパス

        // CSVファイルを読み込む
        TextAsset csvFile = Resources.Load<TextAsset>(Path.GetFileNameWithoutExtension(path));

        if (csvFile != null)
        {
            StringReader reader = new StringReader(csvFile.text);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(','); // カンマで区切られた各項目を分割

                // ベクトルに変換してエラーチェック
                if (values.Length >= 3)
                {
                    float x, y, z;
                    if (float.TryParse(values[0], out x) && float.TryParse(values[1], out y) && float.TryParse(values[2], out z))
                    {
                        Vector3 EE_position = new Vector3(x, y, z);

                        // デバッグ出力
                        Debug.Log("EE_position: " + EE_position);
                    }
                    else
                    {
                        Debug.LogError("データのパースに失敗しました: " + line);
                    }
                }
                else
                {
                    Debug.LogError("データ形式が不正です: " + line);
                }
            }

            reader.Close();
        }
        else
        {
            Debug.LogError("CSVファイルが見つかりませんでした。");
        }

        // リソースの解放
        Resources.UnloadAsset(csvFile);
        
        
    }
}
