using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENYME : MonoBehaviour
{
    public string targetObjectName;  
    public float speed = 1; 
    GameObject targetObject;
    private Animator anim;
    public float dis = 0;
    void Start () 
    {
        targetObject = GameObject.Find(targetObjectName);
        anim = GetComponent<Animator>();
    }
    void Update ()
    {
        Vector3 Apos = targetObject.transform.position;//プレイヤー
        Vector3 Bpos = this.transform.position;//敵
        dis = Vector3.Distance(Apos,Bpos);
        if (dis <= 3)
        {
             anim.SetBool("Attack",true);
        }
        else
        {
            anim.SetBool("Attack",false);
        }
        
    }

    private void FixedUpdate()
    {
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;  
        float vx = dir.x * speed;
        float vz = dir.z * speed;
        this.transform.Translate(vx / 50, 0,  vz / 50);
    }
}
