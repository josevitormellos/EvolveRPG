using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public static Enemy user;
    public Monster monster;
    public int vida, dano, mana;

    public bool ataque = true;
    public float time;
    public int nivel;
    public Text nv;
    public GameObject slider, nvG;

    

    void Aweke(){
        user = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
         gameObject.transform.DOScale(new Vector3(1.05f,1.05f, 1f), 6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        if(ataque){
            if(time >= 5f){
                Player.user.ataque = false;
                ataque = false;
            time = 0;
                gameObject.transform.DOMoveX(-0.5f, 0.7f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine).OnComplete(() => { 
                    Atacar();
                });
           

        }
        else{
            time += Time.deltaTime * 0.9f;
        }
        }
        
    }

    public void CarregarStatus( int nivel){
        vida = monster.vida + (int)(nivel * 1.5f);
        dano = monster.ataqueF + (int)(nivel * 1.2f);
        mana = monster.energia + (int)(nivel * 1.5f);
        nv.text = "NV " + nivel.ToString();
        ataque = true;
    }
    public void Atacar(){
        int total = dano / 2;
        MenuBackGround.menu.SangueParticula(MenuBackGround.menu.playerP, MenuBackGround.menu.sangue, total.ToString());
        
         MonsterBase player = Player.user.monster;
         if(player.vida <= total){
            player.vida = 0;
            SystemRound.instance.round = 0;
            SystemRound.instance.DerrotouBando();
            player.CarregarStatus();
            SystemPosition.system.x = 0;
            SystemPosition.system.y = 0;
            PlayerPrefs.SetInt("x", SystemPosition.system.x);
            PlayerPrefs.SetInt("y", SystemPosition.system.y);
            MenuBackGround.menu.position.text = "X: " + SystemPosition.system.x.ToString() + " Y: " + SystemPosition.system.y.ToString();
            MenuScore.menu.CarregarDados("Derrota", "");
            SystemRound.instance.CarregarRounds();
            

            
            
         }
         else{
            player.vida -= (dano/2);
           
            MenuBackGround.menu.playerI.DOColor(MenuBackGround.menu.dano, 2f).OnComplete(() => {
                        ataque = true;
                Player.user.ataque = true;
                    });
         }
            MenuStatus.menu.CarregarVida( player);
    }

    public void CarregarNivel(int nivelMax){
        nivel = Random.Range(1, nivelMax + 1);

    }
    public void AlterarBoss(bool boss){
        if(boss){
           
             slider.transform.position = new Vector3 (0, 2.5f, 0);
            slider.transform.localScale = new Vector3( 2.9f, 1.9f, 1f);
            nvG.transform.localScale = new Vector3 ( 0.6f, 0.8f, 1f);
            nv.text = monster.nome;
            nv.color = new Color32(190, 27, 3, 255);
        }
        else{
           slider.transform.position =  new Vector3 (1.2f,0.8f, 0);
            slider.transform.localScale =  new Vector3( 1f, 1f, 1f);
            nvG.transform.localScale = new Vector3 ( 1f, 1f, 1f);
            nv.text = "Lv " + nivel.ToString();
        }
       
    }

      
}
