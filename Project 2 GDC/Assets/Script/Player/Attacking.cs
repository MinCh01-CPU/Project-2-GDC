using UnityEngine;
using UnityEngine.InputSystem;

public class Attacking : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;
    [SerializeField] private Transform attackPoint;
    
    private LayerMask enemyLayer;
    private Animator anim;

    private float cooldownTimer;

    void Awake()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
    }
    void Start()
    {
        anim = GetComponent<Animator>();

        cooldownTimer = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKey(KeyCode.J) && cooldownTimer <= 0) 
        {
            Attack();
            cooldownTimer = attackCooldown;
            
        }

        cooldownTimer -= Time.deltaTime;

    }

    private void Attack ()
    {
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit enemy");
        }
        Sound.instance.PlayClip(Sound.instance.slash, transform.position);
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}
