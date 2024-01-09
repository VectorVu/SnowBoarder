using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 3f;
    Rigidbody2D rd2d;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            rd2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow)) 
        {
            rd2d.AddTorque(-torqueAmount);
        }
    }
}
