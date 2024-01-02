using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class SystemPosition : MonoBehaviour
{
    public int x, y;
    public static SystemPosition system;

    public GameObject enemy;
    public Enemy inimigo;
    public Text description;
    public bool verificar = true;
    public Sprite bau, superbau;
   
    // Start is called before the first frame update
    void Start()
    {
        system = this;
        x = PlayerPrefs.GetInt("x");
        y = PlayerPrefs.GetInt("y");
        MenuBackGround.menu.position.text = "X: " + x.ToString() + " Y: " + y.ToString();
        Player.user.ataque = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnalisarMov(){
        int random = Random.Range(0, 100);
        verificar = false;
        if( random < 50){
            description.text = "Encontrou nada, Continuar andando";
            description.DOFade(255, 1.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>{
                verificar = true;
            });
            
        }
        else if(random < 70){
            Debug.Log("Encontrou Encontramos um grupo menor");
             verificar = true;
            ChamarBando(10);

        }
          else if(random < 80){
            Debug.Log("Encontrou Encontramos um grupo grande");
             verificar = true;
            ChamarBando(20);
         
        }
          else if(random < 90){
            Debug.Log("Encontrou Encontramos um grupo con un boss da Dungeon");
            verificar = true;
            ChamarBando(30);
            
            
        }
        else if(random < 95){
            description.text = "Opa um Bau";
            Bau(bau, 1);
            description.DOFade(255, 1.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>{
                verificar = true;
            });;
            
        }
        else if(random < 97){
            description.text = "Opa um super Bau";
            Bau(superbau , 2);
            description.DOFade(255, 1.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>{
                verificar = true;
            });;
            
        }
        else if(random <= 99){
            description.text = "O mercador";
            description.DOFade(255, 1.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>{
                verificar = true;
            });;
            
        }
    }

    public void Andou(){
        Dungeon dun = SystemRound.instance.dungeon;
        MenuBackGround.menu.position.text = "X: " + x.ToString() + " Y: " + y.ToString();
        if(x == 300 && y == 0){
           // SystemCarregamento.instance.AbrirFade(SystemRound.instance.dungeon.historia, 5f, Dados.instance.andares[1].nome);
            Player.user.battler = false;
            SystemCarregamento.instance.AbrirFade(dun.historia ,3f);
            
            
        }
        else{
            AnalisarMov();
        }
        
    }
    
    public void ChamarBando(int rounds){
            MenuBackGround.menu.AbrirBook(MenuBackGround.menu.systemController);
            SystemCarregamento.instance.AbrirBook(enemy);
            if(x < 100 || y <100){
                SystemRound.instance.nivelMax = 6;
            }
            else{
            SystemRound.instance.nivelMax = (x + y) / 10;
            }
            SystemRound.instance.roundMax = rounds;
            SystemRound.instance.AtualizarInimigo(inimigo); 
            Player.user.ataque = true;
    }
    public void Bau(Sprite bau, int i){
       SystemCarregamento.instance.AbrirBook(MenuBackGround.menu.systemController);
       SystemCarregamento.instance.AbrirBook(MenuBackGround.menu.bau);
        int gold;
       switch(i){
        case 1:
                gold = Random.Range(100, 151);
                break;
        case 2:
                gold = Random.Range(200, 251);
                break;
        default:
                gold = 0;
                break;
       }
        Equip equip = Dados.instance.equipamentoGlobal[Random.Range(0, 8)];
        MenuBackGround.menu.bau.GetComponent<Bau>().AddInfo(equip, gold);
       MenuBackGround.menu.bauSprite.sprite = bau;

    }

    public void AddX(int value){
        Dungeon dun = SystemRound.instance.dungeon;
        if(verificar){
             if(value > 0){
             if(x < dun.xMax ){
                x++;
                Andou();
            
            }
            else{
                Debug.Log("Encontrou seu limite, é a parede da Dungeon a sua frente");
            }
        }
        else{
            if(x > -dun.xMax){
                x--;
                Andou();
            }
            else{
                Debug.Log("Encontrou seu limite, é a parede da Dungeon bem atrás de vocÊ");
            }
        }
        PlayerPrefs.SetInt("x", x);
        }
       
       
        
    }
        public void AddY(int value){
            Dungeon dun = SystemRound.instance.dungeon;
            
            if(verificar){
                if(value > 0){
             if(y < dun.yMax ){
                y++;
                Andou();
            
            }
            else{
                Debug.Log("Encontrou seu limite, é a parede da Dungeon a sua esquerda");
            }
        }
        else{
            if(y > -dun.yMax){
                y--;
                Andou();
            }
            else{
                Debug.Log("Encontrou seu limite, é a parede da Dungeon a sua direita");
            }
        }
       PlayerPrefs.SetInt("y", y);
            }
        
        
    }
}
