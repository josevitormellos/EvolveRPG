using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dados : MonoBehaviour
{
    public static Dados instance;
    public List<Item> itensGlobal;
    public List<Monster> monsterGlobal;
    public List<Equip> equipamentoGlobal;

    public List<Dungeon> andares;

    private List<int> termos;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        Application.LoadLevel("MenuInicial");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarItens(){
        if(!PlayerPrefs.HasKey("itensTotal")){
            PlayerPrefs.SetInt("itensTotal", 0);
        }
         else{
            
             for(int i = 0; i < PlayerPrefs.GetInt("itensTotal"); i++){
                
                Player.user.itens.Add(itensGlobal[PlayerPrefs.GetInt("itensId" + i.ToString())]);

            }
        }
        if(!PlayerPrefs.HasKey("equipsTotal")){
            PlayerPrefs.SetInt("equipsTotal", 0);
        }
         else{
             for(int i = 0; i < PlayerPrefs.GetInt("equipsTotal"); i++){
                
                Player.user.equips.Add(equipamentoGlobal[PlayerPrefs.GetInt("equipsId" + i.ToString()) -1]);

            }
        }
        if(PlayerPrefs.HasKey("arma")){
            Player.user.monster.arma = equipamentoGlobal[PlayerPrefs.GetInt("arma") -1];
            
        }
         if(PlayerPrefs.HasKey("armadura")){
            Player.user.monster.armadura = equipamentoGlobal[PlayerPrefs.GetInt("armadura") -1];
            
        }
         if(PlayerPrefs.HasKey("bota")){
            Player.user.monster.bota = equipamentoGlobal[PlayerPrefs.GetInt("bota") -1];
           
        }
         if(PlayerPrefs.HasKey("anel")){
            Player.user.monster.anel = equipamentoGlobal[PlayerPrefs.GetInt("anel") -1];
            
        }
         if(PlayerPrefs.HasKey("joia")){
            Player.user.monster.joia = equipamentoGlobal[PlayerPrefs.GetInt("joia") -1];
            
        }
        Player.user.monster.CarregarStatus();
       
    }

    public void IniciarGame(){
        if(!PlayerPrefs.HasKey("MobPrincipal")){
            PlayerPrefs.SetInt("MobPrincipal", 1);
            PlayerPrefs.SetInt("azul",20);
            PlayerPrefs.SetInt("vermelho",20);
            PlayerPrefs.SetInt("laranja",20);
            PlayerPrefs.SetInt("preto",20);
            PlayerPrefs.SetInt("verde",20);
            PlayerPrefs.SetInt("roxo",20);
            PlayerPrefs.SetInt("rosa",20);

            CriarTermosEvolve(-1,  monsterGlobal[0]);

        }
  
        MonsterBase.monstro = monsterGlobal[PlayerPrefs.GetInt("MobPrincipal")-1];
        Player.user.gold = 0;
        
        BuscarMobs();
    }

    public void BuscarMobs(){
        Player.user.monstros.Clear();
        Player.user.nivel.Clear();
        Player.user.xp.Clear();
        if(PlayerPrefs.HasKey("MobsCount")){
            for(int i = 0; i < PlayerPrefs.GetInt("MobsCount"); i++){
                Player.user.monstros.Add(monsterGlobal[PlayerPrefs.GetInt("Mob" + i.ToString())]);
                Player.user.nivel.Add(PlayerPrefs.GetInt("nivel" + i.ToString()));
                Player.user.xp.Add(PlayerPrefs.GetInt("xp" + i.ToString()));
            }
        }
    }

    public void AlterarMob(int pos){
        if(PlayerPrefs.HasKey("Mob" + pos.ToString())){
            int id =  PlayerPrefs.GetInt("MobPrincipal");
            int nivel = PlayerPrefs.GetInt("nivelPrincipal");
            int xp = PlayerPrefs.GetInt("xpPrincipal");
            int rosa = PlayerPrefs.GetInt("rosa"); 
            int azul = PlayerPrefs.GetInt("azul");
            int vermelho = PlayerPrefs.GetInt("vermelho");
            int laranja = PlayerPrefs.GetInt("laranja");
            int preto = PlayerPrefs.GetInt("preto");
            int verde = PlayerPrefs.GetInt("verde");
            int roxo = PlayerPrefs.GetInt("roxo");
            
            PlayerPrefs.SetInt("MobPrincipal", PlayerPrefs.GetInt("Mob"+ pos.ToString()));
            PlayerPrefs.SetInt("nivelPrincipal", PlayerPrefs.GetInt("nivel"+ pos.ToString()));
            PlayerPrefs.SetInt("xpPrincipal", PlayerPrefs.GetInt("xp"+ pos.ToString()));
            PlayerPrefs.SetInt("azul",PlayerPrefs.GetInt("azul"+ pos.ToString()));
            PlayerPrefs.SetInt("vermelho",PlayerPrefs.GetInt("vermelho"+ pos.ToString()));
            PlayerPrefs.SetInt("laranja",PlayerPrefs.GetInt("laranja"+ pos.ToString()));
            PlayerPrefs.SetInt("preto",PlayerPrefs.GetInt("preto"+ pos.ToString()));
            PlayerPrefs.SetInt("verde",PlayerPrefs.GetInt("verde"+ pos.ToString()));
            PlayerPrefs.SetInt("roxo",PlayerPrefs.GetInt("roxo"+ pos.ToString()));
            PlayerPrefs.SetInt("rosa",PlayerPrefs.GetInt("rosa"+ pos.ToString()));
            MonsterBase.monstro = monsterGlobal[PlayerPrefs.GetInt("MobPrincipal") - 1];
            Player.user.monster.IniciarStatus(MonsterBase.monstro);
        
            //Passando Alterar Mob
            PlayerPrefs.SetInt("Mob"+ pos.ToString(), id);
            PlayerPrefs.SetInt("nivel"+ pos.ToString(), nivel);
            PlayerPrefs.SetInt("xp"+ pos.ToString(), xp);
            PlayerPrefs.SetInt("rosa" + pos.ToString(), rosa);
            PlayerPrefs.SetInt("azul" + pos.ToString(), azul);
            PlayerPrefs.SetInt("vermelho" + pos.ToString(), vermelho);
            PlayerPrefs.SetInt("verde" + pos.ToString(), verde);
            PlayerPrefs.SetInt("roxo" + pos.ToString(), roxo);
            PlayerPrefs.SetInt("preto" + pos.ToString(), preto);
            PlayerPrefs.SetInt("laranja" + pos.ToString(), laranja);
        }
    }

    public void IncluirMob(int id){
        if(!PlayerPrefs.HasKey("MobsCount")){
            PlayerPrefs.SetInt("MobsCount", 0);
        }
        PlayerPrefs.SetInt("Mob" + PlayerPrefs.GetInt("MobsCount"), id);
        PlayerPrefs.SetInt("nivel" + PlayerPrefs.GetInt("MobsCount"), 1);
        PlayerPrefs.SetInt("xp" + PlayerPrefs.GetInt("MobsCount"), 0);
        PlayerPrefs.SetInt("azul" + PlayerPrefs.GetInt("MobsCount"),Random.Range(0, 101));
            PlayerPrefs.SetInt("vermelho" + PlayerPrefs.GetInt("MobsCount"),Random.Range(0, 101));
            PlayerPrefs.SetInt("laranja" + PlayerPrefs.GetInt("MobsCount"),Random.Range(0, 101));
            PlayerPrefs.SetInt("preto" + PlayerPrefs.GetInt("MobsCount"),Random.Range(0, 101));
            PlayerPrefs.SetInt("verde" + PlayerPrefs.GetInt("MobsCount"),Random.Range(0, 101));
            PlayerPrefs.SetInt("roxo" + PlayerPrefs.GetInt("MobsCount"),Random.Range(0, 101));
            PlayerPrefs.SetInt("rosa" + PlayerPrefs.GetInt("MobsCount"),Random.Range(0, 101));

        Player.user.monstros.Add(monsterGlobal[id]);
        Player.user.nivel.Add(1);
        Player.user.xp.Add(0);
        CriarTermosEvolve(PlayerPrefs.GetInt("MobsCount"),monsterGlobal[id]);
        PlayerPrefs.SetInt("MobsCount", PlayerPrefs.GetInt("MobsCount") + 1);
        Debug.Log(PlayerPrefs.GetInt("MobsCount"));
        

        
    }

    public void DeletarItem(int id){
        if(PlayerPrefs.HasKey("itensQuant" + id)){
            PlayerPrefs.SetInt("itensQuant" + id,  PlayerPrefs.GetInt("itensQuant" + id) - 1);

            if( PlayerPrefs.GetInt("itensQuant" + id) == 0){
                
                for( int i = id; i < PlayerPrefs.GetInt("itensTotal")-1; i++){
                    PlayerPrefs.SetInt("itensQuant" + i.ToString(), PlayerPrefs.GetInt("itensQuant" + (i+1).ToString()));
                    PlayerPrefs.SetInt("itensId" + i.ToString(), PlayerPrefs.GetInt("itensId" + (i+1).ToString()));
                }
                PlayerPrefs.DeleteKey("itensId" + PlayerPrefs.GetInt("itensTotal").ToString());
                PlayerPrefs.DeleteKey("itensQuant" + PlayerPrefs.GetInt("itensTotal").ToString());
                PlayerPrefs.SetInt("itensTotal", PlayerPrefs.GetInt("itensTotal") -1);
                Player.user.itens.RemoveAt(PlayerPrefs.GetInt("posItem"));
            }
        }
        
        
    }

    public int AddItem(int id){
       
        for(int i = 0; i < PlayerPrefs.GetInt("itensTotal"); i++){
            Debug.Log(id);
            Debug.Log(PlayerPrefs.GetInt("itensId" + i.ToString()));
            if(id == PlayerPrefs.GetInt("itensId" + i.ToString())){
                if( PlayerPrefs.GetInt("itensQuant" + i.ToString()) < 99){
                    Debug.Log("Entrei");
                    PlayerPrefs.SetInt("itensQuant" + i.ToString(), PlayerPrefs.GetInt("itensQuant" + i.ToString()) + 1);
                    return 1;
                }
                
            }

        }
        if(PlayerPrefs.GetInt("itensTotal") < 24){
            Debug.Log("Entrei no Add");
            PlayerPrefs.SetInt("itensQuant" + PlayerPrefs.GetInt("itensTotal").ToString(), 1);
            PlayerPrefs.SetInt("itensId" + PlayerPrefs.GetInt("itensTotal").ToString(), id);
            PlayerPrefs.SetInt("itensTotal", PlayerPrefs.GetInt("itensTotal") +1);
            Player.user.itens.Add(itensGlobal[id]);
            return 0;
        }
        
        return -1;

    }
    public string AddEquip(int id){
        
        if(PlayerPrefs.GetInt("equipsTotal") < 15){
            PlayerPrefs.SetInt("equipsId" + PlayerPrefs.GetInt("equipsTotal").ToString(), id);
            int eq = PlayerPrefs.GetInt("equipsId" + PlayerPrefs.GetInt("equipsTotal").ToString());
             Player.user.equips.Add( equipamentoGlobal[eq-1]);
            PlayerPrefs.SetInt("equipsTotal", PlayerPrefs.GetInt("equipsTotal") +1);
           
            return equipamentoGlobal[eq-1].nome;
        }
        return "";
        
    }

    public void DeletarEquip(int id){
        if(PlayerPrefs.HasKey("equipsId" + id.ToString())){      
                for( int i = id; i < PlayerPrefs.GetInt("equipsTotal")-1; i++){
                    PlayerPrefs.SetInt("equipsId" + i.ToString(), PlayerPrefs.GetInt("equipsId" + (i+1).ToString()));
                }
                PlayerPrefs.DeleteKey("equipsId" + PlayerPrefs.GetInt("equipsTotal").ToString());
                PlayerPrefs.SetInt("equipsTotal", PlayerPrefs.GetInt("equipsTotal") -1);
            
        }

    }

    public void CriarTermosEvolve(int id, Monster mon){
         
           for (int i = 0; i < mon.evoluir.Count; i++){
                for (int j = 0; j < mon.evoluir[i].termos.Count; j++){
                    
                    PlayerPrefs.SetInt("MValueT" + id.ToString() + "/" + j.ToString(), 0);
                    Debug.Log(mon.evoluir[i].termos[j].tipo + ": " + PlayerPrefs.GetInt("MValueT" + id.ToString() + "/" + j.ToString()));
                }
           }
        
    }

    public void VerificarTermosEvolve(int id, string termo ){
        Monster mon;
       
        if(id == -1){
            mon = MonsterBase.monstro;
            
        }
        else{
            mon = monsterGlobal[PlayerPrefs.GetInt("Mob" + id.ToString())];
        }
        
        for (int i = 0; i < mon.evoluir.Count; i++){
                for (int j = 0; j < mon.evoluir[i].termos.Count; j++){
                    
                    if(mon.evoluir[i].termos[j].tipo == termo){
                        
                       
                        PlayerPrefs.SetInt("MValueT" + id.ToString() + "/" + j.ToString(), PlayerPrefs.GetInt("MValueT" + id.ToString() + "/" + j.ToString()) + 1);
                    }
          
                }
           }
    }

    public void AlterarTermos( int prox, Monster monA, Monster monP){
        termos.Clear();
        for (int i = 0; i < monA.evoluir.Count; i++){
                for (int j = 0; j < monA.evoluir[i].termos.Count; j++){
                      
                       termos.Add(PlayerPrefs.GetInt("MValueT" + (-1).ToString() + "/" + j.ToString()));
                       PlayerPrefs.DeleteKey("MValueT" + (-1).ToString() + "/" + j.ToString());
                    
          
                }
        }
        
       for (int i = 0; i < monP.evoluir.Count; i++){
                for (int j = 0; j < monP.evoluir[i].termos.Count; j++){
                       
                       PlayerPrefs.SetInt("MValueT" + (-1).ToString() + "/" + j.ToString(), 0);
                    
          
                }
        }
        for (int i = 0; i < monA.evoluir.Count; i++){
                for (int j = 0; j < monA.evoluir[i].termos.Count; j++){
                        
                       termos.Add(PlayerPrefs.GetInt("MValueT" + prox.ToString() + "/" + j.ToString()));
                    
          
                }
        }

    }
    
}
