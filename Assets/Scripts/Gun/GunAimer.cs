using UnityEngine;

public class GunAimer : MonoBehaviour
{
    const float GUN_RECOIL = 100f;
    const float RECOIL_RECOVERY_SPEED = 100f;

    [SerializeField]
    CharacterVision Vision;

    public void ApplyRecoil(float recoilScalar)
    {
        Quaternion rotationRecoil = Quaternion.Euler(-recoilScalar * GUN_RECOIL, 0f, 0f);
        transform.rotation = transform.rotation * rotationRecoil;
    }

    void FixedUpdate()
    {
        UpdateRotation();
    }

    void UpdateRotation()
    {
        Vector3 direction = Vision.ViewPoint - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        float speedPercent = Quaternion.Angle(transform.rotation, targetRotation) / 180f;
        float baseSpeed = RECOIL_RECOVERY_SPEED * Time.fixedDeltaTime;
        float actualSpeed = Mathf.Lerp(baseSpeed * .5f, baseSpeed * 5f, speedPercent);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, actualSpeed);
    }
}
