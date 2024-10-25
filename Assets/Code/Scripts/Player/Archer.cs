using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Archer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask EnemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint; 

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
   // [SerializeField] private float rotationSpeed = 200f; 
    [SerializeField] private float fireRate = 1f;

    private Transform target;
    private float fireCooldown = 0f;

    private void Update()
    {
        FindTarget();

        if (target != null)
        {
            //RotateTowardsTarget();

            if (ChekTargetIsInRange())
            {
                if (fireCooldown <= 0f)
                {
                    Shoot();
                    fireCooldown = 1f / fireRate;
                }
            }
        }

        if (fireCooldown > 0f)
        {
            fireCooldown -= Time.deltaTime;
        }
    }

    private void FindTarget()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) > targetingRange)
            {
                target = null;
            }
            return;
        }

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, Vector2.zero, 0f, EnemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool ChekTargetIsInRange()
    {
        if (target == null)
            return false;

        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    /*private void RotateTowardsTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    */
    private void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletInstance.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetTarget(target);
            }
        }
    }
    /*
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
    */
}
