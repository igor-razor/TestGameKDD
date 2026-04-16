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

        // foreach (AudioClip audio in CS.MainAudio) { Debug.Log(audio.name); }

        //Debug.Log(CS.MainAudio);
        //throw new NotImplementedException();

        Material mat1 = new Material(Shader.Find("Specular"));
        mat1.color = Color.yellow;
        gameObject.GetComponent<MeshRenderer>().material = mat1;
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
} //public class CMenuClick : CSoundManager, IPointerClickHandler

