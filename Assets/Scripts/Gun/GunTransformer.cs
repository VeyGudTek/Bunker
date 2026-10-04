using UnityEngine;

public class GunTransformer : MonoBehaviour
{
    [SerializeField]
    private GunMover GunMover;
    [SerializeField]
    private GunAimer GunAimer;

    private void Update()
    {
        //Test
        if (InputManager.Instance.Fire)
        {
            ApplyRecoil(1f);
        }
    }

    public void ApplyRecoil(float recoilScalar)
    {
        GunAimer.ApplyRecoil(recoilScalar);
        GunMover.ApplyRecoil(recoilScalar);
    }
}
