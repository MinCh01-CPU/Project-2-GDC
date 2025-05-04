using UnityEngine;
using System.Collections;
public class Move_Snail : MonoBehaviour
{
    [SerializeField] private float Enemy_spd;
    [SerializeField] private float circleRadius; 
    [SerializeField] private float patrolRange;
    [SerializeField] private float hurtDuration;
    private bool isGround=true;
    private bool isHurt=false;
    public GameObject groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D _rb;
    private Vector2 StartPoint;
    private bool directRight=false;
    public Animator animator;
    private Coroutine patrolCoroutine;
    private void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
        StartPoint=transform.position;
    }
    private void Start(){

        patrolCoroutine = StartCoroutine(Patrol());
    }
    void FixedUpdate()
    {
        checkGround();     
    }
    private IEnumerator Patrol()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
        animator.SetBool("Walk",true);
        animator.SetBool("Hide",false);
        yield return new WaitForSeconds(1f);
        _rb.linearVelocity = Vector2.zero;
            // Di chuyển đến khi vượt khỏi phạm vi tuần tra
            while (Mathf.Abs(transform.position.x - StartPoint.x) <= patrolRange)
            {
                move();
                yield return null;
            }
            // Đã tới giới hạn → dừng và đợi
            animator.SetBool("Walk",false);
            animator.SetBool("Hide",true);
            yield return new WaitForSeconds(3f);
            // Quay đầu và lặp lại
            Flip();
        }
    }
    void Flip(){
        directRight=!directRight;
        Vector2 scale= transform.localScale;
        scale.x *=-1;
        transform.localScale=scale;
        StartPoint = transform.position;
    }
    void move(){
        if(!directRight){
            _rb.linearVelocityX=-Enemy_spd;
        }
        else{
            _rb.linearVelocityX=Enemy_spd;
        }
    }
    void checkGround(){
        isGround=Physics2D.OverlapCircle(groundCheck.transform.position,circleRadius,groundLayer);
        if(!isGround){
            Flip();
        }
    }
    public void TakeDamageReaction(){
        
        if (!isHurt){
            StopAllCoroutines();
            StartCoroutine(Hide());
            _rb.linearVelocity=Vector2.zero;
        }
    }
    private IEnumerator Hide(){
        isHurt = true;
        Debug.Log("TakeDamageReaction called");
        animator.SetBool("Walk",false);
        animator.SetBool("Hide",true);
        _rb.linearVelocity=Vector2.zero;
        yield return new WaitForSeconds(hurtDuration); // khoảng choáng
        isHurt = false;
        patrolCoroutine = StartCoroutine(Patrol());
    }
}
