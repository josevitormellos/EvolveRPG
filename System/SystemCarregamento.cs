using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SystemCarregamento : MonoBehaviour
{
    public static SystemCarregamento instance;
    public GameObject panelScene, historiaG;
    public Text map, historia;

    void Awake(){
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarCenario(string nome, int nivel = 1){
        panelScene.SetActive(true);
        panelScene.GetComponent<Image>().DOFade(1, 3f).SetEase(Ease.InOutSine).OnComplete(() => {
            map.DOText(Dados.instance.andares[PlayerPrefs.GetInt("dungeon")].nome, 2f, true, ScrambleMode.None, null).SetLoops(2, LoopType.Yoyo).OnComplete(() =>{
                
                Application.LoadLevel(nome);
                PlayerPrefs.SetInt("dungeon", PlayerPrefs.GetInt("dungeon") + 1);
               

            });
        });
        
    }

 


    public void AbrirBook(GameObject book){
        if(book.activeSelf){
            book.SetActive(false);
        }
        else{
             book.SetActive(true);
        }
           
    }
    public void AbrirFade(string texto, float dist){
        if(PlayerPrefs.HasKey("dungeon" + PlayerPrefs.GetInt("dungeon"))){
            CarregarCenario("Base");
        }
        else{
            AbrirBook(panelScene);
            historia.text = texto;
            panelScene.GetComponent<Image>().DOFade(1f, 5f).OnComplete(() => {
            historiaG.transform.DOMoveY(dist, 20f);
            PlayerPrefs.SetInt("dungeon" + PlayerPrefs.GetInt("dungeon"), 1);
            

            });
        }
      
    }
    public void Confirm(GameObject button){
        button.SetActive(false);
        historia.DOFade(0, 3f).OnComplete(() => {
            CarregarCenario("Battler");
           

        });
    }

    public void CarregarScena(){
         panelScene.GetComponent<Image>().DOFade(0f, 3f).OnComplete(() => {
            panelScene.SetActive(false);
           

        });
    }
    
}
