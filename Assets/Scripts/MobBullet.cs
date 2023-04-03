using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBullet : Bullet
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.TryGetComponent<PlayerHealth>(out PlayerHealth health);
        if (isPlayer) health.TakeDamage(Damage);

        Destroy(gameObject);
    }
}
