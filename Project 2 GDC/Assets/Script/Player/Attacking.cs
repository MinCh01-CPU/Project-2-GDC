using UnityEngine;
using UnityEngine.InputSystem;

public class Attacking : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enemyLayer;
    private Animator anim;
    public Transform attackPoint;

    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKey(KeyCode.J) && cooldownTimer > attackCooldown) 
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack ()
    {
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit enemy");
        }
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}
