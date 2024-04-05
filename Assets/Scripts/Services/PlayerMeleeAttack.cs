using GameProject.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCoolDown;
    [SerializeField] private int damage;
    [SerializeField] private float range;

    [Header("Collider Parameters")]
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] private float colliderDistance;

    [Header("Player Layer")]
    [SerializeField] private LayerMask enemyLayer;

    private CharacterHealth enemyHealth;
    private Animator anim;




    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }   

    private void Update()
    {
        attack();
    }


    private bool EnemyInRange()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                                             new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
                                             0,
                                             Vector2.left, 0, enemyLayer);
        if (hit.collider != null)
        {
            enemyHealth = hit.transform.GetComponent<CharacterHealth>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamageEnemy()
    {
        if (EnemyInRange())
        {
            enemyHealth.TakeDamage(damage);
            Debug.Log("IVE HIT THE enemy: ");
        }
        
    }

    public void attack()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            anim.SetTrigger("meleeAttack");
        }
    }
}
