using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemSkill : MonoBehaviour
{
    public Skill skill;
    public float time;

    public Text timeT;
    public Image carregar;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = skill.icon;
        carregar.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0){
            carregar.fillAmount = time/skill.time;
            time -= Time.deltaTime * 0.7f;
            timeT.text = time.ToString("#.00");

            
        }
        else{
            timeT.text = "";
            time = 0;

        }
    }

    public void AtacarSkill(){
       
        if(Player.user.ataque && time <= 0){
            MonsterBase player = Player.user.monster;
            int danoGlobal = skill.dano + (int)(skill.dano * player.ataqueF/10f);
             MenuBackGround.menu.SangueParticula( SystemPosition.system.inimigo.gameObject, MenuBackGround.menu.sangue, danoGlobal.ToString());
            if(player.energia  >= skill.mana){
                MenuBackGround.menu.ManaParticulas();
                if(SystemPosition.system.inimigo.vida <= danoGlobal){
                    int gold = SystemPosition.system.inimigo.monster.gold + SystemRound.instance.round;
                    Player.user.gold += gold;
                    SystemRound.instance.gold = gold;
                    int result = SystemPosition.system.inimigo.monster.xp + (SystemRound.instance.round/2);
                    SystemRound.instance.xp += result;
                    
                    SystemRound.instance.AtualizarInimigo(SystemPosition.system.inimigo);
                    
            
                    player.Up(result);
                MenuBackGround.menu.CarregarGold();
                
                }
                else{
                    SystemPosition.system.inimigo.vida -= danoGlobal;
                }
                player.energia -= skill.mana;
                MenuStatus.menu.CarregarMana(player);
                MenuBackGround.menu.CarregarSlideEnemy(SystemPosition.system.inimigo);
                time = skill.time;
                carregar.fillAmount =1f;
                timeT.text = time.ToString("#.00");
            }
        }
        
        
    }

}
