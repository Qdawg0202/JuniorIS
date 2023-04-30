using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxhealth;
    public GameObject hpBar;
    public Slider hpslider;

    // Start is called before the first frame update
    void Start()
    {

        maxhealth = generateHP(6);
        health = maxhealth;
    }

    public void takingDamage(int damage)
    {
        hpBar.SetActive(true);
        health -= damage;
        checkDead();
        hpslider.value = showHealth();
    }

    public void checkDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private int generateHP(int meanHP)
    {
        int hp = meanHP;
        int loss = Time.frameCount % 2;
        if (loss > 0)
        {
            hp += Time.frameCount % 4;
        }
        else
        {
            hp -= Time.frameCount % 3;
        }

        return hp;
    }

    private float showHealth()
    {
        return (float)health/(float)maxhealth;
    }
}
