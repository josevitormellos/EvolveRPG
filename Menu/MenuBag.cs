using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBag : MonoBehaviour
{   public static MenuBag menu;
    public List<Image> itens;
    public List<Text> quants;
    public Sprite invisSprite;
    public static Sprite invisivel;

    public Image visible;
    public Text name, descript, gold;
    public Item item;
    public int idItem;
    public GameObject panel;
    // Start is called before the first frame update
    void Awake(){
        invisivel = invisSprite;
        menu = this;
    }
    
    void Start()
    {
        
        Reiniciar();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar(){
        List<Item> itens = Player.user.itens;
        for(int i = 0; i < 24; i ++){
            if(itens.Count > i ){
                quants[i].text = PlayerPrefs.GetInt("itensQuant" + i.ToString()).ToString() + "x";
                this.itens[i].sprite = itens[i].icon;
            }
            else{
                quants[i].text = "";
                this.itens[i].sprite = invisivel;
            }
          
        }
    }

    public void VisibleItem(int i){
        List<Item> itens = Player.user.itens;
        if( i < itens.Count){
            Debug.Log("entrei mais");
            panel.SetActive(true);
            item = itens[i];
            name.text = item.nome;
            visible.sprite = item.icon;
            descript.text = "Recupera " + item.vida.ToString() + " de Vida";
            gold.text = "Vender " + item.valor;
            PlayerPrefs.SetInt("posItem", i);
            
        }
    }
    public void UsarItem(){
        CarregarLife(Player.user.monster);
        Dados.instance.VerificarTermosEvolve(-1, item.tipo);
    }

    public void CarregarLife(MonsterBase player){
        
        if(player.vida + item.vida >= player.vidaM){
            player.vida = player.vidaM;
        }
        else{
            player.vida += item.vida;
        }
        Dados.instance.DeletarItem(PlayerPrefs.GetInt("posItem"));
        Reiniciar();
        panel.SetActive(false);
        MenuStatus.menu.CarregarVida(player);
    }

    public void Vender(){
        Player.user.gold += item.valor;
        PlayerPrefs.SetInt("gold", Player.user.gold);
        Dados.instance.DeletarItem(PlayerPrefs.GetInt("posItem"));
        Reiniciar();
        MenuBackGround.menu.CarregarGold();
    }
    public void AtualizaAutomatico(){
        if(gameObject.activeSelf){
            Reiniciar();
        }
    }
}
