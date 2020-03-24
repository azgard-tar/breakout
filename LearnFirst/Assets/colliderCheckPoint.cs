using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class colliderCheckPoint : MonoBehaviour
{

    public static int winTime = 40, score;
    public static Color winColor;
    public static int[] normal_time;
    public static Color[] colors;
    public static bool[] status;
    public static bool rest;
    private Vector3 firstCheckPointPos, secondCheckPointPos, thirdCheckPointPos;
    private GameObject chp1, chp2, chp3;

    // Start is called before the first frame update
    void Start()
    {
        normal_time = new int[] { 5, 11, 20 };

        // Стандартная позиция чекпоинтов
        firstCheckPointPos = new Vector3(1f, 0.3f, 1f);
        secondCheckPointPos = new Vector3(-4.3f, 0.3f, 2f);
        thirdCheckPointPos = new Vector3(-0.1f, 0.3f, -2.5f);

        // Берём наши чекпоинты
        chp1 = GameObject.Find("checkPoint");
        chp2 = GameObject.Find("checkPoint1");
        chp3 = GameObject.Find("checkPoint2");

        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (rest)
            Restart();
    }

    void OnTriggerEnter( Collider other )
    {
        for( int i = 0; i < 3; i++ ) {
            if(other.gameObject.name.Equals( "checkPoint" + (i == 0 ? "" : i+"" ) ) && status[i])
            {
                helloCheckPoint(ref other, ref ballMove.chp[i]); // hide check point
                setScore(ballMove.tim, normal_time[i], ref colors[i], ref status[i+1]);
            }
        }
        if( other.gameObject.name.Equals("win") && status[3] )
		{
            setScore(ballMove.tim, winTime, ref winColor, ref ballMove.win);
            using (StreamWriter sw = new StreamWriter(ballMove.PATH_TO_SCORE_FILE, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + "," + ballMove.chp[0] + "," + ballMove.chp[1] + "," + ballMove.chp[2] + "," + Math.Round(ballMove.tim, 1));
            }
        }

    }

    void helloCheckPoint( ref Collider check, ref float yourTime )
    {
        check.transform.Translate(Vector3.down * 3); // Vector3.down - константа для економии ресурсов
        yourTime = (float)Math.Round(ballMove.tim, 1);
    }

    void setScore( float whatComp, float withComp, ref Color yourClr, ref Boolean forTrue )
    {
        forTrue = true;
        if (whatComp > withComp * 1.5)
        {
            score += 1;
            yourClr = Color.red;
        }
        else if (whatComp > withComp * 1.2)
        {
            score += 2;
            yourClr = Color.magenta;
        }
        else if (whatComp > withComp)
        {
            score += 3;
            yourClr = Color.yellow;
        }
        else
        {
            score += 4;
            yourClr = Color.green;
        }
    }

    void Restart()
    {
        // Инициализируем массивы
        colors = new Color[] { Color.white, Color.white, Color.white };
        status = new bool[] { true, false, false, false };
        rest = false;

        score = 0;

        // Ставим на место наши чекпоинты
        chp1.transform.position = firstCheckPointPos;
        chp2.transform.position = secondCheckPointPos;
        chp3.transform.position = thirdCheckPointPos;

    }

}
