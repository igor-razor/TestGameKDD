//using System.Collections;
//using System.Collections.Generic;
//using System;
using UnityEngine;

public static class CLandGen
{
    public static int SIZE = 30;
    public static int iNULL = 0;

    public static float[,] FLandGen(int index, float Pscale, float Pborder)
    {
        float[,] H = new float[SIZE, SIZE];

        // 0 - Perlin noise
        if (index == 0) { return Fperlin(Pscale, Pborder); }

        return H;
    }//    public static void FLandGen()

    private static float[,] Fperlin(float scale, float border)
    {
        float[,] H = new float[SIZE, SIZE];

        ////float scale = 3.0f;
        ////float border = 0.5f;

        border = UnityEngine.Random.Range(border - 0.05f, border + 0.05f);
        //Debug.Log(border);

        if (scale <= 0) { scale = 0.0001f; }

        System.Random rnd = new System.Random();
        int delta = rnd.Next(0, 100);

        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
            {
                float dX = i / scale;
                float dY = j / scale;

                float PerlinH = Mathf.PerlinNoise(dX + delta, dY + delta);

                if (PerlinH >= border) { H[i, j] = (float)(iNULL + 1); }
                if (PerlinH < border) { H[i, j] = (float)iNULL; }
            }

        return H;
    }//private static byte[,] Fperlin()

}// public static class CMazeGen
