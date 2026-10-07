using UnityEngine;

public class GunAimer : MonoBehaviour
{
    const float AIM_SPEED = 100f;

    [SerializeField]
    CharacterVision Vision;

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateRotation();
    }

    void UpdateRotation()
    {
        Vector3 direction = Vision.ViewPoint - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, AIM_SPEED * Time.fixedDeltaTime);
    }
}
