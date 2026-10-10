using UnityEngine;

public class GunScope : MonoBehaviour
{
    const float MAX_SPEED = 1f;

    [SerializeField]
    Transform ScopedTransform;
    [SerializeField]
    Transform HipTransform;

    bool IsScoped = false;

    public void ToggleScope()
    {
        IsScoped = !IsScoped;
    }

    private void FixedUpdate()
    {
        Transform target = IsScoped ? ScopedTransform : HipTransform;
        MoveGun(target);
    }

    void MoveGun(Transform targetTransform)
    {
        Vector3 hipToScopeDistance = ScopedTransform.localPosition - HipTransform.localPosition;
        Vector3 difference = targetTransform.localPosition - transform.localPosition;

        float speed = Mathf.Clamp(difference.magnitude / (hipToScopeDistance.magnitude / 2), 0f, 1f)
            * MAX_SPEED;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetTransform.localPosition, speed * Time.fixedDeltaTime);
    }
}
