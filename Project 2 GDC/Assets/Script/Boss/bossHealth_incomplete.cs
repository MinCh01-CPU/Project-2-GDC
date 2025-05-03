using UnityEngine;

public class bossHealth_incomplete : MonoBehaviour
{

///////////////////////////////////////////   todo: làm máu cho con boss , mới làm màn hình win thôi -- "Thịnh"

    private int hp_temp=1;
    public GameObject UI;
    private UImanager script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        script=UI.GetComponent<UImanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp_temp<=0) script.victory=true;
    }
}
