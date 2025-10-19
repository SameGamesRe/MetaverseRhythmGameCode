using UnityEngine;

public class NoteMover : MonoBehaviour
{
    public float speed = 5f; // 速度（Inspectorで変更可）

    void Update()
    {
        // Z軸マイナス方向へ移動（奥→手前）
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
