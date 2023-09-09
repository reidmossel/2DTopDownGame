using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    public float speed = 5f;
    Transform player;

    public int enemyHealth = 10;
    public int enemyMaxHealth = 10;
    public int enemyDamage = 2;

    [SerializeField] FloatingStatusbar healthBar;

    void Awake()
    {
        healthBar = GetComponentInChildren<FloatingStatusbar>();
    }

    void Start()
    {
        // Find player
        player = FindObjectOfType<PlayerController>().transform;

        healthBar.UpdateStatusBar(enemyHealth, enemyMaxHealth);
    }

    void Update()
    {

        Debug.DrawLine(player.position, transform.position, Color.red);
        // Move towards player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    // Taking damage
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            TakeDamage(other.GetComponent<Projectile>().projectileDamage);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        healthBar.UpdateStatusBar(enemyHealth, enemyMaxHealth);
        if (enemyHealth <= 0)
        {
            HUD.score = HUD.score + 1;
            Destroy(gameObject);
        }
    }
}
