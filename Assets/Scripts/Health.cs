using UnityEngine;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour
{

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private Slider _slider;
    private bool _isPlayer;
    private bool _isCrystal;
    private bool _isMob;
    public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

    private int _currentHealth;
    public int CurrentHealth { get { return _currentHealth; } set { _maxHealth = value; } }

    public static event Action OnPlayerKilled;
    public static event Action OnMobKilled;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _isPlayer = TryGetComponent<PlayerController>(out PlayerController playerController);
        _isCrystal = TryGetComponent<Crystal>(out Crystal crystal);
        _isMob = TryGetComponent<Mob>(out Mob mob);
    }


    private void Start()
    {
        if(_isPlayer)
        {
            _slider.maxValue = _maxHealth;
        }
    }

    private void Update()
    {
        if (_isPlayer)
        {
            _slider.value = _currentHealth;
        }
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

        if (_isPlayer || _isCrystal)
        {
            OnPlayerKilled?.Invoke();
        }

        if (_isMob)
        {
            OnMobKilled?.Invoke();
        }
    }
   
}
