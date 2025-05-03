using UnityEngine;

public class Camcontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject character;
    private Transform charTrans;

    void Start()
    {
        charTrans=character.GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position=charTrans.position+new Vector3(0,0,-9);
    }
    
}
