using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    COMMON = 20,
    UNCOMMON = 10,
    RARE = 5,
    LEGENDARY = 1
}

[CreateAssetMenu()]
public class WeaponData : ScriptableObject
{
    [System.Serializable]
    public struct WeightedWeapon
    {
        public WeaponObject weapon;
        public Rarity rarity;
    }

    [System.Serializable]
    public struct WeightedBullets
    {
        public BulletObject bullet;
        public Rarity rarity;
    }

    public WeightedWeapon[] weapons;
    public WeightedBullets[] bullets;

    public WeaponObject GetRandomWeapon()
    {
        return weapons[Random.Range(0, weapons.Length)].weapon;
    }

    public BulletObject GetRandomBullet()
    {
        return bullets[Random.Range(0, bullets.Length)].bullet;
    }
}
