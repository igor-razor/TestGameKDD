//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using System;

public class CMarch : MonoBehaviour
{
    //static int SIZE = CMazeGen.SIZE;
    static int iNULL = CLandGen.iNULL;

    public static void FMarch(GameObject[,] goMland, float[,] H)
    {
        for (int i = 0; i < goMland.GetLength(0); i++)
            for (int j = 0; j < goMland.GetLength(1); j++)
                if (goMland[i, j].activeSelf == true)
                {
                    GameObject goCD = goMland[i, j].transform.Find("CubeD").gameObject;
                    GameObject goCT = goMland[i, j].transform.Find("CubeT").gameObject;
                    GameObject goCR = goMland[i, j].transform.Find("CubeR").gameObject;

                    if (H[i, j] == iNULL)
                    {
                        goCD.SetActive(false);
                        goCT.SetActive(false);
                        goCR.SetActive(false);

                        if ((i + 1 < goMland.GetLength(0)) && (j + 1 < goMland.GetLength(0)))
                            if ((H[i, j] < H[i + 1, j]) && (H[i, j] < H[i, j + 1]) && (H[i, j] < H[i + 1, j + 1]))
                            {
                                goCD.transform.position = new Vector3(goCD.transform.position.x, H[i + 1, j + 1], goCD.transform.position.z);
                                goCD.SetActive(true);
                            }
                    }//if (H[i, j] == iNULL)

                    if (H[i, j] > iNULL)
                    {
                        if (i + 1 < goMland.GetLength(0))
                            if (H[i, j] > H[i + 1, j]) { goCR.SetActive(false); }

                        if (j + 1 < goMland.GetLength(1))
                            if (H[i, j] > H[i, j + 1]) { goCT.SetActive(false); }

                        if ((i + 1 < goMland.GetLength(0)) && (j + 1 < goMland.GetLength(0)))
                        {
                            if ((H[i, j] > H[i + 1, j]) && (H[i, j] > H[i, j + 1])) { goCD.SetActive(false); goCT.SetActive(false); goCR.SetActive(false); }
                            if ((H[i, j] > H[i + 1, j + 1]) && (H[i, j] > H[i, j + 1])) { goCD.SetActive(false); goCT.SetActive(false); }
                            if ((H[i, j] > H[i + 1, j + 1]) && (H[i, j] > H[i + 1, j])) { goCD.SetActive(false); goCR.SetActive(false); }
                        }

                        if (i + 1 == goMland.GetLength(0)) { goCR.SetActive(false); goCD.SetActive(false); }
                        if (j + 1 == goMland.GetLength(1)) { goCT.SetActive(false); goCD.SetActive(false); }

                    }//if (H[i, j] > iNULL)
                }// for i // for j
    }//private void FMarch(GameObject goMland)

}//public class CMarch : MonoBehaviour
