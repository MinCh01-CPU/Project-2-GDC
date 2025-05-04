using UnityEngine;
using UnityEngine.Rendering;

public class Health_Bee : Health_Enemy
{
    [SerializeField] private float Bee_Health;
    protected override void Start(){
        maxHealth=Bee_Health;
        base.Start();
    }
    public override void TakeDamage(float Damage){
        base.TakeDamage(Damage);
        if (animator != null)
        {
            animator.SetTrigger("Get Hit");  // Gọi animation "Get Hit"
        }
        Move_Bee move_Bee=GetComponent<Move_Bee>();
        if(move_Bee!=null){
            move_Bee.TakeDamageReaction();
        }
    }
}
