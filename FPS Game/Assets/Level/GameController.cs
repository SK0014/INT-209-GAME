using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   
   public Player player;
   public Text ammoText;
   public GameObject enemyContainer;
   public Text healthText;
   public Text enemyText;
   public Text infoText;
   private int intialEnemyCount;
void Start(){
intialEnemyCount=enemyContainer.GetComponentsInChildren<Enemy>().Length;     
  infoText.gameObject.SetActive(false);   

 }

    // Update is called once per frame
    void Update()
    { healthText.text="Health: "+player.Health;
     ammoText.text="Ammo: "+player.Ammo;
      int killedEnemies=0;
     foreach(Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>()){
     if(enemy.Killed==true){
       killedEnemies++;}
}
enemyText.text="Enemies: "+(intialEnemyCount-killedEnemies);
if(intialEnemyCount-killedEnemies==0){
infoText.gameObject.SetActive(true);
infoText.text="You Win!!\nGood Job";
}
if(player.Killed==true){
infoText.gameObject.SetActive(true);
infoText.text="You Lose!!\n:(";

}
}
}