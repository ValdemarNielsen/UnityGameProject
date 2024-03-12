using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
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
        }
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
            Debug.Log("THIS IS THE CURRENT HEALTH: "+CurrecntHealth);
        }
    }
}
