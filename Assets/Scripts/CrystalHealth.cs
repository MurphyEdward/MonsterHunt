using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CrystalHealth : Health
{
    [SerializeField] private Slider _bar;

    private int _mobInTrigger; // змінна для зберігання кількості мобів, які перебувають в тригері

    private void Start()
    {
        MaxHealth = 1000;
        CurrentHealth = MaxHealth;
        _bar = _bar.GetComponent<Slider>();
        _bar.maxValue = MaxHealth;
        _bar.value = CurrentHealth;
    }

    // корутин для нанесення пошкодження по часу
    private IEnumerator DamageOverTime()
    {
        while (_mobInTrigger > 0) // поки є моби в тригері
        {
            TakeCrystalDamage(Mob.Damage * _mobInTrigger); // наносимо пошкодження
            yield return new WaitForSeconds(1f); // чекаємо 1 секунду перед наступним нанесенням пошкодження
        }
    }

    public void TakeCrystalDamage(int damage)
    {
        TakeDamage(damage); // виклик методу базового класу для зменшення здоров'я
        _bar.value = CurrentHealth; // оновлюємо значення слайдера
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mob mob = collision.GetComponent<Mob>();
        if (mob != null)
        {
            _mobInTrigger++; // збільшуємо лічильник мобів в тригері
            if (_mobInTrigger > 1) // якщо мобів в тригері більше одного, то починаємо наносити пошкодження по часу
                StartCoroutine(DamageOverTime());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Mob mob = collision.GetComponent<Mob>();
        if (mob != null)
        {
            _mobInTrigger--; // зменшуємо лічильник мобів в тригері
        }
    }
}
