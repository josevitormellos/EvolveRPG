using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEvolve : MonoBehaviour
{
    public List<Image> peles;
    public List<Monster> monsters;
    public GameObject panel;
    public static MenuEvolve menu;
    // Start is called before the first frame update
    void Start()
    {
        menu= this;
         CarregarMonster();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void CarregarMonster(){
        for(int i = 0; i<peles.Count; i++){
            if(monsters[i].visible){
                peles[i].color = new Color32(255, 255,255,255);
            }
            else{
                peles[i].color = new Color32(0, 0,0,255);
            }
        }
    }

    public void AbrirMenu(int id){
         panel.SetActive(true);
        int evo = -1;
        for(int i = 0; i < MonsterBase.monstro.evoluir.Count; i++){
            if(MonsterBase.monstro.evoluir[i].monstro.id == id){
                evo = i;
                break;
            }
        }
        panel.GetComponent<MenuEC>().AtualizarStatus(id, evo);
        
    }


    
}
