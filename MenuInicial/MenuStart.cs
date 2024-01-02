using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuStart : MonoBehaviour
{
    public static MenuStart menu;
    public GameObject button;
    public Color cor, scene;
    public Text title;
    public GameObject background, text;
    public string historia;



    void Awake(){
        menu = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        InicialContinuar();
        background.transform.DOScale(1.4f, 30f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        text.transform.DOScale(1.05f, 3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        title.DOColor(cor, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        SystemCarregamento.instance.CarregarScena();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Iniciar(){
        PlayerPrefs.DeleteAll();
       
        for(int i = 0; i < Dados.instance.monsterGlobal.Count; i++){
            Dados.instance.monsterGlobal[i].visible = false;
        }
      
        PlayerPrefs.SetInt("dungeon", 0);
        PlayerPrefs.SetInt("gold", 0);
        Dados.instance.IniciarGame();
        Player.user.monster.IniciarStatus(MonsterBase.monstro);
        Continuar();
        
    }

    public void InicialContinuar(){
        if(PlayerPrefs.HasKey("MobPrincipal")){
            button.SetActive(true);
        }
    }
    public void Continuar(){
        Dados.instance.BuscarMobs();
        Dados.instance.IniciarItens();
       
    }

    public void AndarTexto(){
        SystemCarregamento.instance.AbrirFade(historia, 3f);
    }

    

    
}
