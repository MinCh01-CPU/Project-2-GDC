using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float Enemy_spd;
    [SerializeField] private float circleRadius; 
    private Rigidbody2D _rb;
    private Aware _aware;
    private bool directRight=false;
    private bool isGround=true;
    public Transform _player;
    public GameObject groundCheck;
    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
        _aware=GetComponent<Aware>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_aware.AwareOfPlayer){
            move();
        }
        else{
            Patrol();
        }
    }
    void move()
    {
        if(_player.position.x>transform.position.x){
            if(!directRight)Flip();
        }
        else{
            if(directRight)Flip();     
        }
        _rb.linearVelocityX=-Enemy_spd;
    }
    void Flip(){
        directRight=!directRight;
        Enemy_spd=-Enemy_spd;
        Vector2 scale= transform.localScale;
        scale.x *=-1;
        transform.localScale=scale;
    }
    void Patrol(){
        _rb.linearVelocityX=-Enemy_spd;
        isGround=Physics2D.OverlapCircle(groundCheck.transform.position,circleRadius,groundLayer);
        if(!isGround){Flip();}
    }
}
