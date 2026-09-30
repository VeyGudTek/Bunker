using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    SettingsDto PrivateSettings = new SettingsDto();
    public SettingsDto Settings => PrivateSettings.Clone();

    private void Awake()
    {
        SetSingleton();
    }

    void SetSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
