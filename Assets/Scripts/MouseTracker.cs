using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{

    public Transform playerTransform;
    public float rotationSpeed = 10f;
  
    private void Update()
    {
        // Отримати позицію миші в світі
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z *= -1;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);



        // Обчислити напрямок від рук героя до позиції миші
        Vector3 direction = worldMousePosition - playerTransform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Повернути руки героя до заданого кута
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if ((transform.position.x < playerTransform.position.x && playerTransform.localScale.x < 0)
            || (transform.position.x > playerTransform.position.x && playerTransform.localScale.x > 0))
        {
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
        

    }
}
