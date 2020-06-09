using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01 : Unit
{
    public float moveSpeed = 0;
    public Transform turret;
    public float pauseBetweenShots = 5f;
    public float projectileSpeed = -12;
    float timeSinceLastShot;
    float speedManipulator;
    float currentTime;


    void Start()
    {
        timeSinceLastShot = 0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        currentTime += Time.deltaTime;
        speedManipulator = Mathf.Sin(currentTime * 10) + 1;

        Vector3 newPosition = new Vector3(transform.position.x - moveSpeed * Time.deltaTime * speedManipulator, transform.position.y, transform.position.z);
        transform.position = newPosition;

        if (transform.position.x < -10)
        {
            Vector3 newLowerPosition = new Vector3(-10f, transform.position.y - 1, transform.position.z);
            transform.position = newLowerPosition;
            moveSpeed = -moveSpeed;
        }
        if (transform.position.x > 10)
        {

            Vector3 newLowerPosition = new Vector3(10f, transform.position.y - 1, transform.position.z);
            transform.position = newLowerPosition;
            moveSpeed = -moveSpeed;
        }
        timeSinceLastShot += Time.deltaTime;
        if(moveSpeed < 0)
        {
            moveSpeed -= Time.deltaTime/50f;
        }
        else
        {
            moveSpeed += Time.deltaTime/50f;
        }
        Vector3 offset = new Vector3(.25f, 0f, 0f);
        Debug.DrawRay(turret.transform.position - offset, turret.transform.TransformDirection(Vector3.down), Color.red);





        if (WouldIHit("Player", 0) & timeSinceLastShot > pauseBetweenShots)
        {
            Shoot();
        }


    }
    IEnumerator ShootAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        if (WouldIHit("enemy", -.3f) || WouldIHit("enemy", .3f)) yield break;

        ShootProjectile(turret, projectileSpeed);


    }

    bool WouldIHit(string objectTag, float offset)
    {
        Vector3 offsetVector = new Vector3(offset, 0, 0);
        RaycastHit hit;
        if (Physics.Raycast(turret.transform.position + offsetVector, turret.transform.TransformDirection(Vector3.down), out hit))
        {
            if (hit.collider.gameObject.tag == objectTag)
            {
                return true;
            }

        }
        return false;
    }
    void Shoot()
    {

        float checkdistance = 1f;
        float checkIntervall = .5f;
        for (float i = -checkdistance; i < checkdistance; i += checkIntervall)
        {
            if (WouldIHit("enemy", i)) return;
        }
        float shootDelay = UnityEngine.Random.Range(0f, 0f);

        ShootProjectile(turret, projectileSpeed);
        //StartCoroutine( ShootAfterDelay(shootDelay));
        timeSinceLastShot = 0;
    }

}
