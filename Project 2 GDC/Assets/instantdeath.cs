using UnityEngine;

public class instantdeath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    private Health hp;
    private Collider2D playercollider;
    void Start()
    {
        hp=player.GetComponent<Health>();
        playercollider=player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D playercollision)
    {
        if(this.name=="spike")hp.TakeDamage(1f); 
        else hp.TakeDamage(999999999999999999.0f); 
    }
}
