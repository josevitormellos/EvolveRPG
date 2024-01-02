using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{   
    public static MenuScore menu;
    public Text gold, xp, decisao, bonusT;
   

    void Awake(){
        menu = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarDados(string final, string bonus){
        gold.text = SystemRound.instance.gold.ToString() + " GOLD";
        xp.text = SystemRound.instance.xp.ToString() + "XP";
        decisao.text = final;
        bonusT.text = bonus;
    }

    

  
}
