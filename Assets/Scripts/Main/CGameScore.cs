//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class CGameScore : CSoundManager
{
    //public Text textScore;
    GUIStyle style = new GUIStyle();
    private static float timerBorder = 5.0f;
    private static float timerStart = 30.5f;
    private float timer = timerStart;
    private int itimer = 0;
    private int itimerEnd = -1;
    private string sTimer = "";
    private float incTimer = 3.0f;
    private float timer1 = 0.0f;
    private static int iScoreStart = 10;
    private int iScore = iScoreStart;

    private bool game_play = false;
    private bool timer5_flag = false;

    private void Finit()
    {
        timer = timerStart;
        iScore = iScoreStart;
        game_play = true;
    }//private void Finit()

    void Start()
    {
        style.normal.textColor = Color.yellow;
        style.fontSize = 24;
        style.fontStyle = FontStyle.Bold;
    }

    void OnGUI()
    {
        if (game_play == true)
        {
            GUI.Label(new Rect(5, 0, 100, 34), "SCORE " + iScore + "\nTIME " + sTimer, style);
        }

        if (game_play == false)
        {
            GUI.Label(new Rect(5, 0, 100, 34), "CLICK TO START", style);
        }

     }//void OnGUI()

    void FixedUpdate()
    {
        if (game_play == true)
        {
            timer -= Time.deltaTime;
            itimer = (int)timer;
            //sTimer = timer.ToString("0.###");
            sTimer = itimer.ToString();

            if (timer5_flag == true)
            {
                timer1 += Time.deltaTime;
                if (timer1 > 1) { timer5_flag = false; }
            }

            if ((itimer <= timerBorder) && (timer5_flag == false))
            {
                timer5_flag = true;
                timer1 = 0.0f;
                PlaySound(CS.MainAudio[(int)CS.M.a12timer]);
            }

            if (itimer <= itimerEnd)
            {
                //Debug.Log("Game Over");
                game_play = false;
                sTimer = "0";
                gameObject.GetComponent<CMain>().Fstop();
                PlaySound(CS.MainAudio[(int)CS.M.a01gameover]);
                PlaySound(CS.MainAudio[(int)CS.M.a09musicmenu], 0.75f, true, 1.0f, CS.MainAudio[(int)CS.M.a01gameover].length + 0.1f);

                gameObject.GetComponent<CMain>().FloadMusic();
            }
        }
    }//void FixedUpdate()

    public void FgetBonusTime()
    {
        timer += incTimer;
        PlaySound(CS.MainAudio[(int)CS.M.a05bonusclick]);
    }

    public void FIncScore(int i)
    {
        bool flag = false;

        if (flag == false)
            if (game_play == false)
            {
                gameObject.GetComponent<CMain>().FclearListMusicBots();

                flag = true;
                Finit();
                gameObject.GetComponent<CMain>().Fstart();
                gameObject.GetComponent<AudioSource>().Stop();
                PlaySound(CS.MainAudio[(int)CS.M.a00startgame]);
                PlaySound(CS.MainAudio[(int)CS.M.a10musicgame], 1.25f, true, 1.0f, CS.MainAudio[(int)CS.M.a00startgame].length + 0.1f);
            }//if (game_play == false)

        if (flag == false)
            if (game_play == true)
            {
                flag = true;
                iScore += i;
                if (iScore <= 0)
                {
                    game_play = false;
                    gameObject.GetComponent<CMain>().Fstop();
                    gameObject.GetComponent<AudioSource>().Stop();
                    PlaySound(CS.MainAudio[(int)CS.M.a01gameover]);
                    PlaySound(CS.MainAudio[(int)CS.M.a09musicmenu], 0.75f, true, 1.0f, CS.MainAudio[(int)CS.M.a01gameover].length + 0.1f);

                    gameObject.GetComponent<CMain>().FloadMusic();
                }
            }//if (game_play == true)
    }//public void FIncScore(int i)

}//public class CGameScore : MonoBehaviour
