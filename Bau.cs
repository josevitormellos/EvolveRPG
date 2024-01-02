using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bau : MonoBehaviour
{
    public int gold;
    public Equip equipamento;

    public Image icon;
    public Text nome, goldT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddInfo( Equip equip, int value){
        equipamento = equip;
        gold = value;
    }

    public void CarregarInfo(){
        icon.sprite = equipamento.icon;
        nome.text = equipamento.nome;
        goldT.text = "Gold Encontrado \n" + gold.ToString();
    }
    public void InfoConfirm(){
        Player.user.InserirGold(gold);
        Dados.instance.AddEquip(equipamento.id - 1);
    }
}
