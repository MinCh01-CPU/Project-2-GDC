
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private Image healthBar;
    private float currentHealth;
    private Animator anim;
    public GameObject UI;
    private UImanager UIscript;
    
    void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        UIscript=UI.GetComponent<UImanager>();
    }
    void Update()
    {
        if (currentHealth <= 0) {anim.SetBool("isDead", true); UIscript.isdead=true;}

        healthBar.fillAmount = currentHealth/startingHealth;
    }
   
    // Update is called once per frame
    public void TakeDamage (float _dame) 
   {
        currentHealth -= _dame;
        if (currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
        }
        else {
            //healthBar.text = "HP" + currentHealth.ToString();
        }
        Sound.instance.PlayClip(Sound.instance.getHit, transform.position);
   }
}
