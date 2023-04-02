using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int _maxHealth = 100;
    public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

    [SerializeField] private int _currentHealth = 100;
    public int CurrentHealth { get { return _currentHealth; } set { _maxHealth = value; } }

    public void TakeDamage(int damage)
    {
        if (damage >= _currentHealth)
        {
            Die();
            return;
        }
        _currentHealth -= damage;

    }

    private void Die()
    {
       // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
   
}
