using UnityEngine;
using System.Collections;
public class Move_Snail : MonoBehaviour
{
    [SerializeField] private float Enemy_spd;
    [SerializeField] private float circleRadius; 
    [SerializeField] private float patrolRange;
    private bool isGround=true;
    public GameObject groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D _rb;
    private Vector2 StartPoint;
    private bool directRight=false;
    public Animator animator;
    private void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
        StartPoint=transform.position;
    }
    private void Start(){

        StartCoroutine(Patrol());
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
        yield return new WaitForSeconds(1f);
        _rb.linearVelocity = Vector2.zero;
            // Di chuyển đến khi vượt khỏi phạm vi tuần tra
            while (Mathf.Abs(transform.position.x - StartPoint.x) <= patrolRange)
            {
                move();
                yield return null;
            }

            // Đã tới giới hạn → dừng và đợi
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
}
