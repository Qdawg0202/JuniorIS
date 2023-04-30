using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public GameObject player;
    public int health;
    public int maxhealth;
    public Slider healthSlider;

    private void Awake()
    {
        if(playerStats != null)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            playerStats = this;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {

        maxhealth = generateHP(8);
        health = maxhealth;
        healthSlider.value = 1;
    }


    public void takingDamage(int damage)
    {
        health -= damage;
        checkDead();
        healthSlider.value = showHealth();
    }

    public void HealCharacter(int heal)
    {
        health += heal;
    }

    public void checkDead()
    {
        if (health <= 0)
        {
            Destroy(player);
            SceneManager.LoadScene(0);
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
        return (float)health / (float)maxhealth;
    }
}
