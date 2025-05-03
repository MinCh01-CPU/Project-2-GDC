using UnityEngine;

public class Health_Snail : Health_Enemy
{
    [SerializeField] private float Snail_Health;
    protected override void Start(){
        maxHealth=Snail_Health;
        base.Start();
    }
    public override void TakeDamage(float Damage){
        base.TakeDamage(Damage);
        if (animator != null)
        {
            animator.SetTrigger("Get Hit");  // Gọi animation "Get Hit"
        }
    }
}
