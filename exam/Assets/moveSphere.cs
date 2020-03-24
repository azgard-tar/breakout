using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveSphere : MonoBehaviour
{

    public static float force;
    private Rigidbody ball;
    public static Vector3 startPos;
    

    // Start is called before the first frame update
    void Start()
    {
        force = 50f;
        ball = this.GetComponent<Rigidbody>();
        startPos = ball.transform.position;
        //ballVect.z += 3f;
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetKey(KeyCode.Space));
        if( Input.GetKey( KeyCode.Space ) )
        {
            ball.AddForce(// время // коеф силы
                new Vector3(
                    Mathf.Sin(moveArrow.angle * Mathf.PI / 180 ),
                    0,
                    Mathf.Cos(moveArrow.angle * Mathf.PI / 180)
                    ) * force
            ); 
        }
    }

}
