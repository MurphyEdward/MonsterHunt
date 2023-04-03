using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int _maxHealth = 100;
    public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

    private int _currentHealth;
    public int CurrentHealth { get { return _currentHealth; } set { _maxHealth = value; } }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

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
        Destroy(gameObject);
    }
   
}
