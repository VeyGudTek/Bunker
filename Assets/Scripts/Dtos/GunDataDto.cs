public class GunDataDto
{
    public float Damage { get; set; } = 10f;
    public float Recoil { get; set; } = 1f;
    public float FireRate { get; set; } = 0.1f;
    public int AmmoCapacity { get; set; } = 30;
    public int CurrentAmmo { get; set; } = 30;
    public bool Automatic { get; set; } = false;
    public GunDataDto Clone()
    {
        return new GunDataDto
        {
            Recoil = this.Recoil,
            FireRate = this.FireRate,
            AmmoCapacity = this.AmmoCapacity,
            CurrentAmmo = this.CurrentAmmo,
            Automatic = this.Automatic
        };
    }
}
