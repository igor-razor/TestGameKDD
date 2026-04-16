//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CMain : MonoBehaviour
{

    public GameObject goEnemyPref;
    public Camera targetCamera;
    public GameObject goBarPref;
    private GameObject _goBar = null;

    private static float Yfly = 4.0f;
    private static float Xmin = -2.0f;
    private static float Xmax = 43.0f;
    private static float Zmin = -1.0f;
    private static float Zmax = 42.0f;
    private static float SpeedMin = 5.0f;
    private static float SpeedMax = 10.0f;

    private float[] Mminmax = { Yfly, Xmin, Xmax, Zmin, Zmax };
    private float timer = 0.0f;
    private float timer_rnd = 0.0f;
    private float timer_rndMax = 2.0f;

    private bool game_play = false;

    private List<GameObject> Lbots = new List<GameObject>();
    private List<GameObject> Lpacks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        FloadPrefabs();
        goEnemyPref = CS.Mprefabs[(int)CS.P.p02enemy];
        goBarPref = CS.Mprefabs[(int)CS.P.p03bonusbar];
        FloadMusic();
        //FcreateBonusBar();
        gameObject.GetComponent<CMainLand>().FLandGen();
        //for (int i=0;i<5;i++)
        //FcreateEnemy(Random.Range(0,2),Random.Range(Zmin,Zmax+1.0f),Random.Range(SpeedMin,SpeedMax+1));
        
    }//void Start()

    // Update is called once per frame
    void Update()
    {
        if (game_play == true)
        {
            timer += Time.deltaTime;
            if (timer >= timer_rnd)
            {
                FcreateEnemy(Random.Range(0, 2), Random.Range(Zmin, Zmax + 1.0f), Random.Range(SpeedMin, SpeedMax + 1));
                timer = 0.0f;
                timer_rnd = Random.Range(0, timer_rndMax);
                //timer_rnd = timer_rndMax;
            }
        }

        //if (game_play == false) { FclearList(); }
    }//void Update()
    
    private void FcreateBonusBar()
    {
        _goBar = Instantiate(goBarPref);
        _goBar.name = "GObonusBar";
        _goBar.transform.SetParent(gameObject.transform);
        _goBar.GetComponent<CBonusBar>().Finit(goEnemyPref, Mminmax);
    }//private void FcreateBonusBar()

    private void FcreateEnemy(int border, float z, float speed) // create one enemy
    {
        float x = 0.0f;
        if (border == 0) { border = -1; x = Xmin; }
        if (border == 1) { x = Xmax; }
        float y = Yfly;

        GameObject goEnemy = Instantiate(goEnemyPref);
        goEnemy.GetComponent<CMenuClick>().enabled = false;
        goEnemy.name = "EnemyBot";
        goEnemy.transform.SetParent(gameObject.transform);
        goEnemy.transform.position = new Vector3(x, y, z);
        //Debug.Log(goEnemy.transform.position);
        goEnemy.GetComponent<CEnemyClick>().Finit(border, speed, _goBar, Xmin, Xmax);
        //Debug.Log(speed);
        Lbots.Add(goEnemy);
    }//private void FcreateEnemy(int border, Vector3 coord)

    public void FremoveElement(GameObject go) { Lbots.Remove(go); }
    
    private void FclearList()
    {
        for (int i=0;i<Lbots.Count;i++)
        {
            Destroy(Lbots[i]);
            //Lbots.Remove(Lbots[i]);
        }

        Lbots = new List<GameObject>(); 
    }// private void FclearList()

    public void Fstart()
    {
        //FclearList();
        FcreateBonusBar();
        game_play = true;
    }//public void Fstart()

    public void Fstop()
    {
        game_play = false;
        FclearList();
        Destroy(_goBar);
        gameObject.GetComponent<CMainLand>().FLandGen();
    }//public void Fstop()

    private void FcreateMusicBot(string folder)
    {
        float x = Random.Range(Xmin, Xmax);
        float y = Yfly;
        float z = Random.Range(Zmin, Zmax);

        GameObject goMusicBot = Instantiate(goEnemyPref);
        goMusicBot.name = folder;
        goMusicBot.transform.SetParent(gameObject.transform);
        goMusicBot.transform.position = new Vector3(x, y, z);
        //Debug.Log(goEnemy.transform.position);
        goMusicBot.GetComponent<CEnemyClick>().enabled = false;
        goMusicBot.GetComponent<CBonusClick>().enabled = false;
        //Debug.Log(speed);
        Lpacks.Add(goMusicBot);

        goMusicBot.GetComponent<CMenuClick>()._goMain = this.gameObject;
        goMusicBot.GetComponent<CMenuClick>().enabled = true;
    }

    public void FclearListMusicBots()
    {
        foreach (GameObject go in Lpacks) { Destroy(go);}
        Lpacks.Clear();
    }

    public void FloadMusic()
    {
        //Debug.Log("load music");

        CS.MainAudio = Resources.LoadAll<AudioClip>("Sounds/Pack1");

        string main_dir_path = Application.dataPath + "/Resources/Sounds";

        //Debug.Log(main_dir_path);

        //List<string> Ldir = new List<string>();
        //int count = 0;

        if (Directory.Exists(main_dir_path))
        {
            DirectoryInfo mainDir = new DirectoryInfo(main_dir_path);
            DirectoryInfo[] subDirs = mainDir.GetDirectories();

            int count = Directory.GetDirectories(main_dir_path).Length;
            //Debug.Log(count);

            CS.MPackPath = new string[count];

            //foreach (DirectoryInfo subD in subDirs) { Debug.Log(subD.Name); }

            for (int i = 0; i < count; i++)
            {
                CS.MPackPath[i] = subDirs[i].Name;
                FcreateMusicBot(subDirs[i].Name);
            }
        }
        //else { Debug.Log("oops"); }

        //for (int i=0;i<count;i++) { FcreateMusicBot(CS.MPackPath[i]); }

        //string path = "Sounds";
        //string folder = new DirectoryInfo(path).Name;
        //Debug.Log(folder);

        //Object[] folders = Resources.LoadAll("Sounds");
        //foreach (var folder in folders) { Debug.Log(folder.name); }

        //CS.MainAudio = Resources.LoadAll<AudioClip>("Sounds/Pack1");

       // for (int i=0; i < CS.MainAudio.Length; i++) {Debug.Log(CS.MainAudio[i].name);}
    }//public void FloadMusic()


    public void FloadPrefabs()
    {
        //Debug.Log("load prefabs !");
        CS.Mprefabs = Resources.LoadAll<GameObject>("Prefabs");
        //foreach (GameObject go in CS.Mprefabs) { Debug.Log(go.name); }
    }//public void FloadPrefabs()

}//public class CMain : MonoBehaviour
