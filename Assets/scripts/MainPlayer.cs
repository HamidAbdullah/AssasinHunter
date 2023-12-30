using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;


    public HealthBar mainPlayerHealthBar;
    public EnemyPlayer enemy;
    public float movementSpeed = 5f;

    void Start()
    {
        currentHealth = maxHealth;
        mainPlayerHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        transform.Translate(movement * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1")) // Assuming Fire1 is the attack button (e.g., left-click or a specified key)
        {
            // Perform an attack towards the enemy's position
            AttackEnemy();
        }
    }

    void AttackEnemy()
    {
        // Assuming the enemy is within a certain range for attack
        Vector3 enemyPosition = enemy.transform.position;
        float attackRange = 1.5f; // Adjust this range as needed

        if (Vector3.Distance(transform.position, enemyPosition) <= attackRange)
        {
            enemy.TakeDamage(20); // Assuming the main player deals 20 damage per attack to the enemy
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        mainPlayerHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Death logic for the main player
        Destroy(gameObject);
    }
}
