using UnityEngine;
using UnityEngine.InputSystem;

public class FlickNoteController : MonoBehaviour
{
    [Header("判定ラインと許容誤差")]
    public float judgeZ = 0f;      // 判定ラインのZ座標
    public float judgeRange = 0.2f; // 許容範囲

    private bool isPressing = false; // 押してる状態を追跡

    void Update()
    {
        bool isPressedNow = false;
        bool wasReleasedThisFrame = false;

        // ✅ タッチ対応(Android/iOS)
        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.wasPressedThisFrame)
                isPressing = true;

            // 離した瞬間
            if (touch.press.wasReleasedThisFrame)
            {
                wasReleasedThisFrame = true;
            }
        }
        // ✅ マウス対応(PC)
        else if (Mouse.current != null)
        {
            var mouse = Mouse.current;

            if (mouse.leftButton.wasPressedThisFrame)
                isPressing = true;

            if (mouse.leftButton.wasReleasedThisFrame)
            {
                wasReleasedThisFrame = true;
            }
        }

        // ✅ 指を離した瞬間に判定
        if (wasReleasedThisFrame && isPressing)
        {
            float distance = Mathf.Abs(transform.position.z - judgeZ);
            if (distance <= judgeRange)
            {
                Destroy(gameObject);
            }

            // 押し状態リセット
            isPressing = false;
        }
    }
}
