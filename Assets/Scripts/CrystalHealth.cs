using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CrystalHealth : Health
{
    [SerializeField] private Slider _bar;

    private int _mobInTrigger; // ����� ��� ��������� ������� ����, �� ����������� � ������

    private void Start()
    {
        MaxHealth = 1000;
        CurrentHealth = MaxHealth;
        _bar = _bar.GetComponent<Slider>();
        _bar.maxValue = MaxHealth;
        _bar.value = CurrentHealth;
    }

    // ������� ��� ��������� ����������� �� ����
    private IEnumerator DamageOverTime()
    {
        while (_mobInTrigger > 0) // ���� � ���� � ������
        {
            TakeCrystalDamage(Mob.Damage * _mobInTrigger); // �������� �����������
            yield return new WaitForSeconds(1f); // ������ 1 ������� ����� ��������� ���������� �����������
        }
    }

    public void TakeCrystalDamage(int damage)
    {
        TakeDamage(damage); // ������ ������ �������� ����� ��� ��������� ������'�
        _bar.value = CurrentHealth; // ��������� �������� ��������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mob mob = collision.GetComponent<Mob>();
        if (mob != null)
        {
            _mobInTrigger++; // �������� �������� ���� � ������
            if (_mobInTrigger > 1) // ���� ���� � ������ ����� ������, �� �������� �������� ����������� �� ����
                StartCoroutine(DamageOverTime());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Mob mob = collision.GetComponent<Mob>();
        if (mob != null)
        {
            _mobInTrigger--; // �������� �������� ���� � ������
        }
    }
}
