using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float Enemy_dmg;
    [SerializeField] private float Enemy_cd;
    private float lastTime = 0f;
    private bool isTouch=false;
    public Transform _player;
    public Animator animator;
    public GameObject Enemy_Prefab;
    public BoxCollider2D SummonArena;
    public int Max_Enemy;
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            isTouch=true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            isTouch=false;
        }
    }
    void attack(){
            summon();
            animator.SetBool("Attack",true);
            Health hp=_player.GetComponent<Health>();
            if(hp!=null){
                hp.TakeDamage(Enemy_dmg);
            }   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isTouch && Time.time-lastTime>=Enemy_cd){
                attack();
                lastTime=Time.time;
            }
            else{
                animator.SetBool("Attack",false);
            }
    }
    public void summon(){
        for(int i=0; i<Max_Enemy; i++){
            Vector2 spawnPos=GetRandom(SummonArena.bounds);
            Instantiate(Enemy_Prefab,spawnPos,Quaternion.identity);
            Debug.Log("Đã Summon");
        }
    }
    Vector2 GetRandom(Bounds bounds){
        return new Vector2(
            Random.Range(bounds.min.x,bounds.max.x),
            Random.Range(bounds.min.y,bounds.max.y)
        );
    }
}
