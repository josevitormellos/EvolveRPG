using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEC : MonoBehaviour
{
    public static MenuEC menu;
    public Monster mon;
    public float time = 0;
    public Image pele;
    public Text description, dados;

    public GameObject verificar;
    public int identificador;
    // Start is called before the first frame update
    void Start()
    {
        menu = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(verificar.activeSelf){
            time += Time.deltaTime * 0.8f;
            if(time >= 3f){
                time = 0f;
                verificar.SetActive(false);
            }
        }
      
    }

    public void AtualizarStatus(int id, int evo = -1){
      
        mon = Dados.instance.monsterGlobal[id-1];
        pele.sprite = mon.pele;

        if(evo >= 0){
            description.text = MonsterBase.monstro.evoluir[evo].description;
            
        }
        else{
            description.text = "Nao tem a possibilidade da classe atual evoluir para esta subespecia";
        }
        identificador = evo;
        
        
    }

     public void Evoluir(){
       
        if(identificador >= 0){
            Debug.Log("ENTREI AQUI");
             Monster monster = Player.user.monster.Evoluir(-1, identificador);
            if(monster != null){
                Player.user.monster.PrepararEvolucao(monster);
            }
            MenuEvolve.menu.CarregarMonster();
        }
       
        


        
    }
}
