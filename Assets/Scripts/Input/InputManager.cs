using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerControls m_Actions;
    private PlayerControls.PlayerActions m_Player;

    public Vector2 Look => m_Player.Look.ReadValue<Vector2>();
    public Vector2 Move => m_Player.Move.ReadValue<Vector2>();
    public bool Fire => m_Player.Fire.WasPressedThisFrame();
    public bool FireHeld => m_Player.Fire.IsPressed();

    void Awake()
    {
        Instance = this;

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
