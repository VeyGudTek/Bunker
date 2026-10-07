using UnityEngine;

public class GunTransformer : MonoBehaviour
{
    [SerializeField]
    private GunMover GunMover;
    [SerializeField]
    private GunRotator GunRotator;

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
        GunRotator.ApplyRecoil(recoilScalar);
        GunMover.ApplyRecoil(recoilScalar);
    }
}
