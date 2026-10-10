using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody CharacterRigidbody;
    [SerializeField]
    GunScope GunScope;

    const float BASE_MOVE_SPEED = 5f;
    Vector2 Input = Vector2.zero;

    public void InputMovement(Vector2 movementVector)
    {
        Input = movementVector;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 inputVector = new Vector3(Input.x, 0f, Input.y);
        Vector3 movementVector = transform.TransformDirection(inputVector).normalized;
        float moveSpeed = GunScope.IsScoped ? BASE_MOVE_SPEED / 2f : BASE_MOVE_SPEED;

        CharacterRigidbody.MovePosition(CharacterRigidbody.position + movementVector * moveSpeed * Time.fixedDeltaTime);
    }
}
