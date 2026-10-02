using UnityEngine;

public class GunMover : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerBodyTransform;

    const float MAX_SPEED_DISTANCE = .5f;
    const float MAX_SPEED = 10f;

    void FixedUpdate()
    {
        MoveGun();
    }

    private void MoveGun()
    {
        Vector3 difference = PlayerBodyTransform.position - transform.position;
        float speed = Mathf.Clamp(difference.magnitude / MAX_SPEED_DISTANCE, 0f, 1f) * MAX_SPEED;

        transform.position = Vector3.MoveTowards(transform.position, PlayerBodyTransform.position, speed * Time.fixedDeltaTime);
    }
}
