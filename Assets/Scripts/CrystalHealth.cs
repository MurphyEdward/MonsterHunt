using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalHealth : Health
{
    [SerializeField]private Image bar;
    void Start()
    {
        MaxHealth = 1000;
        CurrentHealth = MaxHealth;
        bar = GetComponent<Image>();
    }

    public void TakeCrystalDamage(int damage)
    {
        TakeDamage(damage);
        bar.fillAmount = CurrentHealth / MaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mob mob = collision.GetComponent<Mob>();
        if (mob != null) TakeCrystalDamage(100);
    }
}
