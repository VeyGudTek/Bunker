using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    private static readonly GunType[] GunTypeOrder = { GunType.Pistol, GunType.AutoRifle };
    private readonly Dictionary<GunType, GunDataDto> BaseGunDataDictionary = BaseGunData.GunDataDictionary
        .ToDictionary(typeDataPair => typeDataPair.Key, typeDataPair => typeDataPair.Value.Clone());

    public GunType CurrentGunType { get; private set; } = GunType.Pistol;
    public GunDataDto CurrentGunData => BaseGunDataDictionary[CurrentGunType];

    public void ScrollGun(bool left)
    {
        int currentIndex = Array.IndexOf(GunTypeOrder, CurrentGunType);

        int increment = left ? -1 : 1;
        currentIndex += increment;
        if (currentIndex < 0)
        {
            currentIndex = GunTypeOrder.Length - 1;

        }
        else if (currentIndex >= GunTypeOrder.Length)
        {
            currentIndex = 0;
        }

        CurrentGunType = GunTypeOrder[currentIndex];
    }
}
