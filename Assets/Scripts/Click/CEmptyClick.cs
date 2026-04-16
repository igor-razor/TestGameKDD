//using System.Collections;
//using System.Collections.Generic;
//using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CEmptyClick : CSoundManager, IPointerClickHandler
{
    //public bool game_play = false;

    public GameObject goMain = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("miss");
        //throw new NotImplementedException();
        //  gameObject.transform.parent.gameObject.GetComponent<CGameScore>().FIncScore(-1);


        ///GameObject goMain = gameObject.transform.parent.gameObject;

        if (goMain.transform.Find("GObonusBar") == true) { goMain.transform.Find("GObonusBar").gameObject.GetComponent<CBonusBar>().Fclear(); }

        goMain.GetComponent<CGameScore>().FIncScore(-1);

        //if (game_play == false)
        //{
        //    game_play = true;
        //}
        //else
        //{ 
           // PlaySound(sounds[0]);
        //}

        if (gameObject.name.Contains("Cube"))
        {
            PlaySound(CS.MainAudio[(int)CS.M.a02missground]);
        }
        else
        {
            PlaySound(CS.MainAudio[(int)CS.M.a03misswater]);
        }
    }// public void OnPointerClick(PointerEventData eventData)

    //public void Fstart() { game_play = false; }

    // Start is called before the first frame update
    void Start()
    {
        //game_play = false;
        goMain = gameObject.transform.parent.gameObject;

        if (gameObject.name.Contains("unit"))
        {
            goMain = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        }
        if (gameObject.name.Contains("Cube"))
        {
            goMain = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        }
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    
    //}
}//public class CEmptyClick : MonoBehaviour
