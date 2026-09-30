using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody CharacterRigidbody;

    const float MoveSpeed = 5f;

    Vector2 Input = Vector2.zero;


    void Update()
    {
        Input = InputManager.Instance.Move;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 inputVector = new Vector3(Input.x, 0f, Input.y);
        Vector3 movementVector = transform.TransformDirection(inputVector).normalized;
        CharacterRigidbody.MovePosition(CharacterRigidbody.position + movementVector * MoveSpeed * Time.fixedDeltaTime);
    }
}
