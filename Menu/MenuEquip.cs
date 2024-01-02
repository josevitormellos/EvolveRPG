using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEquip : MonoBehaviour
{
    public static MenuEquip menu;
    public Image mob;
    public Image bota, armadura, arma, anel, joia;
    public Sprite invisivel;
    public List<Image> equipamentos;


    //Visible
    public Text nome, description;
    public GameObject desequipar, visibleP;
    public Image iconVisible;

    public int vis;
    // Start is called before the first frame update
    void Awake(){
        menu = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarEquips(){
        if(PlayerPrefs.HasKey("arma")){
            arma.sprite = Dados.instance.equipamentoGlobal[PlayerPrefs.GetInt("arma") -1].icon;
        }
        else{
            arma.sprite = invisivel;
        }

        if(PlayerPrefs.HasKey("armadura")){
            armadura.sprite = Dados.instance.equipamentoGlobal[PlayerPrefs.GetInt("armadura") -1].icon;
        }
        else{
            armadura.sprite = invisivel;
        }
        
        if(PlayerPrefs.HasKey("bota" )){
            bota.sprite = Dados.instance.equipamentoGlobal[PlayerPrefs.GetInt("bota" ) -1].icon;
        }
        else{
            bota.sprite = invisivel;
        }

        if(PlayerPrefs.HasKey("anel")){
            anel.sprite = Dados.instance.equipamentoGlobal[PlayerPrefs.GetInt("anel" ) -1].icon;
        }
        else{
            anel.sprite = invisivel;
        }

        if(PlayerPrefs.HasKey("joia" )){
            joia.sprite = Dados.instance.equipamentoGlobal[PlayerPrefs.GetInt("joia" ) -1].icon;
        }
        else{
            joia.sprite = invisivel;
        }
    }

    public void MobImage(){
        mob.sprite = MonsterBase.monstro.pele;
    }

    public void CarregarEquipsTotal(){
        List<Equip> equips = Player.user.equips;
        for (int i = 0; i < 15; i++){
            if(i < equips.Count){
                equipamentos[i].sprite = equips[i].icon;
            }
            else{
                equipamentos[i].sprite = invisivel;
            }
        }
    }

    public void VisibleEquip(int id){
        List<Equip> equips = Player.user.equips;
        if(id < 15 && id >=0){
            if(id < equips.Count){
                 visibleP.SetActive(true);
                iconVisible.sprite = equips[id].icon;
                nome.text = equips[id].nome;
                vis = id;
            }
           
        }
        else if(id >= 15 && id < 20){
            MonsterBase mon = Player.user.monster;
            Equip equip = null;
            visibleP.SetActive(true);
            desequipar.SetActive(true);
            switch(id){
                case 15:
                    equip = mon.arma;
                    
                    break;
                case 16:
                    equip = mon.armadura;
                    
                    break;
                case 17:
                    equip = mon.bota;
                    
                    break;
                case 18:
                    equip = mon.anel;
                    
                    break;
                case 19:
                    equip = mon.joia;
                    
                    break;
                default:
                    break;
            }
            if(equip != null){
                iconVisible.sprite = equip.icon;
                nome.text = equip.nome;
            }
            
        }
    }

    public void Equipar(){
        List<Equip> equips = Player.user.equips;

        if (equips[vis].tipo.ToString() == "Arma"){
            if(!PlayerPrefs.HasKey("arma") || PlayerPrefs.GetInt("arma") == -1){ 
                PlayerPrefs.SetInt("arma", equips[vis].id);
                Player.user.monster.arma = equips[vis];
                equips.RemoveAt(vis);
                Dados.instance.DeletarEquip(vis);
                arma.sprite = equipamentos[vis].sprite;
                equipamentos[vis].sprite = invisivel;
                
                
                
            }
        }
        else if(equips[vis].tipo.ToString() == "Armadura"){
            if(!PlayerPrefs.HasKey("armadura") || PlayerPrefs.GetInt("armadura") == -1){
                PlayerPrefs.SetInt("armadura", equips[vis].id);
                Player.user.monster.armadura = equips[vis];
                equips.RemoveAt(vis);
                Dados.instance.DeletarEquip(vis);
                armadura.sprite = equipamentos[vis].sprite;
                equipamentos[vis].sprite = invisivel;
                
                
            }

        }
        else if(equips[vis].tipo.ToString() == "Bota"){
            if(!PlayerPrefs.HasKey("bota") || PlayerPrefs.GetInt("bota") == -1){
                PlayerPrefs.SetInt("bota", equips[vis].id);
                Player.user.monster.bota = equips[vis];
                equips.RemoveAt(vis);
                Dados.instance.DeletarEquip(vis);
                bota.sprite = equipamentos[vis].sprite;
                equipamentos[vis].sprite = invisivel;
                
                
            }

        }
        Player.user.monster.CarregarStatus();
        vis = -1;
        
    }
}
