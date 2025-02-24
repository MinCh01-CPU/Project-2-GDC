using UnityEngine;

public class rope : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {   
            Vector3 pivot =new Vector3(-1,1,0);
            transform.RotateAround(pivot,Vector3.forward,25*Time.deltaTime);
        }
    }
    
}
