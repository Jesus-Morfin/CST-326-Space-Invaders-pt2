using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public PlayerProjectile laserPrefab;

    private bool laserShot;
    
    
    
    private void Projectile()
    {
        if (!laserShot)
        {
            PlayerProjectile playerProjectile =Instantiate(laserPrefab, this.transform.position, Quaternion.identity);
            playerProjectile.projectileDestroyed += ProjectileDestroyed;
            laserShot = true;
        }
    }

    private void ProjectileDestroyed()
    {
        laserShot = false;
    }

}
