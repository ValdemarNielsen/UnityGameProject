using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolService : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("PlayerMovement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behavior")]
    [SerializeField] private float patrolIdleTime;
    private float idleTimer;

    [Header("Animator")]
    [SerializeField] private Animator anim;
    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft) {
            if(enemy.position.x >= leftEdge.position.x) 
                MoveLeftOrRight(-1);
            else
            {
                DirectionChange();
            }
            
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveLeftOrRight(1);
            else
            {
                DirectionChange();
            }
        }
    }

    //Make Enemy face correct direction, then move
    private void MoveLeftOrRight(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("isMoving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
                                     enemy.position.y, enemy.position.z);
    }

    private void DirectionChange()
    {
        anim.SetBool("isMoving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > patrolIdleTime)
            movingLeft = !movingLeft;
    }

    private void OnDisable()
    {
        anim.SetBool("isMoving", false);
    }
}
