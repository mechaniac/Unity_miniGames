using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<Projectile_01> projectileList_01;
    public Projectile_01 projectile_01;
    public int amount_projectile_01;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        projectileList_01 = new List<Projectile_01>();
        for (int i = 0; i < amount_projectile_01; i++)
        {
            Projectile_01 p = (Projectile_01)Instantiate(projectile_01);
            p.gameObject.SetActive(false);
            projectileList_01.Add(p);
            p.transform.parent = transform;
        }
    }


    public Projectile_01 GetProjectile_01()
    {
        for (int i = 0; i < projectileList_01.Count; i++)
        {
            if (!projectileList_01[i].gameObject.activeInHierarchy)
            {
                return projectileList_01[i];
            }
        }
        return null;
    }
}
