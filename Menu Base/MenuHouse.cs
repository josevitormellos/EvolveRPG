using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHouse : MonoBehaviour
{
    public Image mob;
    public Text nivel, nome, vida, mana, ataque;
    public Text confirm;
    public int cont;

    public void EntrarHouse(int id){
        if(id > 0){
            Dados.instance.AlterarMob(id -1);

        }

         MonsterBase mon = Player.user.monster;
            mob.sprite = MonsterBase.monstro.pele;
            nome.text = MonsterBase.monstro.nome;
            vida.text = "Vida: " + mon.vida.ToString();
            mana.text = "Mana: " + mon.energia.ToString();
            ataque.text = "Dano: " + mon.ataqueF.ToString();
        
        nivel.text = "Nivel: " + mon.nivel.ToString();

        confirm.text = "Equipado";
    }
    public void Trocar(int i){
        cont += i;

        if(cont  < 0 || cont > Player.user.monstros.Count){
            cont = 0;
           
            
        }
        EntrarHouse(cont);


        
    }
    public void Confirmar(){
        if(cont > 0){
            SystemBase.TrocarMob(cont -1);
        }
    }
    
}
