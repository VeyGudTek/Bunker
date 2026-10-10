using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    [SerializeField]
    Rigidbody CharacterRigidBody;

    float TargetYaw;

    public void ApplyInput(float lookX)
    {
        TargetYaw += lookX * SettingsManager.Instance.Settings.MouseSensitivity;
    }

    private void FixedUpdate()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        CharacterRigidBody.MoveRotation(Quaternion.Euler(0f, TargetYaw, 0f));
    }
}
