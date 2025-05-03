using UnityEngine;
using UnityEngine.Rendering;

public class Health_Boar : Health_Enemy
{
    [SerializeField] private float Boar_Health;
    protected override void Start(){
        maxHealth=Boar_Health;
        base.Start();
    }
    public override void TakeDamage(float Damage){
        base.TakeDamage(Damage);
        if (animator != null)
        {
            animator.SetTrigger("Get Hit");  // Gọi animation "Get Hit"
        }
        Move_Boar move_Boar=GetComponent<Move_Boar>();
        if(move_Boar!=null){
            move_Boar.TakeDamageReaction();
        }
    }
}
