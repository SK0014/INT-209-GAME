using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed=8f;
   public float lifeduration=2f;
   private float life;
   public int damage=5;
    // Start is called before the first frame update
   private bool shotByPlayer;
  public bool ShotByPlayer{get{return shotByPlayer;} set{shotByPlayer=value; }}    

    void OnEnable()
    {
        life=lifeduration;        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position+=transform.forward*speed*Time.deltaTime;        
      life-=Time.deltaTime;
       if(life<=0f){
         gameObject.SetActive(false);          
}
    }
}
