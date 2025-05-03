using UnityEngine;

public class bossHealth_incomplete : MonoBehaviour
{

///////////////////////////////////////////   todo: làm máu cho con boss , mới làm màn hình win thôi -- "Thịnh"

    public GameObject UI;
    private UImanager script;
    [SerializeField]private float maxHealth;
    private float Health;
    protected Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        script=UI.GetComponent<UImanager>();
        Health = maxHealth;
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float Damage){
        Health-=Damage;
        if(Health<=0){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<=0) script.victory=true;
    }
}
