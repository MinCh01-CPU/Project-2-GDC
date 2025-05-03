using UnityEngine;

public class Camcontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform character;

    void Awake()
    {
        transform.position = character.position + new Vector3(0,0,-9);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position= character.position + new Vector3(0,0,-9);
    }
    
}
