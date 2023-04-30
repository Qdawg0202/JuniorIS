using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public int meanDamage;
    public GameObject projectile;
    public float projSpeed;
    public float fireRate = 1.0f;
    private float lastShot = 0.0f;

    void Start()
    {
        meanDamage = 3;
        projSpeed = 23;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > fireRate + lastShot)
            {
                GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
                Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 entityPosition = transform.position;
                Vector2 direction = (mouseposition - entityPosition).normalized;
                bullet.GetComponent<Rigidbody2D>().velocity = projSpeed * direction;
                bullet.GetComponent<Projectile>().damage = getDamage(meanDamage);
                lastShot = Time.time;
            }  
        }
    }

    private int getDamage(int meanDamage) //will give a gaussian generated number for damage
    {
        double x1, x2;
        x1 = 1.0 - (double)((Time.frameCount % 10) / 10); //creates a random number 0 - 1.0 from the frames since the start of game
        x2 = 1.0 - (double)((Time.fixedTime % 10) / 10); //creates a random number 0 - 1.0 from the seconds sence the start of game
        double randomDev = Math.Sqrt(-2.0 * Math.Log(x1)) * (Math.Sin(2.0 * Math.PI * x2));

        if ((meanDamage + (int)(1 * randomDev)) < 0) // negative damage is a miss
        {
            return 0;
        }

        return meanDamage + (int)(1 * randomDev);
    }

}
