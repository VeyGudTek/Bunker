using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    [SerializeField]
    Rigidbody CharacterRigidBody;

    float TargetYaw;

    void Update()
    {
        ApplyInput();
    }

    private void FixedUpdate()
    {
        RotatePlayer();
    }

    void ApplyInput()
    {
        TargetYaw += InputManager.Instance.Look.x * SettingsManager.Instance.Settings.MouseSensitivity;
    }

    void RotatePlayer()
    {
        CharacterRigidBody.MoveRotation(Quaternion.Euler(0f, TargetYaw, 0f));
    }
}
