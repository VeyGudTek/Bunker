using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GunMover GunMover;
    [SerializeField]
    private GunAimer GunAimer;
    [SerializeField]
    private HeadPitcher HeadPitcher;
    [SerializeField]
    private GunManager GunManager;
    [SerializeField]
    private PlayerBulletManager PlayerBulletManager;
    [SerializeField]
    private Transform GunTip;

    private float ShootTimer = 0f;

    public void Shoot()
    {
        GunDataDto currentGunData = GunManager.CurrentGunData;

        if (ShootTimer > currentGunData.FireRate)
        {
            ShootTimer = 0f;
            PlayerBulletManager.Shoot(GunTip);
            ApplyRecoil(currentGunData.Recoil);
        }
    }

    void ApplyRecoil(float recoilScalar)
    {
        GunMover.ApplyRecoil(recoilScalar);
        GunAimer.ApplyRecoil(recoilScalar);
        HeadPitcher.ApplyRecoil(recoilScalar);
    }

    private void Update()
    {
        ShootTimer += Time.deltaTime;
    }
}
