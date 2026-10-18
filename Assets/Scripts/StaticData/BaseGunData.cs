using System.Collections.Generic;
using UnityEngine;

public static class BaseGunData
{
    public static Dictionary<GunType, GunDataDto> GunDataDictionary = new Dictionary<GunType, GunDataDto>
    {
        { GunType.AutoRifle, new GunDataDto { Damage = 10f, AmmoCapacity = 30, FireRate = 0.1f, Recoil = 0.5f, Automatic = true } },
        { GunType.Pistol, new GunDataDto { Damage = 10f, AmmoCapacity = 12, FireRate = 1f, Recoil = 1f, Automatic = false } }
    };
}
