using UnityEngine;
using UnityEngine.Rendering;

public class Summon_Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    protected float Health;
    protected Animator animator;
    protected void Start(){
        Health=maxHealth;
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float Damage){
        Health-=Damage;
        if (animator != null)
        {
            animator.SetTrigger("Get Hit");  // Gọi animation "Get Hit"
        }
        Summon_Move summon_Move=GetComponent<Summon_Move>();
        if(summon_Move!=null){
            summon_Move.TakeDamageReaction();
        }
    }
    void Update()
    {
        if(Health<=0){
            Destroy(gameObject);
        }
    }
}
