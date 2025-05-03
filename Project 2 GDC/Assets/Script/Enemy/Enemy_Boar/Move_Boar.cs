using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;
using System.Collections;

public class Move_Boar : MonoBehaviour
{
    [SerializeField] private float Enemy_spd;
    [SerializeField] private float circleRadius; 
    [SerializeField] private float patrolRange; 
    private Rigidbody2D _rb;
    private Aware_Boar _aware;
    private bool directRight=false;
    private bool isGround=true;
    private bool isChasing;
    private bool isHurt;
    private Vector2 StartPoint;
    public Transform _player;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
        _aware=GetComponent<Aware_Boar>();
        StartPoint=transform.position;

    }
    private void Start(){
        StartCoroutine(Patrol());
    }
    void FixedUpdate()
    {
        checkGround();     
    }
    void walk(){
        animator.SetBool("Walk",true);
        _rb.linearVelocityX=-Enemy_spd;
    }
    void idie(){
        animator.SetBool("Walk",false);
        animator.SetBool("Run",false);
    }
    void Run()
    {
        animator.SetBool("Walk",false);
        animator.SetBool("Run",true);
            animator.SetBool("Run",true);
            if(_player.position.x<transform.position.x){
                if(!directRight)Flip();
            }
            else{
                if(directRight)Flip();     
            }
            _rb.linearVelocityX=-Enemy_spd;
    }
    void Hit(){
        animator.SetBool("Hit",true);
    }
    void Flip(){
        directRight=!directRight;
        Enemy_spd=-Enemy_spd;
        Vector2 scale= transform.localScale;
        scale.x *=-1;
        transform.localScale=scale;
        StartPoint = transform.position;
    }
    private IEnumerator Patrol()
    {
        while (true)
        {
            // Di chuyển đến khi vượt khỏi phạm vi tuần tra
            while (Mathf.Abs(transform.position.x - StartPoint.x) <= patrolRange)
            {
                walk();
                yield return null;
            }

            // Đã tới giới hạn → dừng và đợi
            idie();
            yield return new WaitForSeconds(3f);

            // Quay đầu và lặp lại
            Flip();
        }
    }
    void checkGround(){
        isGround=Physics2D.OverlapCircle(groundCheck.transform.position,circleRadius,groundLayer);
        if(!isGround){
            Flip();
            }
    }
    public void TakeDamageReaction(){
        if (!isChasing){
            StopAllCoroutines();
            isChasing=true;
            StartCoroutine(RunAway());
        }
    }
    private IEnumerator RunAway(){
        while(_aware.AwareOfPlayer){
            Run();
            yield return null;
        }
        isChasing = false;
        idie();
        yield return new WaitForSeconds(2f);
        StartCoroutine(Patrol());
    }
}
