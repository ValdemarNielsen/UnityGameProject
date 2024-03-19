using Assets.Scripts.Services;
using GameProject.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private GameObject character;
    public float CurrecntHealth { get; private set; }
    private Animator anim;

    private void Awake()
    {
        CurrecntHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        CurrecntHealth = Mathf.Clamp(CurrecntHealth - damage, 0, startingHealth);
        if(CurrecntHealth > 0)
        {
            anim.SetTrigger("hurt"); 
        }
        else
        {
            
            anim.SetTrigger("die");
            CharacterDeath();
        }
    }
    public void Update()
    {
        
    }

    public void CharacterDeath()
    {
        Destroy(character);
    }
}
