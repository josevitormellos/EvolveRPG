using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuBackGround : MonoBehaviour
{
    public  RectTransform player, enemy;
    public Image background, enemyI, playerI, evoluirI, item;
    public Text title, nivel, gold;
    public Slider enemyLife;
    public static MenuBackGround menu; 
    public Item itemUsable;
    public Text position;
    public GameObject status;
    public GameObject panelEvolve, drop, score, carregar, bau;
    public Image bauSprite;  

    public Color dano;
    
    public Sprite invisivel;

    public GameObject systemController;

     public GameObject playerP;
     public ParticleSystem particula, sangue, particulaUp;
     
    /*Bestiario*/
 
     // Start is called before the first frame update
    void Awake(){
        menu = this;
    }
    void Start()
    {

        SystemCarregamento.instance.CarregarScena();
        MenuBackGround.menu.title.text = "Campo de Slimes";
        CarregarImagePlayer();
      
        
             playerP.transform.DOScale(new Vector3(1.05f,1.05f, 1f), 6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        

        
    }

    // Update is called once per frame
    void Update()
    {
        CarregarGold();
    }

    

    public void CarregarStatus( string title, int round){
        this.title.text = title;
        nivel.text = "Round " + round.ToString();
        
    }

    public void CarregarSlideEnemy(Enemy enemy){
        enemyLife.maxValue = enemy.monster.vida;
        enemyLife.DOValue(enemy.vida, 2f);
       
    }

    public void CarregarImageEnemy(Enemy enemy){
        enemyI.sprite = enemy.monster.pele;
        AtualizarReact(this.enemy, enemy.monster);
        AtualizarRotation(this.enemy,enemy.monster, 0 , 180);
        
    }
     public void CarregarImagePlayer(){
        playerI.sprite = MonsterBase.monstro.pele;
        AtualizarReact(player, MonsterBase.monstro);
        AtualizarRotation(player, MonsterBase.monstro, 180, 0);
    }

    public void StartGame(){
        CarregarImageEnemy(Enemy.user);
        CarregarImagePlayer();
        CarregarSlideEnemy(Enemy.user);
    }

    public void AbrirPanelEvolve(){
        if(panelEvolve.activeSelf){
            panelEvolve.SetActive(false);
        }
        else{
            panelEvolve.SetActive(true);
            evoluirI.sprite = MonsterBase.evoluir.pele;
        }
    }

   
    public void Dropar(){
        List<Item> drops = SystemPosition.system.inimigo.monster.drops;
        int random = Random.Range(0, 100);
        if(random >= 80){
            if(drops.Count > 0){
                int rand = Random.Range(0, drops.Count);
                GameObject item = Instantiate(drop, new Vector3(1.3f, -0.2f, 0), Quaternion.identity, gameObject.transform);
                item.GetComponent<Drop>().DropItem(drops[rand]);
            }
        }
        
       
    }

    public void CarregarGold(){
        gold.text = PlayerPrefs.GetInt("gold").ToString();
    }


    public void AbrirBook(GameObject book){
        if(book.activeSelf){
            book.SetActive(false);
        }
        else{
             book.SetActive(true);
        }
           
    }

    public void AtualizarReact(RectTransform tamanho, Monster mon){
        tamanho.sizeDelta = new Vector2 (mon.x,mon.x);
    }
      public void AtualizarRotation(RectTransform tamanho, Monster mon, float rotI, float rotF){
           
            if(mon.inverte ){
             
                tamanho.rotation = Quaternion.Euler(0, rotI, 0);
            }
            else{
                 tamanho.rotation = Quaternion.Euler(0, rotF, 0);
            }
        }

        public void AbrirBau(){
            Player.user.InserirGold(200);
            
        }

        public void ManaParticulas(){
            Instantiate(particula, playerP.transform.position, particula.transform.rotation);
        }
        public void SangueParticula( GameObject obj, ParticleSystem particul, string texto){
            status.GetComponent<Text>().DOFade(255, 0.2f);
        status.GetComponent<Text>().text = "";

        
            status.transform.SetParent(obj.transform);
            status.transform.position = obj.transform.position;
        Vector3 posicao = status.transform.position;
        posicao.y += 1;
        status.transform.position = posicao;
            ParticleSystem partc = Instantiate(particul, new Vector3 (0, 0,0), particula.transform.rotation);
        partc.transform.SetParent(obj.transform);
        partc.transform.position = obj.transform.position;
        partc.transform.localScale = new Vector3(1, 1, 1);
         
        status.GetComponent<Text>().DOText(texto, 1f, true, ScrambleMode.None, null).OnComplete(() => {
            status.GetComponent<Text>().DOFade(0, 1f);
        });
        }





}
