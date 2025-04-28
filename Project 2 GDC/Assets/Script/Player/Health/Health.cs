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

    // Update is called once per frame
   public void TakeDamage (int _dame) 
   {
        currentHealth -= _dame;
        if (currentHealth <= 0)
        {
            anim.SetBool("isDeath", true);
        }
        else {
            healthBar.text = "HP" + currentHealth.ToString();
        }
   }
}
