using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ballMove : MonoBehaviour
{
    public static string PATH_TO_SCORE_FILE = "result.txt";

    private Rigidbody ball3d;
    private const float forceModule = 100f;

    //float prevX = 0f, prevZ = 0f;
    public static float tim, waitingTime;
    public static float[] chp, highChp;

    public static bool win, activeWait;
    public static List<String[]> scores;

    public Vector3 ballPos;

    public Text textTime;
    public Text ch1;
    public Text ch2;
    public Text ch3;
    public Text[] textCheckPoint;
    public Text textScore;
    public Text waitText;

    // Start is called before the first frame update
    void Start()
    {
        // prevX = this.transform.position.x; // скорость
        // prevZ = this.transform.position.z;

        ball3d = this.GetComponent<Rigidbody>(); // наш шарик
        ballPos = new Vector3(4.2f, 0.3f, 4f);

        setStart();

    }

    // Update is called once per frame
    void Update() // вызывается с периодом deltaTime, зависит от тяжести вычислений
    {
        // Скорость
        // text.text = (prevX - this.transform.position.x) / Time.deltaTime + ", " + (prevZ - this.transform.position.z) / Time.deltaTime;
        // prevX = this.transform.position.x;
        // prevZ = this.transform.position.z;

        // Движение шарика
        ball3d.AddForce(
            Time.deltaTime * // время
            forceModule * // коеф силы
            new Vector3( // направление
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")
            )
        );
    }

    void LateUpdate()
	{
        if (!win)
        {
            tim += Time.deltaTime; // собираем время
            textTime.text = String.Format("{0:0.0}", tim); // ставим время

            for( int i = 0; i < 3; i++ )
            {
                textCheckPoint[i].text = "Check point " + ( i + 1 ) + ": " + // номер чекпоинта
                    ((chp[i] == 0f) ? "--" : chp[i] + // значение чекпоинта отсуствует ? да : нет
                    " c( the best " + highChp[i] + " c)"); // добавляем лучший результат
                textCheckPoint[i].color = colliderCheckPoint.colors[i];
            }
            textScore.text = "Score: " + colliderCheckPoint.score;


        }
        else
		{
            waitingTime -= Time.deltaTime;
            waitText.text = String.Format("Рестарт игры через: {0:0.0}", waitingTime);
            if ( ! activeWait) // входит один раз, запускает ожидание 5 сек
            {
                textTime.text = String.Format("Win!!! Your time {0:0.0} c ( the best {1} c)",tim, highChp[3]); // Победа!
                textTime.color = colliderCheckPoint.winColor;
                activeWait = true;
            }
            if( waitingTime < 0.1f ) // рестарт
            {
                colliderCheckPoint.rest = true; // Запуск рестарта в том скрипте
                setStart(); // Запуск рестарта тут
            } 
		}

    }

    void setStart()
    {
        // Инициализируем наши массивы 
        chp = new float[] { 0f, 0f, 0f }; // наше время прохождение чекпоинтов
        highChp = new float[] { 1000f, 1000f, 1000f, 1000f }; // рекорд
        textCheckPoint = new Text[3] { ch1, ch2, ch3 }; //  тексты 

        win = activeWait = false; // победа и ожидание после победы
        tim = 0f;
        waitingTime = 5f;

        waitText.text = "";

        textTime.color = Color.white;
        textScore.text = "Score: 0";

        // Ставим шарик на место
        ball3d.transform.position = ballPos;

        // Считываем рекорды с файла
        scores = new List<String[]>();
        if (File.Exists(PATH_TO_SCORE_FILE))
        {
            using (StreamReader sr = new StreamReader(PATH_TO_SCORE_FILE, System.Text.Encoding.Default)) // построчно 
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    scores.Add(line.Split(',')); // добавляем в список
            }
        }
        // Устанавливаем значение рекорда
        if (scores.Count > 0)
        {
            for (int i = 0; i < scores.Count; i++)
                for (int j = 1; j < scores[i].Length; j++)
                    if (highChp[j - 1] > float.Parse(scores[i][j])) highChp[j - 1] = float.Parse(scores[i][j]);
        }
    }
}
