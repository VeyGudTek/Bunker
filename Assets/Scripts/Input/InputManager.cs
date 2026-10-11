using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls m_Actions;
    private PlayerControls.PlayerActions m_Player;

    public Vector2 Look => m_Player.Look.ReadValue<Vector2>();
    public Vector2 Move => m_Player.Move.ReadValue<Vector2>();
    public bool Fire => m_Player.Fire.WasPressedThisFrame();
    public bool FireHeld => m_Player.Fire.IsPressed();
    public bool Scope => m_Player.Scope.WasPressedThisFrame();
    public bool ScrollLeft => m_Player.ScrollLeft.WasPressedThisFrame();
    public bool ScrollRight => m_Player.ScrollRight.WasPressedThisFrame();

    void Awake()
    {
        m_Actions = new PlayerControls();
        m_Player = m_Actions.Player;
    }

    void OnDestroy()
    {
        m_Actions.Dispose();
    }

    void OnEnable()
    {
        m_Player.Enable();
    }

    void OnDisable()
    {
        m_Player.Disable();
    }
}
