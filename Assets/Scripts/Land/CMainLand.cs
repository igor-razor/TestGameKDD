//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class CMainLand : MonoBehaviour
{
    public GameObject goCubePref;
    private int SIZE = CLandGen.SIZE;
    private int iNULL = CLandGen.iNULL;
    private float delta = Mathf.Sqrt(2);
    private float[,] H = new float[CLandGen.SIZE, CLandGen.SIZE];
    private GameObject[,] goMland = new GameObject[CLandGen.SIZE, CLandGen.SIZE];

    private int itype = 0;

    private float Pscale = 7.0f;
    private float Pborder = 0.5f;

    // Start is called before the first frame update
    //void Start()
    //{
    //
    //}//void Start()

    public void FLandGen()
    {
        //Debug.Log("GEN");
        goCubePref = CS.Mprefabs[(int)CS.P.p01cube];
        FdestroyLand();
        FcreateLand();
        CMarch.FMarch(goMland, H);
    }//public void FLandGen()

    private void FcreateLand()
    {

        H = CLandGen.FLandGen(itype, Pscale, Pborder);

        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
            //if (H[i, j] > iNULL)
            {
                GameObject goCube = Instantiate(goCubePref);
                goCube.name = "unit_" + Convert.ToString(i) + "_" + Convert.ToString(j) + "_H" + Convert.ToString(Convert.ToInt32(H[i, j]));
                goCube.transform.SetParent(gameObject.transform.Find("Land").transform);
                goCube.transform.position = new Vector3(i * delta, H[i, j], j * delta);
                //if (H[i, j] == iNULL) { goCube.transform.position = new Vector3(i * delta, H[i, j], j * delta); }

                goMland[i, j] = goCube;
            }

        FclearSingle();

    }//private void Fcreate()

    private void FclearSingle()
    {
        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
                if (H[i, j] > iNULL)
                {
                    if ((i > 0) && (i < SIZE - 1) && (j > 0) && (j < SIZE - 1))
                        if ((H[i, j + 1] < H[i, j]) && (H[i + 1, j] < H[i, j]) && (H[i, j - 1] < H[i, j]) && (H[i - 1, j] < H[i, j]))
                        { goMland[i, j].transform.position = new Vector3(goMland[i, j].transform.position.x, iNULL, goMland[i, j].transform.position.z); }

                    if ((i == 0) && (j > 0) && (j < SIZE - 1))
                        if ((H[i, j + 1] < H[i, j]) && (H[i + 1, j] < H[i, j]) && (H[i, j - 1] < H[i, j]))
                        { goMland[i, j].transform.position = new Vector3(goMland[i, j].transform.position.x, iNULL, goMland[i, j].transform.position.z); }

                    if ((i == SIZE - 1) && (j > 0) && (j < SIZE - 1))
                        if ((H[i, j + 1] < H[i, j]) && (H[i, j - 1] < H[i, j]) && (H[i - 1, j] < H[i, j]))
                        { goMland[i, j].transform.position = new Vector3(goMland[i, j].transform.position.x, iNULL, goMland[i, j].transform.position.z); }

                    if ((i > 0) && (i < SIZE - 1) && (j == 0))
                        if ((H[i, j + 1] < H[i, j]) && (H[i + 1, j] < H[i, j]) && (H[i - 1, j] < H[i, j]))
                        { goMland[i, j].transform.position = new Vector3(goMland[i, j].transform.position.x, iNULL, goMland[i, j].transform.position.z); }

                    if ((i > 0) && (i < SIZE - 1) && (j == SIZE - 1))
                        if ((H[i + 1, j] < H[i, j]) && (H[i, j - 1] < H[i, j]) && (H[i - 1, j] < H[i, j]))
                        { goMland[i, j].transform.position = new Vector3(goMland[i, j].transform.position.x, iNULL, goMland[i, j].transform.position.z); }
                }// for i // for j

    }//private void FclearSingle()

    private void FdestroyLand()
    {
        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
                if (goMland[i, j] != null)
                    Destroy(goMland[i, j].gameObject);
    }//private void Fdestroy()

    ///////////////////////////////////////

    // Update is called once per frame
    //void Update()
    //{
    //
    //}//void Update()
}//public class CMain : MonoBehaviour
