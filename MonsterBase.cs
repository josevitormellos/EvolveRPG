using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MonsterBase : MonoBehaviour
{
    public static bool battler = false;

    public static Monster monstro, evoluir;
    public int vidaM, vida, energiaM, energia, ataqueF, ataqueM, nivel, defesaF, defesaM;
    public int energiaRecup, vidaRecup;

    public float specialFogo, specialAgua, specialLuz, specialSombra, specialFada, defesaFogo, defesaAgua, defesaLuz, defesaSombra, defesaFada;
    public int xp, xpTaxa;
    public float velocidade, velocidadeA, chCritico, critico;
    public Equip arma, armadura, bota, anel, joia;
    public int id;
   


     /*Upgrads*/
    public int rosa;
    public int vermelho;
    public int azul;
    public int verde;
    public int roxo;
    public int laranja;
    public int preto;

    public List<Skill> skills;

    // Start is called before the first frame update
    void Start()
    {
        
       
       Dados.instance.IniciarGame();
        IniciarStatus(monstro);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarStatus(Monster mon){
        
        monstro = mon;
        id = monstro.id;
        energiaRecup = 1;
        
        
         if(!PlayerPrefs.HasKey("nivelPrincipal")){
           PlayerPrefs.SetInt("nivelPrincipal", 1);

        }
        nivel = PlayerPrefs.GetInt("nivelPrincipal");
        xpTaxa = PlayerPrefs.GetInt("xpPrincipal");
         CarregarStatus();

    }

    public void CarregarStatus(){
        
        xp = nivel * 20 * (int)monstro.raridade ;

        int calculotaxa = nivel * (int)monstro.raridade / 10;

        energiaM = monstro.energia + (monstro.energia * calculotaxa);
        vidaM = monstro.vida + (monstro.vida * calculotaxa);
        ataqueF = monstro.ataqueF + (monstro.ataqueF * calculotaxa);
        ataqueM = monstro.specialE + (monstro.specialE * calculotaxa);
        defesaF = monstro.defesaF + (monstro.defesaF * calculotaxa);
        defesaM = monstro.defesaE + (monstro.defesaE * calculotaxa);
        velocidadeA = monstro.velocidade + (monstro.velocidade * calculotaxa)/2;
        velocidade = monstro.velocidadeM;
        chCritico = monstro.chanceCritico + (monstro.chanceCritico * calculotaxa)/2;
        critico = monstro.critico + (monstro.critico * calculotaxa);

        /*Special Class*/

        specialAgua = monstro.specialAgua + (monstro.specialAgua * calculotaxa);
        specialFogo = monstro.specialFogo + (monstro.specialFogo * calculotaxa);
        specialLuz = monstro.specialLuz + (monstro.specialLuz * calculotaxa);
        specialSombra = monstro.specialSombra + (monstro.specialSombra * calculotaxa);
        specialFada = monstro.specialFada + (monstro.specialFada * calculotaxa);

        defesaAgua = monstro.defesaAgua + (monstro.defesaAgua * calculotaxa);
        defesaFogo = monstro.defesaFogo + (monstro.defesaFogo * calculotaxa);
        defesaLuz = monstro.defesaLuz + (monstro.defesaLuz * calculotaxa);
        defesaSombra = monstro.defesaSombra + (monstro.defesaSombra * calculotaxa);
        defesaFada = monstro.defesaFada + (monstro.defesaFada * calculotaxa);

        /*Status Cores*/
        azul = PlayerPrefs.GetInt("azul");
        vermelho = PlayerPrefs.GetInt("vermelho");
        laranja = PlayerPrefs.GetInt("laranja");
        preto = PlayerPrefs.GetInt("preto");
        verde = PlayerPrefs.GetInt("verde");
        roxo = PlayerPrefs.GetInt("roxo");
        rosa = PlayerPrefs.GetInt("rosa");

        RecalcularCor();
        energia = energiaM;
        vida = vidaM;

        AddStatusEquip(arma);
        AddStatusEquip(armadura);
        AddStatusEquip(bota);
        

        CarrergarSkill();
        if(battler){
            MenuStatus.menu.AtualizarDados(this);
        }
        
       
    }

    public void RecalcularCor(){
        ataqueM += (ataqueM * laranja / 100);
        specialLuz += specialLuz * laranja / 100;
        defesaLuz += defesaLuz * laranja / 100;
        ataqueF += ataqueF * preto / 100;
        defesaF += ataqueF * preto / 100;
        velocidadeA += velocidadeA * preto / 100;
        energiaM += energiaM * azul / 100;
        specialAgua += specialAgua * azul / 100;
        defesaAgua += defesaAgua * azul / 100;
        chCritico += chCritico * roxo / 100;
        specialSombra += specialSombra * roxo / 100;
        defesaSombra += defesaSombra * roxo / 100;
        critico += critico * vermelho / 100;
        specialFogo += specialFogo * vermelho / 100;
        defesaFogo += defesaFogo * vermelho / 100;
        defesaM += defesaM * verde / 100;
        specialFada += specialFada * rosa / 100;
        defesaFada += defesaFada * rosa / 100;

    }

    

    public void Up(int point){
        
        xpTaxa += point;
        if(xp <= xpTaxa){
            xpTaxa -= xp;
            nivel ++;
            MenuBackGround.menu.SangueParticula(MenuBackGround.menu.playerP, MenuBackGround.menu.particulaUp, "Up+");
             PlayerPrefs.SetInt("xpPrincipal", xpTaxa);
            PlayerPrefs.SetInt("nivelPrincipal", nivel);
           
            CarregarStatus();
            
            if(evoluir != null){
               MenuBackGround.menu.AbrirPanelEvolve();
            }
    
        }
        else{
             PlayerPrefs.SetInt("xpPrincipal", xpTaxa);
            MenuStatus.menu.CarregarXp(this);
          
        }
         
    }

    public void CarrergarSkill(){
        skills.Clear();
        for(int i = 0; i < monstro.skills.Count; i++){
            if(nivel >= monstro.skills[i].nivel){
                skills.Add(monstro.skills[i].skill);
            }
        }
    }

    public void RecuperarMana(){
        
        if((energia + energiaRecup)  <  energiaM){
            energia += 2 + energiaRecup;
        }
        else if(energia <  energiaM){
            energia =  energiaM;
            
        }
        MenuStatus.menu.CarregarMana(this);
    }
    public void RecuperarVida(){
        
        if((vida + vidaRecup)  <  vidaM){
            vida += vidaRecup;
        }
        else if(vida <  vidaM){
            vida =  vidaM;
            
        }
        MenuStatus.menu.CarregarVida(this);
    }

    public Monster Evoluir(int id, int evol){

        int cont = 0;
        
            if(monstro.evoluir[evol].nivel <= nivel){
                if(monstro.evoluir[evol].termos.Count == 0){
                    return monstro.evoluir[evol].monstro;
                }
                else{
                   
                    for(int j=0; j < monstro.evoluir[evol].termos.Count; j++){
                    if(monstro.evoluir[evol].termos[j].quantidade <= PlayerPrefs.GetInt("MValueT" + id.ToString() + "/" + j.ToString())){
                        cont ++;
                    }
                    else{
                            MenuEC.menu.verificar.SetActive(true);
                            MenuEC.menu.dados.text = "Falta " + PlayerPrefs.GetInt("MValueT" + id.ToString() + "/" + j.ToString()).ToString() + " de " +  monstro.evoluir[evol].termos[j].quantidade.ToString() + monstro.evoluir[evol].termos[j].tipo;
                            
                        
                    }
                    
                    }
                    if(cont == monstro.evoluir[evol].termos.Count){
                        
                        return monstro.evoluir[evol].monstro;
                    }
                }
                
            }
            else{
                MenuEC.menu.verificar.SetActive(true);
                MenuEC.menu.dados.text = "Ainda não atigim o nivel necessario, por favor treine mais";
                            
            }
        

        return null;
    }

    public void ReiniciarMonster(){
            PlayerPrefs.SetInt("nivelPrincipal", 1);
            PlayerPrefs.SetInt("xpPrincipal", 0);
    }

    public void PrepararEvolucao(Monster mon){
                IniciarStatus(mon);
                evoluir = null;
                nivel = 1;
                xpTaxa = 0;
                PlayerPrefs.SetInt("nivelPrincipal", nivel);
                PlayerPrefs.SetInt("xpPrincipal", xpTaxa);
                CarregarStatus();
                MenuBackGround.menu.CarregarImagePlayer();
                PlayerPrefs.SetInt("MobPrincipal", id);
                monstro.visible = true;
                Dados.instance.CriarTermosEvolve(-1, monstro);
    }




    public void AddStatusEquip(Equip equip){
       if(equip != null){
         energia = energiaM += equip.mana;
        vida = vidaM += equip.vida;
        ataqueF += equip.dano;
        }
       
    }

}
