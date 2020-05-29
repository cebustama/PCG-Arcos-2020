using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject offsetPoint;
    public BulletObject bullet;

    GameObject weaponObject;
    Vector2 mousePos;
    Shooting[] shootingPoints;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = (mousePos - (Vector2)transform.position);

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    void Shoot()
    {
        foreach(Shooting s in shootingPoints)
        {
            s.Shoot(bullet.prefab);
        }
    }

    public void Assign(WeaponObject weapon, BulletObject bullet)
    {
        weaponObject = Instantiate(weapon.prefab, offsetPoint.transform);
        shootingPoints = weaponObject.GetComponentsInChildren<Shooting>();

        this.bullet = bullet;
    }

    
}
