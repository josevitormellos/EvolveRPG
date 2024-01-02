using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuStatus : MonoBehaviour
{

    public Slider vida, mana, xp;
    public static MenuStatus menu;
    public Text tVida, tMana, tXp;

    public Text nivel;

    public GameObject panelSkills;
    public GameObject skill;
    public List<GameObject> skills;

    void Awake(){
        menu = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        MonsterBase.battler = true;
        
        AtualizarDados(Player.user.monster);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarXp(MonsterBase player){
        

        xp.maxValue = player.xp;
        xp.DOValue(player.xpTaxa, 2f);
        int xpPorcent = 100 * player.xpTaxa / player.xp;
        tXp.text = xpPorcent + "%";

    }
       public void CarregarVida(MonsterBase player){

        
        vida.maxValue = player.vidaM;
        
        vida.DOValue(player.vida, 2f);
        tVida.text = vida.maxValue + "/" + player.vida;

    }
       public void CarregarMana(MonsterBase player){
        mana.maxValue = player.energiaM;
        
        mana.DOValue(player.energia, 2f);
        tMana.text = mana.maxValue + "/" + player.energia;

    }

    public void CarregarPanelSkills(MonsterBase player){
        for(int i = 0; i < skills.Count; i++){
            Destroy(skills[i]);
        }
        for(int i = 0; i < player.skills.Count; i++){
            GameObject obj = Instantiate(skill, new Vector3(-1.8f + (1.2f * i), -4.227f, 0), Quaternion.identity, panelSkills.transform);
            obj.GetComponent<SystemSkill>().skill = player.skills[i];
            skills.Add(obj);
            
        }
    }

    public void AtualizarDados(MonsterBase mon){
        CarregarMana(mon);
        CarregarVida(mon);
        CarregarXp(mon);
        CarregarPanelSkills(mon);
        nivel.text = "Nv :. " + mon.nivel.ToString();
       

    }
}
