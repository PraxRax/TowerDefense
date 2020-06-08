using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public ScriptableEnemy scriptableEnemy;

    [Header("References")]
    public GameObject deathEffectParticles;

    public Image healthBar;

    // neccassary components
    [HideInInspector]
    public float speed;

    [HideInInspector]
    public float health;

    private bool enemyIsDead = false;

    void Start()
    {
        speed = scriptableEnemy.startSpeed;
        health = scriptableEnemy.startHealth;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / scriptableEnemy.startHealth;

        if(health <= 0f && !enemyIsDead)
        {
            Die();
            enemyIsDead = true;
        }
    }

    public void Slow(float amount)
    {
        speed = scriptableEnemy.startSpeed * (1 - amount);
    }

    private void Die()
    {
        PlayerStats.Money += scriptableEnemy.moneyGain;

        GameObject particleEffect = (GameObject)Instantiate(deathEffectParticles, transform.position, Quaternion.identity);
        Destroy(particleEffect, 2f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }
}
