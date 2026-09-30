using UnityEngine;

public class SettingsDto
{
    public float MouseSensitivity { get; set; } = .25f;

    public SettingsDto Clone()
    {
        return new SettingsDto
        {
            MouseSensitivity = this.MouseSensitivity
        };
    }
}
