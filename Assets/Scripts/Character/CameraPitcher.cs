using UnityEngine;

public class CameraPitcher : MonoBehaviour
{
    float TargetPitch = 0f;

    void Update()
    {
        ApplyInput();
    }

    void FixedUpdate()
    {
        RotateCamera();
    }

    void ApplyInput()
    {
        TargetPitch -= InputManager.Instance.Look.y * SettingsManager.Instance.Settings.MouseSensitivity;
        TargetPitch = Mathf.Clamp(TargetPitch, -90f, 90f);
    }

    void RotateCamera()
    {
        transform.localRotation = Quaternion.Euler(TargetPitch, 0f, 0f);
    }
}
