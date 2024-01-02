using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemRound : MonoBehaviour
{
    public int round =0;
    public int roundMax, nivelMax;
    public string title;
    public List<Sprite> background;
    public Dungeon dungeon;
    public static SystemRound instance;
    public string bonus;
    public int gold, xp;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        dungeon = Dados.instance.andares[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarDados(){
        round ++;
        MenuBackGround.menu.CarregarStatus(title, round);
       
    }

    public void AtualizarInimigo(Enemy enemy){
        int random = Random.Range(0, dungeon.monstros.Count);
        if(round > 1){
             MenuBackGround.menu.Dropar();
        }
        CarregarDados();
        Dados.instance.VerificarTermosEvolve(-1, enemy.monster.specie.ToString());
        Dados.instance.VerificarTermosEvolve(-1, enemy.monster.nome.ToLower());
        if(round > roundMax && roundMax > 0){
            round = 0;
            Bonus();
            DerrotouBando();

        }
        else{
              
         if(round%10 == 0){
            if(round/10 <= dungeon.boss.Count){
                 enemy.monster = dungeon.boss[round/10-1];
                 enemy.AlterarBoss(true);       
                    
            }
         }
         else{
            enemy.monster = dungeon.monstros[random];
            enemy.AlterarBoss(false);   
            
         }
        enemy.CarregarNivel(nivelMax);
        enemy.CarregarStatus(enemy.nivel);
        MenuBackGround.menu.CarregarSlideEnemy(enemy);
        MenuBackGround.menu.CarregarImageEnemy(enemy);
        
                   
        
        }
       
       
      
       
    }

    public void DerrotouBando(){
        SystemCarregamento.instance.AbrirBook(SystemPosition.system.enemy);
        SystemCarregamento.instance.AbrirBook(MenuBackGround.menu.systemController);
        SystemCarregamento.instance.AbrirBook(MenuBackGround.menu.score);
        MenuScore.menu.CarregarDados("Vitoria", bonus);
            
            Player.user.ataque = false;
    }

      public void CarregarRounds(){
        gold = 0;
        xp = 0;
    }
        public void Bonus(){
            Debug.Log(roundMax);
            int taxa = 0;
            switch (roundMax)
            {
                case 10:
                    taxa = 50;
                    break;
                case 20:
                    taxa = 80;
                    break;
                case 30:
                    taxa = 100;
                    break;
                default:
                    break;
            }
            Debug.Log(taxa);
            int xp = this.xp*taxa/100;
            int gold = this.gold*taxa/100;
            bonus = "Gold Extra:. " + gold.ToString();
            bonus += "\nXp Extra:. " + xp.ToString();
            int random = Random.Range(0, taxa);
            if(taxa >= 20){
                
                int equip = Random.Range(0, 6);

               string nome = Dados.instance.AddEquip(equip);
                bonus+= "\nEquipamento:." + nome;
            }
            Player.user.monster.Up(xp);
            Player.user.InserirGold(gold);

            
        }
}
