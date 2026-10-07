using UnityEngine;

public class CharacterVision : MonoBehaviour
{
    [SerializeField]
    Transform ViewPointDebug;

    const float RANGE = 100f;

    public Vector3 ViewPoint { get; private set; } = Vector3.zero;

    void Update()
    {
        CheckVision();
    }

    void CheckVision()
    {
        Ray forward = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(forward, out RaycastHit hit, RANGE))
        {
            ViewPoint = hit.point;
        }
        else
        {
            ViewPoint = forward.GetPoint(RANGE);
        }

        ViewPointDebug.position = ViewPoint;
    }
}
