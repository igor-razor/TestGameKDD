//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CRotor : CSoundManager
{
    [SerializeField]
    private float _rot_speed = 5.0f;
    private float mult = 2.0f;
    private float del = 8.0f;

    private float StereoRotor = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        PlaySound(CS.MainAudio[(int)CS.M.a07enemyfly], 0.1f, true, _rot_speed/del);
    }//void Start()

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _rot_speed, 0);
        float Xlocal = gameObject.transform.parent.gameObject.GetComponent<CEnemyClick>().FlocalCoord();
        gameObject.GetComponent<AudioSource>().panStereo = StereoRotor * Xlocal;
    }

    public void FsetSpeedRotor(float rot_speed) { _rot_speed = rot_speed * mult; }

}//public class Rotor : MonoBehaviour
