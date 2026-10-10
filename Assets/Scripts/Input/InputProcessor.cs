using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    [SerializeField]
    private Shooter Shooter;
    [SerializeField]
    private GunScope GunScope;
    [SerializeField]
    private HeadPitcher HeadPitcher;
    [SerializeField]
    private CharacterRotator CharacterRotator;
    [SerializeField]
    private CharacterMovement CharacterMover;

    void Update()
    {
        InputFire();
        InputScope();
        InputLook();
        InputMovement();
    }

    void InputFire()
    {
        if (InputManager.Instance.Fire)
        {
            Shooter.Shoot();
        }
    }

    void InputScope()
    {
        if (InputManager.Instance.Scope)
        {
            GunScope.ToggleScope();
        }
    }

    void InputLook()
    {
        Vector2 lookVector = InputManager.Instance.Look;

        HeadPitcher.ApplyInput(lookVector.y);
        CharacterRotator.ApplyInput(lookVector.x);
    }

    void InputMovement()
    {
        Vector2 movementVector = InputManager.Instance.Move;

        CharacterMover.InputMovement(movementVector);
    }
}
