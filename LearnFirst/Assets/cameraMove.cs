using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject ball;
    
    private Vector3 baseDistance; // взаимное расположение камеры и шарика
    
    // Start is called before the first frame update
    void Start()
    {
        baseDistance =  this.transform.position + new Vector3 (0, 0, 3);
        //baseDistance = this.transform.position; // запоминаем изначальное располож
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = ball.transform.position + baseDistance; // смещаем камеру вместе с шариком, то есть он в центре
    }
    void LateUpdate()
	{
        //transform.LookAt(); // - управление камерой
	}
}
