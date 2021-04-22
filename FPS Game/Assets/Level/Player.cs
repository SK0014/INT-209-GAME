﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{     
    
    public Camera playerCamera;
    public int intialAmmo=12;
    private int ammo;
    public int Ammo{get{return ammo;} }
    public int intialHealth=100;
    private int health;
    private bool killed;
    public bool Killed{get{return killed;}}
    public float knockback=100;
    private bool isHurt;
    public float hurtDuration=0.5f;
    public int Health{get{return health;}}
    void Start()
    { health=intialHealth;
     ammo=intialAmmo;   
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetMouseButtonDown(0)){
        if(ammo>0&&Killed==false){
       ammo--;
           GameObject bulletObject=objectPoolingManager.Instance.GetBullet(true);
           bulletObject.transform.position=playerCamera.transform.position + playerCamera.transform.forward;
            bulletObject.transform.forward=playerCamera.transform.forward;         
}
}   
    }

void OnTriggerEnter(Collider otherCollider){

if(otherCollider.GetComponent<AmmoCrate>()!=null){
AmmoCrate ammoCrate=otherCollider.GetComponent<AmmoCrate>();
ammo+=ammoCrate.ammo;
Destroy(ammoCrate.gameObject);
}
else if(otherCollider.GetComponent<HealthCrate>()!=null){
HealthCrate healthCrate=otherCollider.GetComponent<HealthCrate>();
health+=healthCrate.health;
Destroy(healthCrate.gameObject);
}


if(isHurt==false){
GameObject hazard=null;
if(otherCollider.GetComponent<Enemy>()!=null){

Enemy enemy=otherCollider.GetComponent<Enemy>();
if(enemy.Killed==false){
hazard=enemy.gameObject;
health-=enemy.damage;
}
}
else if(otherCollider.GetComponent<Bullet>()!=null){
Bullet bullet=otherCollider.GetComponent<Bullet>();
if(bullet.ShotByPlayer==false){
hazard=bullet.gameObject;
health-=bullet.damage;
bullet.gameObject.SetActive(false);

}
}
if(hazard!=null){
isHurt=true;
Vector3 hurtDirection=(transform.position-hazard.transform.position).normalized;
Vector3 knockbackD=(hurtDirection+Vector3.up).normalized;
GetComponent<ForceReceiver>().AddForce(knockbackD,knockback);
StartCoroutine(HurtRoutine());

}
if(health<=0){
if(killed==false){
killed=true;
OnKill();}
}
}
}
IEnumerator HurtRoutine(){
yield return new WaitForSeconds(hurtDuration);
isHurt=false;
}
private void OnKill(){
GetComponent<CharacterController>().enabled=false;
GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled=false;
}
}
