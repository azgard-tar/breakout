using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveArrow : MonoBehaviour
{

    private GameObject arrow;
    public Image img;
    public static Vector3 target;
    public static float angle;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("row");
        target = new Vector3(-0.41f, 15.03f, -7.76f);
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (angle < 80f)
            {
                angle++;
                transform.RotateAround(target, Vector3.up, 1f);
            }
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (angle > -80f)
            {
                angle--;
                transform.RotateAround(target, Vector3.up, -1f);
            }
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            moveSphere.force -= 1f;
            img.fillAmount -= 0.01f;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveSphere.force += 1f;
            img.fillAmount += 0.01f;
        }
    }
}
