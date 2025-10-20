using UnityEngine;
using UnityEngine.InputSystem;

public class HoldNoteController : MonoBehaviour
{
    [Header("判定ラインZ座標 & 判定幅")]
    public float judgeZ = 0f;
    public float judgeRange = 0.2f;

    [Header("長押し中にZ軸を縮める速度")]
    public float shrinkSpeed = 1.0f; 

    private bool isHolding = false;
    private float originalLength;

    void Start()
    {
        // Inspectorで設定したscale.zを保持
        originalLength = transform.localScale.z;
    }

    void Update()
    {
        bool isPressed = false;

        if (Touchscreen.current != null)
            isPressed = Touchscreen.current.primaryTouch.press.isPressed;
        else if (Mouse.current != null)
            isPressed = Mouse.current.leftButton.isPressed;

        float distance = Mathf.Abs(transform.position.z - judgeZ);

        if (!isHolding && distance <= judgeRange && isPressed)
        {
            isHolding = true;
        }

        if (isHolding)
        {
            if (isPressed)
            {
                // 少しずつ縮める
                Vector3 scale = transform.localScale;
                scale.z = Mathf.Max(0f, scale.z - shrinkSpeed * Time.deltaTime);
                transform.localScale = scale;

                if (scale.z <= 0f)
                    Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
