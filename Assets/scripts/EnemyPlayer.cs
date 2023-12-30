using UnityEngine;
using UnityEngine.UI;

public class EnemyPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public MainPlayer mainPlayer; // This should be assigned with the main player GameObject in the Inspector

    public HealthBar enemyPlayerHealthBar; 

    void Start()
    {
        currentHealth = maxHealth;
        enemyPlayerHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // Implement enemy's intent to attack the main player when in range
        float distance = Vector3.Distance(transform.position, mainPlayer.transform.position);
        if (distance < 1.0f)
        {
            mainPlayer.TakeDamage(30); // Assuming the enemy deals 30 damage per attack
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyPlayerHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Death logic for the enemy player
        Destroy(gameObject);
    }
}
