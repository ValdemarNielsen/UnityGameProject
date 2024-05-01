using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    [SerializeField] public GameObject character;
    public float currentHealth { get; set; }
    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if(currentHealth > 0 && anim != null)
        {
            anim.SetTrigger("hurt"); 
        }
        else if((currentHealth <= 0))
        {
            if(anim != null)
            {
                anim.SetTrigger("die");
            }
            
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
