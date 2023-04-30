using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour 
{
    public int meanDamage;
    public GameObject projectile;
    private GameObject player;
    public float projSpeed;
    public float fireRate;

    // Start is called before the first frame update
    public void Start()
    {
        meanDamage = 2;
        projSpeed = 23;
        player = FindObjectOfType<playerMovement>().gameObject;
        StartCoroutine(ShootPlayer());
    }
    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(Time.frameCount%3);
        if(player != null)
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 playerPos = player.transform.position;
            Vector2 direction = (playerPos - myPos).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = projSpeed * direction;
            bullet.GetComponent<EnemyProjectile>().damage = getDamage(meanDamage);
            StartCoroutine(ShootPlayer());
        }
    }

    private int getDamage(int meanDamage) //will give a gaussian generated number for damage
    {
        double x1, x2;
        x1 = 1.0 - (double)((Time.frameCount % 10)/10); //creates a random number 0 - 1.0 from the frames since the start of game
        x2 = 1.0 - (double)((Time.fixedTime % 10)/10); //creates a random number 0 - 1.0 from the seconds sence the start of game
        double randomDev = Math.Sqrt(-2.0 * Math.Log(x1)) * (Math.Sin(2.0 * Math.PI * x2));

        if ((meanDamage + (int)(1 * randomDev)) < 0) // negative damage is a miss
        {
            return 0;
        }

        return meanDamage + (int)(1*randomDev);
    }
}
