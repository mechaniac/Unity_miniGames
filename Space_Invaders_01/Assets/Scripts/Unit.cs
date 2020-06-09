using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health;

    public void Hit()
    {
        health -= 1;
    }
    protected virtual void Update()
    {
        if (health <= 0)
        {
            StopAllCoroutines();
            gameObject.SetActive(false);
        }
            
    }
    public void ShootProjectile(Transform turret, float speed)
    {
        Projectile_01 projectile = ObjectPooler.SharedInstance.GetProjectile_01();
        if (projectile != null)
        {
            projectile.speed = speed;
            Vector3 offset = new Vector3(0, speed/20f, 0);
            projectile.transform.position = turret.transform.position + offset;
            projectile.gameObject.SetActive(true);
        }
    }
}
