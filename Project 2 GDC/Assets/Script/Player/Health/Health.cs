using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private TMP_Text healthBar;
     private int currentHealth;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = startingHealth;
    }
    void Update()
    {
        healthBar.text = "HP: " + currentHealth.ToString();
        // if (currentHealth <= 0) anim.SetBool("isDead", true);
    }
    // void FixedUpdate()
    // {
    //     if (currentHealth <= 0) anim.SetBool("isDead", true);
    // }
    // Update is called once per frame
    public void TakeDamage (int _dame) 
   {
        currentHealth -= _dame;
        if (currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
        }
        else {
            healthBar.text = "HP" + currentHealth.ToString();
        }
        Sound.instance.PlayClip(Sound.instance.getHit, transform.position);
   }
}
