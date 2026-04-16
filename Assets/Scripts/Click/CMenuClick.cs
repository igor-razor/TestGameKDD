using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CMenuClick : CSoundManager, IPointerClickHandler
{
    public GameObject _goMain = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name);
        CS.MainAudio = Resources.LoadAll<AudioClip>("Sounds/" + gameObject.name);
        PlaySound(CS.MainAudio[(int)CS.M.a00startgame]);
        // foreach (AudioClip audio in CS.MainAudio) { Debug.Log(audio.name); }

        //Debug.Log(CS.MainAudio);
        //throw new NotImplementedException();

        if (clicked == false)
        {
            //Debug.Log("click");
            clicked = true;
            timer = timer_max;
            //Material mat1 = new Material(Shader.Find("Specular"));
            mat1.color = Color.yellow;
            gameObject.GetComponent<MeshRenderer>().material = mat1;
        }
    }

    private Material mat1 = null;
    private bool clicked = false;
    private float timer = 0;
    private float timer_max = 2;

    // Start is called before the first frame update
    void Start()
    {
        mat1 = new Material(Shader.Find("Specular"));
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked == true)
        {
            timer -= Time.deltaTime;
            //Debug.Log(timer);
            if (timer <= 0)
            {
                clicked = false;
                mat1.color = Color.gray;
                gameObject.GetComponent<MeshRenderer>().material = mat1;
            }

        }    
    }
} //public class CMenuClick : CSoundManager, IPointerClickHandler

