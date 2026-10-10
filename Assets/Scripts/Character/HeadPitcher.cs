using UnityEngine;

public class HeadPitcher : MonoBehaviour
{
    const float MAX_RECOIL_ANGLE = 90f;
    const float RECOIL_DECAY_SPEED = 100f;
    float TargetPitch = 0f;
    Quaternion Recoil = Quaternion.identity;

    public void ApplyRecoil(float recoilScalar)
    {
        float angle = Quaternion.Angle(Recoil, Quaternion.identity);
        if (angle < MAX_RECOIL_ANGLE)
        {
            Recoil *= Quaternion.Euler(-recoilScalar, 0f, 0f);
        }
    }

    public void ApplyInput(float lookY)
    {
        TargetPitch -= lookY * SettingsManager.Instance.Settings.MouseSensitivity;
        TargetPitch = Mathf.Clamp(TargetPitch, -90f, 90f);
    }

    void Update()
    {
        DecayRecoil();
    }

    void FixedUpdate()
    {
        RotateCamera();
    }

    void DecayRecoil()
    {
        float speedPercent = Quaternion.Angle(Recoil, Quaternion.identity) / MAX_RECOIL_ANGLE;
        float baseSpeed = RECOIL_DECAY_SPEED * Time.deltaTime;
        float actualSpeed = Mathf.Lerp(baseSpeed * 0.05f, baseSpeed, speedPercent);

        Recoil = Quaternion.RotateTowards(Recoil, Quaternion.identity, actualSpeed);
    }

    void RotateCamera()
    {
        transform.localRotation = Quaternion.Euler(TargetPitch, 0f, 0f) * Recoil;
    }
}
