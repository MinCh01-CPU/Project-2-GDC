using System.Linq.Expressions;
using UnityEngine;

public class Health_Enemy : MonoBehaviour
{
    protected float maxHealth;
    protected float Health;
    protected Animator animator;
    protected virtual void Start()
    {
        Health = maxHealth;
        animator = GetComponent<Animator>();
    }
    public virtual void TakeDamage(float Damage){
        Health-=Damage;
        if(Health<=0){
            Destroy(gameObject);
        }
    }
}
