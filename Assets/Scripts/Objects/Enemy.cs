using Assets.Scripts.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace GameProject.Models
{
    public class Enemy: Character
    {

        [Header("Stat Parameters")]
        [SerializeField] private float attackCoolDown;
        [SerializeField] private int damage;
        [SerializeField] private float range;
        [SerializeField] private CharacterHealth enemyHealth;

        [Header("Collider Parameters")]
        [SerializeField] BoxCollider2D boxCollider;
        [SerializeField] private float colliderDistance;

        [Header("Player Layer")]
        [SerializeField] private LayerMask playerLayer;
        private float cooldownTimer = Mathf.Infinity;

        [SerializeField] private GameObject gameObject;

        private CharacterHealth playerHealth;
        private Animator anim;

        private EnemyPatrolService enemyPatrol;

        private int[] currentPlayerPosition = GameManager.GetPlayerPosition();

        private void Awake()
        {
            if (GameManager.hasKilled[currentPlayerPosition[0],currentPlayerPosition[1]] == 1){ 
            
                Destroy(gameObject);
            }

            
            anim = GetComponent<Animator>();
            enemyPatrol = GetComponentInParent<EnemyPatrolService>();
        }

        private void Update()
        {
            cooldownTimer += Time.deltaTime;

            //attack when player is within attack range
            if (PlayerInRange())
            {
                if (cooldownTimer >= attackCoolDown)
                {
                    cooldownTimer = 0;
                    anim.SetTrigger("meleeAttack");
                }
            }
            if(enemyPatrol != null)
            {
                enemyPatrol.enabled = !PlayerInRange();
            }
            
        }

        private bool PlayerInRange()
        {
            RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
                                                 new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 
                                                 0, 
                                                 Vector2.left, 0, playerLayer);
            if(hit.collider != null)
            {
                playerHealth = hit.transform.GetComponent<CharacterHealth>();
            }
            return hit.collider != null;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
                                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
        }
        private void DamagePlayer()
        {
            if (PlayerInRange())
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("IVE HIT THE PLAYER: "+playerHealth);
            }
        }

       
    }
}   
