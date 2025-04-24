using UnityEngine;

public class control : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer sp;
    public Collider2D collision;
    public Sprite jungle;
    Vector2 force= new (0,200);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid=GetComponent<Rigidbody2D>() ;
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
       sp.sprite=jungle;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        collision.isTrigger=false;
    }
}
