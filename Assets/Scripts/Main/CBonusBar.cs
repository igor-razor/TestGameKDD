//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using System;

public class CBonusBar : CSoundManager
{
    private GameObject[] goMbars = new GameObject[icountMax + 1];
    private static int icountMax = 5;
    private int icount = 0;

    private GameObject _goBonusPref;
    private float[] _Mminmax;

    // Start is called before the first frame update
    void Start()
    {
        goMbars[0] = gameObject;
        for (int i = 1; i <= icountMax; i++)
        {
            goMbars[i] = gameObject.transform.Find("bar" + System.Convert.ToString(i)).transform.gameObject;
            //Debug.Log(goMbars[i].name);
        }
    }// void Start()

    // Update is called once per frame
    //void Update()
    //{
    //
    //}// void Update()

    public void Finit(GameObject goBonusPref, float[] Mminmax)
    {
        _goBonusPref = goBonusPref;
        _Mminmax = Mminmax;
    }//public void Finit(GameObject goBonusPref)

    public void Finc()
    {
        if (icount < icountMax)
        {
            icount++;
            goMbars[icount].gameObject.SetActive(true);
            PlaySound(CS.MainAudio[(int)CS.M.a11scale],1,false,1.0f + ((float)icount)/10.0f);

            if (icount == icountMax)
            {
                // create bonus
                GameObject _goBonus = Instantiate(_goBonusPref);
                _goBonus.GetComponent<CMenuClick>().enabled = false;
                _goBonus.name = "GObonusUnit";
                _goBonus.transform.SetParent(gameObject.transform);
                _goBonus.GetComponent<CEnemyClick>().FinitBonus();
                _goBonus.transform.position = new Vector3(Random.Range(_Mminmax[1], _Mminmax[2] + 1.0f), _Mminmax[0], Random.Range(_Mminmax[3], _Mminmax[4] + 1.0f));

                Fclear();
            }//if (icount == icountMax)
        }//if (icount < icountMax)

    }//public void Finc()

    public void Fclear()
    {
        icount = 0;
        for (int i = 1; i <= icountMax; i++)
            goMbars[i].gameObject.SetActive(false);
    }//public void Fclear()

    public void FgetBonus()
    {
        gameObject.transform.parent.gameObject.GetComponent<CGameScore>().FgetBonusTime();
        Fclear();
    }

}//public class CBonusBar : MonoBehaviour
