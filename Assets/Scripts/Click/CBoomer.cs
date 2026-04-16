//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBoomer : MonoBehaviour
{
    private List<GameObject> Lcube;
    private List<Vector3> Lpos = new List<Vector3>();

    private float speed = 10.0f;

    private float range1 = -10.0f;
    private float range2 = 10.0f;

    private float scale = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(scale, scale, scale);
        Finit();
        Destroy(gameObject, 1.0f);
    }//void Start()

    // Update is called once per frame
    void Update()
    {
        Fgo();
    }//void Update()

    private void Finit()
    {
        foreach (Transform child in transform)
        {
            child.transform.position = transform.position;
            Lpos.Add(new Vector3(UnityEngine.Random.Range(range1, range2), UnityEngine.Random.Range(range1, range2), UnityEngine.Random.Range(range1, range2)));
        }
    }//private void Finit()

    private void Fgo()
    {
        foreach (Transform child in transform)
        {
            //Debug.Log(child.name);
            child.transform.position = Vector3.MoveTowards(child.transform.position, Lpos[child.GetSiblingIndex()], speed * Time.deltaTime);
        }
    }//private void Fgo()
}//public class CBoomer : MonoBehaviour
