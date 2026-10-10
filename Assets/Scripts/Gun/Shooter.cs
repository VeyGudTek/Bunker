using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GunMover GunMover;
    [SerializeField]
    private GunRotator GunRotator;
    [SerializeField]
    private HeadPitcher HeadPitcher;

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.Fire)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        ApplyRecoil(1f);
    }

    void ApplyRecoil(float recoilScalar)
    {
        GunMover.ApplyRecoil(recoilScalar);
        GunRotator.ApplyRecoil(recoilScalar);
        HeadPitcher.ApplyRecoil(recoilScalar);
    }
}
