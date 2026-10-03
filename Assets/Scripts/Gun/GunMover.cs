using UnityEngine;

public class GunMover : MonoBehaviour
{
    [SerializeField]
    private Transform CameraTransform;

    const float MAX_SPEED_DISTANCE = .5f;
    const float MAX_SPEED = 10f;

    public void ApplyRecoil(float recoilScalar)
    {
        Vector3 baseRecoilVector = new Vector3(0f, .5f, -1f);
        Vector3 localOffset = transform.TransformDirection(baseRecoilVector);

        transform.position += localOffset * recoilScalar;
    }

    void FixedUpdate()
    {
        MoveGun();
    }

    private void MoveGun()
    {
        Vector3 difference = CameraTransform.position - transform.position;
        float speed = Mathf.Clamp(difference.magnitude / MAX_SPEED_DISTANCE, 0f, 1f) * MAX_SPEED;

        transform.position = Vector3.MoveTowards(transform.position, CameraTransform.position, speed * Time.fixedDeltaTime);
    }
}
