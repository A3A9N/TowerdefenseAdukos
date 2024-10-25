using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private Animator anim;
    [SerializeField] private int currencyWorth = 50;

    public UnityEvent onDeath;

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            if (onDeath != null)
            {
                onDeath.Invoke();
                anim.Play("Death");
            }
            LevelManager.main.IncreaseCurrency(currencyWorth);
            Destroy(gameObject);
        }
    }
}
