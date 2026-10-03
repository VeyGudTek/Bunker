using UnityEngine;

public class GunAimer : MonoBehaviour
{
    const float GUN_AIM_SPEED = 1000f;

    [SerializeField]
    private Transform PlayerBodyTransform;
    [SerializeField]
    private Transform CameraTransform;

    public void ApplyRecoil(float recoilScalar)
    {
        Quaternion rotationRecoil = Quaternion.Euler(-recoilScalar, 0f, 0f);
        transform.rotation = transform.rotation * rotationRecoil;
    }

    void FixedUpdate()
    {
        AimGun();
    }

    private void AimGun()
    {
        float yaw = PlayerBodyTransform.localRotation.eulerAngles.y;
        float pitch = CameraTransform.localRotation.eulerAngles.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, 0f);

        float speedPercent = Quaternion.Angle(transform.rotation, targetRotation) / 180f;
        float baseSpeed = GUN_AIM_SPEED * Time.fixedDeltaTime;
        float actualSpeed = Mathf.Lerp(baseSpeed * 0.05f, baseSpeed, speedPercent);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, actualSpeed);
    }
}
