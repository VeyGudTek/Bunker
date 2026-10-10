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
    private PlayerBulletManager PlayerBulletManager;
    [SerializeField]
    private Transform GunTip;

    public void Shoot()
    {
        PlayerBulletManager.Shoot(GunTip.position);
        ApplyRecoil(1f);
    }

    void ApplyRecoil(float recoilScalar)
    {
        GunMover.ApplyRecoil(recoilScalar);
        GunRotator.ApplyRecoil(recoilScalar);
        HeadPitcher.ApplyRecoil(recoilScalar);
    }
}
