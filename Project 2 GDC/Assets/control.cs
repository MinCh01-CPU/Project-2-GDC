using UnityEngine;
using UnityEngine.Tilemaps;

public class control : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer sp;
    private Collider2D hivewall;
    private Collider2D bosswall;
    public Sprite jungle;
    public Sprite sky;
    public Tilemap hive;
    public Tilemap boss;
    Vector2 force= new (0,200);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid=this.GetComponent<Rigidbody2D>() ;
        hivewall=hive.GetComponent<Collider2D>() ;
        bosswall=boss.GetComponent<Collider2D>() ;
        sp=transform.Find("Background").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)) transform.position+=(new Vector3 (2,0,0))*Time.deltaTime;
        if(Input.GetKey(KeyCode.A)) transform.position+=(new Vector3 (-2,0,0))*Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))  rigid.AddForce(force);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="jungle") sp.sprite=jungle;
        if(collision.name=="bridge") sp.sprite=sky;
        if(collision.name=="dark") sp.color=new Color(sp.color.r-0.25f,sp.color.g-0.25f,sp.color.b-0.25f); 
        if(collision.name=="dark1") sp.color=new Color(sp.color.r-0.1f,sp.color.g-0.1f,sp.color.b-0.1f); 
        if(collision.name=="hivetrigger") {hivewall.isTrigger=false;hive.transform.position=new Vector3(0.135f,0.075f,-2);}
        if(collision.name=="bosstrigger") {bosswall.isTrigger=false;boss.transform.position=new Vector3(0.135f,0.075f,-2);}
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name=="jungle") collision.isTrigger=false;
    }

} 
