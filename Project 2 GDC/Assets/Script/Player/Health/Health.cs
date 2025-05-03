
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private Image healthBar;
    private float currentHealth;
    private Animator anim;
    
    void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (currentHealth <= 0) anim.SetBool("isDead", true);

        healthBar.fillAmount = currentHealth/startingHealth;
    }
   
    // Update is called once per frame
    public void TakeDamage (float _dame) 
   {
        currentHealth -= _dame;
        if (currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
            Debug.Log("Dead");
        }
        else {
            //healthBar.text = "HP" + currentHealth.ToString();
            Debug.Log("Alive");
        }
        Sound.instance.PlayClip(Sound.instance.getHit, transform.position);
   }
}
