using UnityEngine;

public class GunMover : MonoBehaviour
{
    [SerializeField]
    private Transform CameraTransform;

    const float BASE_SPEED_DISTANCE = .5f;
    const float BASE_SPEED = 10f;

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
        float speed = (difference.magnitude / BASE_SPEED_DISTANCE) * BASE_SPEED;

        transform.position = Vector3.MoveTowards(transform.position, CameraTransform.position, speed * Time.fixedDeltaTime);
    }
}
