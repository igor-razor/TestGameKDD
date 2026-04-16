//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CEnemyClick : CSoundManager, IPointerClickHandler
{
    public GameObject goBoomPref;

    private int _Border = 0; // start border - 0 (-1) = left, 1 = rigth
    private float _Speed = 10.0f;
    private float SpeedMin = 1.0f;
    private float SpeedMax = 100.0f;
    private float DestroyDelay = 2.0f;
    private GameObject goRotor = null;

    private float _Xmin = 0f;
    private float _Xmax = 0f;
    
    private float StereoEscape = 0.8f;

    private bool flag_click = true;

    private GameObject _goBar;

    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        if (flag_click == true) { Fclick(); }
    }//public void OnPointerClick(PointerEventData eventData)

    // Start is called before the first frame update
    void Start()
    {
        //if (gameObject.name.Contains("bonus"))
       // {
       //     PlaySound(sounds[1]);
       //     Debug.Log("bonus create");
       // }
        //goRotor = gameObject.transform.Find("Rotor").transform.gameObject;
    }//void Start()

    // Update is called once per frame
    void Update()
    {
        //if (flag_click == true)
            if (_Border != 0)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + Vector3.right*(-_Border), _Speed * Time.deltaTime);
            }

        if (flag_click == false)
            if (_Border == 0)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + Vector3.down, _Speed * Time.deltaTime);
            }
    }//void Update()

    public float FlocalCoord()
    {
        float Xg = gameObject.transform.position.x;
        return (2 * (Xg - _Xmin) / (_Xmax - _Xmin)) - 1;
    }

    private void Fclick()
    {
        flag_click = false;

        PlaySound(CS.MainAudio[(int)CS.M.a04hit]);

        //gameObject.GetComponent<CEnemyClick>().enabled = false;
        _Border = 0;        
        //Debug.Log(gameObject.name);
        Destroy(gameObject, DestroyDelay);
        if (goRotor != null)
        {
            goRotor.GetComponent<CRotor>().FsetSpeedRotor(SpeedMin);
            goRotor.GetComponent<AudioSource>().Stop();
        }

        _goBar.gameObject.GetComponent<CBonusBar>().Finc();
        gameObject.transform.parent.gameObject.GetComponent<CGameScore>().FIncScore(1);
        gameObject.transform.parent.gameObject.GetComponent<CMain>().FremoveElement(gameObject);

        GameObject goBoom = Instantiate(goBoomPref);
        goBoom.name = "goBoom";
        //goBoom.transform.SetParent(gameObject.transform);
        goBoom.transform.position = gameObject.transform.position;
    }//private void Fclick()


    private void OnTriggerEnter(Collider other) // enter border
    {
        if (other.gameObject.name.Contains("Border") == true)
            if (flag_click == true)
            {
                flag_click = false;

                if (other.gameObject.name.Contains("Left") == true)
                {
                    gameObject.GetComponent<AudioSource>().panStereo = -StereoEscape;
                }
                else
                {
                    gameObject.GetComponent<AudioSource>().panStereo = StereoEscape;
                }

                StopSound();
                PlaySound(CS.MainAudio[(int)CS.M.a08enemyescape],2.0f);
                
                //_Border = 0;
                //gameObject.GetComponent<CEnemyClick>().enabled = false;
                //Debug.Log("border");
                _Speed = SpeedMax;
                Destroy(gameObject, DestroyDelay);
                if (goRotor != null) { goRotor.GetComponent<CRotor>().FsetSpeedRotor(_Speed); }
                gameObject.transform.parent.gameObject.GetComponent<CGameScore>().FIncScore(-1);
                gameObject.transform.parent.gameObject.GetComponent<CMain>().FremoveElement(gameObject);
            }
    }//private void OnTriggerEnter(Collider other)

    public void Finit(int border, float speed, GameObject goBar, float xmin, float xmax)
    {
        _Border = border;
        _Speed = speed;
        _goBar = goBar;
        goRotor = gameObject.transform.Find("Rotor").transform.gameObject;
        if (goRotor != null) { goRotor.GetComponent<CRotor>().FsetSpeedRotor(_Speed); }
        flag_click = true;

        _Xmax = xmax;
        _Xmin = xmin;
    }
    public void FsetSpeed(float speed) { _Speed = speed; }

    public void FinitBonus()
    {
        gameObject.GetComponent<CEnemyClick>().enabled = false;
        gameObject.GetComponent<CBonusClick>().enabled = true;
        gameObject.GetComponent<CBonusClick>().Finit();

        PlaySound(CS.MainAudio[(int)CS.M.a06bonuscoming], 2);
    }//public void FinitBonus()
}//public class CEnemyClick : MonoBehaviour, IPointerClickHandler
