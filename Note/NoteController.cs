using UnityEngine;
using UnityEngine.InputSystem; // 追加！

public class NoteController : MonoBehaviour
{
    public float judgeZ = 0f;
    public float judgeRange = 0.2f;

    void Update()
    {
        // 新InputSystemでのタップ/クリック検出
        if (Touchscreen.current != null)
        {
            // スマホ・タブレット（タッチ）
            if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                TryJudge();
            }
        }
        else if (Mouse.current != null)
        {
            // PC（クリック）
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                TryJudge();
            }
        }
    }

    void TryJudge()
    {
        float distance = Mathf.Abs(transform.position.z - judgeZ);
        if (distance <= judgeRange)
        {
            Destroy(gameObject);
        }
    }
}
