using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CrystalHealth : Health
{
    [SerializeField] private Slider _bar;
    private Crystal _crystal;

    private void Start()
    {
        _bar.maxValue = MaxHealth;
        _bar.value = CurrentHealth;

        _crystal = GetComponent<Crystal>();
    }

    public void UpdateBarValue()
    {
        _bar.value = CurrentHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isMob = collision.TryGetComponent<Mob>(out Mob mob);
        
        if (isMob)
        {
            _crystal.MobsInCollider++;
            if (_crystal.MobsInCollider == 1)
            {
                StartCoroutine(DamageOverTime());
            }

            
        }
    }

    private IEnumerator DamageOverTime()
    {
        while (_crystal.MobsInCollider > 0)
        {
            TakeDamage(Mob.Damage * _crystal.MobsInCollider);
            UpdateBarValue();
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bool isMob = collision.TryGetComponent<Mob>(out Mob mob);

        if (isMob)
        {
            _crystal.MobsInCollider--;
        }

        if (_crystal.MobsInCollider == 0)
        {
            StopCoroutine(DamageOverTime());
        }
    }
}
