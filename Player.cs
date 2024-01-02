using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Player user;
    
    //Monstros
    public MonsterBase monster;
    public List<Monster> monstros;
    public List<int> nivel;
    public List<int> xp;




    public float time;   
    public bool ataque = false;
    public int gold = 0;

    public List<Item> itens;
    public List<Equip> equips;
    public bool battler = false;
    
    // Start is called before the first frame update

    void Awake(){
        user = this;
    }
    void Start()
    {
            
            gold = PlayerPrefs.GetInt("gold");
            
    }

    // Update is called once per frame
    void Update()
    {
        if(ataque){

            if(time >= (5f - monster.velocidade)){
            time = 0;
                SystemPosition.system.inimigo.ataque = false;
                ataque = false;
                MenuBackGround.menu.playerP.transform.DOMoveX(0.5f, 0.7f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine).OnComplete(() =>
                {
                    Atacar(SystemPosition.system.inimigo);
                    monster.RecuperarMana();
                    monster.RecuperarVida();
                });
          

            }
            else{
                time += Time.deltaTime * 0.9f;
            }
        }
        
       
        
    }


    public void Atacar(Enemy enemy){
        int round = SystemRound.instance.round;
        MenuBackGround.menu.SangueParticula( SystemPosition.system.inimigo.gameObject, MenuBackGround.menu.sangue, monster.ataqueF.ToString());
        
        if (enemy.vida <= monster.ataqueF){
            //Calcular Gold
            
            int total = enemy.monster.gold + (round * 2);
            
            gold += total;
            PlayerPrefs.SetInt("gold", gold);
            
            SystemRound.instance.gold = total;

            /*MenuBackGround.menu.CarregarGold();*/

            //Calcular XP
            int result = enemy.monster.xp + (enemy.monster.xp  * round/2 );
            SystemRound.instance.xp += result;
            monster.Up(result);

            //Atualizar Monstro
            SystemRound.instance.AtualizarInimigo(enemy);
           
            
         }
         else{
            enemy.vida -= monster.ataqueF;
            
            MenuBackGround.menu.enemyI.DOColor(MenuBackGround.menu.dano, 2f).OnComplete(() => {
                        ataque = true;
                enemy.ataque = true;
                    });
         }
            MenuBackGround.menu.CarregarSlideEnemy(SystemPosition.system.inimigo);
    }

    public void InserirGold(int value){
        gold += value;
        PlayerPrefs.SetInt("gold", gold);
        MenuBackGround.menu.CarregarGold();
    }

    

   
}
