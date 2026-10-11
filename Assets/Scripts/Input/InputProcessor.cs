using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    [SerializeField]
    private InputManager InputManager;
    [SerializeField]
    private Shooter Shooter;
    [SerializeField]
    private GunManager GunManager;
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
        InputScroll();
        InputLook();
        InputMovement();
    }

    void InputFire()
    {
        if (InputManager.Fire)
        {
            Shooter.Shoot();
        }
    }

    void InputScope()
    {
        if (InputManager.Scope)
        {
            GunScope.ToggleScope();
        }
    }

    void InputScroll()
    {
        bool scrollLeft = InputManager.ScrollLeft;
        bool scrollRight = InputManager.ScrollRight;

        if (scrollLeft || scrollRight)
        {
            GunManager.ScrollGun(scrollLeft);
        }
    }

    void InputLook()
    {
        Vector2 lookVector = InputManager.Look;

        HeadPitcher.ApplyInput(lookVector.y);
        CharacterRotator.ApplyInput(lookVector.x);
    }

    void InputMovement()
    {
        Vector2 movementVector = InputManager.Move;

        CharacterMover.InputMovement(movementVector);
    }
}
