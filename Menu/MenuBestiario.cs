using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBestiario : MonoBehaviour
{
    public List<Monster> monstrosD, monstrosC, monstrosB, monstrosA, monstrosS, monstrosSR, monstrosSSR, monstrosUR, monstros;

    public Text nome, vida, mana, dano, raridade;
    public Image mon;

    public GameObject panel;

    public int cont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fechar(){
        gameObject.SetActive(false);
    }
     public void FecharPanel(){
        panel.SetActive(false);
    }

    public void CarregarFiltro(int specie){
        cont = 0;
        monstrosD.Clear();
        monstrosC.Clear();
        monstrosB.Clear();
        monstrosA.Clear();
        monstrosS.Clear();
        monstrosSR.Clear();
        monstrosSSR.Clear();
        monstrosUR.Clear();
        List<Monster> mons = Dados.instance.monsterGlobal;
        for(int i = 0; i < mons.Count; i++){
            if(specie == (int)mons[i].specie ||  specie < 0){
                switch((int)mons[i].raridade){
                    case 1:
                        monstrosD.Add(mons[i]);
                        break;
                    case 2:
                        monstrosC.Add(mons[i]);
                        break;
                    case 3:
                        monstrosB.Add(mons[i]);
                        break;
                    case 4:
                        monstrosA.Add(mons[i]);
                        break;
                    case 5:
                        monstrosS.Add(mons[i]);
                        break;
                    case 6:
                        monstrosSR.Add(mons[i]);
                        break;
                    case 7:
                        monstrosSSR.Add(mons[i]);
                        break;
                    case 8:
                        monstrosUR.Add(mons[i]);
                        break;
                    default:
                        break;
                }
            }
        }
        monstros.Clear();
        AddList(monstrosD);
        AddList(monstrosC);
        AddList(monstrosB);
        AddList(monstrosA);
        AddList(monstrosS);
        AddList(monstrosSR);
        AddList(monstrosSSR);
        AddList(monstrosUR);

        panel.SetActive(true);
        CarregarDados(0);

    }

    public void CarregarDados(int i){
        cont += i;
        
        if(cont < 0){
            cont = monstros.Count -1;

        }
        else if(cont == monstros.Count){
            cont = 0;
        }

        nome.text = monstros[cont].nome;
        vida.text = "Vida\n" + monstros[cont].vida.ToString();
        mana.text = "Mana\n" + monstros[cont].energia.ToString();
        dano.text = "Dano\n" + monstros[cont].ataqueF.ToString();
        raridade.text = monstros[cont].raridade.ToString();
        mon.sprite = monstros[cont].pele;
    }

    public void AddList(List<Monster> mon){
        for(int i = 0; i < mon.Count; i++){
            monstros.Add(mon[i]);
        }
    }

    

    
}
