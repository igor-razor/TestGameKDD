//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CBonusClick : MonoBehaviour, IPointerClickHandler
{
    //private Renderer rend;
    //public Material mat;
    private float _Speed = 10.0f;
    private float DestroyDelay = 2.0f;

    bool flag_click = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        if (flag_click == true) { Fclick(); }
    }//public void OnPointerClick(PointerEventData eventData)

    // Start is called before the first frame update
    //void Start()
    //{
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
    //}// void Start()

    // Update is called once per frame
    void Update()
    {
        if (flag_click == false)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + Vector3.down, _Speed * Time.deltaTime);
            }
    }// void Update()

    public void Finit()
    {
        //Material m = new Material(Shader.Find("Specular"));
        //m.color = new Color(c.R,c.G,c.B);
        //go.GetComponent<MeshRenderer>().material = m;

        Material mat1 = new Material(Shader.Find("Specular"));
        mat1.color = Color.yellow;
        gameObject.GetComponent<MeshRenderer>().material = mat1;

        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //rend.sharedMaterial = mat;
        
    }//public void Finit()

    private void Fclick()
    {
        flag_click = false;
        Destroy(gameObject, DestroyDelay);
        // get bonus
        gameObject.transform.parent.gameObject.GetComponent<CBonusBar>().FgetBonus();
    }//private void Fclick()

}// public class CBonusClick : MonoBehaviour
