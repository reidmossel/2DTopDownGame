using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform weapon;
    public float offset = 90f;

    public Transform shotPoint;
    public GameObject projectile;

    public float shotCooldown = 0.2f;
    float nextShotTime;

    public int playerHealth = 10;
    public int maxPlayerHealth = 20;

    public GameObject gameManager;

    [SerializeField] private Slider slider;


    void Update()
    {
        // Player Movement
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += playerInput.normalized * speed * Time.deltaTime;

        if (!PauseMenu.isPaused & !GameOverMenu.isOver)
        {
            // Weapon rotation
            Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
            weapon.rotation = Quaternion.Euler(0f, 0f, angle + offset);

            // Shooting
            if (Input.GetMouseButton(0))
            {
                if (Time.time > nextShotTime)
                {
                    nextShotTime = Time.time + shotCooldown;
                    Instantiate(projectile, shotPoint.position, shotPoint.rotation);
                }
            }
        }
        

        
    }

    // Taking Damage
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            TakeDamage(other.GetComponent<Projectile>().projectileDamage);
        }

        if (other.tag == "Enemy")
        {
            TakeDamage(other.GetComponent<Enemy>().enemyDamage);
        }
    }

    void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        UpdateBar(playerHealth, maxPlayerHealth);
        if (playerHealth <= 0)
        {
            gameManager.GetComponent<GameOverMenu>().GameOver();
        }
    }

    public void UpdateBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

}
