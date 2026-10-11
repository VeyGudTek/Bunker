using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GunMover GunMover;
    [SerializeField]
    private GunRotator GunRotator;
    [SerializeField]
    private HeadPitcher HeadPitcher;
    [SerializeField]
    private GunManager GunManager;
    [SerializeField]
    private PlayerBulletManager PlayerBulletManager;
    [SerializeField]
    private Transform GunTip;

    public void Shoot()
    {
        GunDataDto currentGunData = GunManager.CurrentGunData;

        PlayerBulletManager.Shoot(GunTip);
        ApplyRecoil(currentGunData.Recoil);
    }

    void ApplyRecoil(float recoilScalar)
    {
        GunMover.ApplyRecoil(recoilScalar);
        GunRotator.ApplyRecoil(recoilScalar);
        HeadPitcher.ApplyRecoil(recoilScalar);
    }
}
