using UnityEngine;
using UnityEngine.InputSystem;

public class TapTouchNoteController : MonoBehaviour
{
    [Header("判定ラインと許容誤差")]
    public float judgeZ = 0f;       // 判定ラインのZ座標
    public float judgeRange = 0.2f; // 判定範囲

    void Update()
    {
        bool isTapped = false;

        // ✅ タッチ対応
        if (Touchscreen.current != null)
        {
            if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
                isTapped = true;
        }
        // ✅ マウス対応
        else if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
                isTapped = true;
        }

        if (isTapped)
        {
            float distance = Mathf.Abs(transform.position.z - judgeZ);
            if (distance <= judgeRange)
            {
                Destroy(gameObject);
            }
        }
    }
}
