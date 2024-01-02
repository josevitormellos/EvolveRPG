using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatusGlobal : MonoBehaviour
{
    public Text nome, raridade, vida, energia, defesaF, defesaM, ataqueF, ataqueM, velocidade, velocidadeA, critico, chCritico; 
    public Text specialFogo, specialAgua, specialLuz, specialSombra, specialFada, defesaFogo, defesaAgua, defesaLuz, defesaSombra, defesaFada;
    public Image face;

     [SerializeField] private UI_STATUS_RADAR uiStatsRadar;
    private GraphRadarStatus status;

    public void CarregarDados(){
        
        MonsterBase mon = Player.user.monster;

        face.sprite = MonsterBase.monstro.pele;
        nome.text = MonsterBase.monstro.nome;
        raridade.text = MonsterBase.monstro.raridade.ToString();
        vida.text = "Vida : " + mon.vidaM.ToString();
        energia.text = "Energia : " + mon.energiaM.ToString();
        defesaF.text = "Defesa F. : " + mon.defesaF.ToString();
        defesaM.text = "Defesa M. " + mon.defesaM.ToString();
        ataqueF.text = "Ataque F. : " + mon.ataqueF.ToString();
        ataqueM.text = "Ataque M. : " + mon.ataqueM.ToString();
        velocidade.text ="Velocidade : 1";
        velocidadeA.text = "Velocidade A. : " + mon.velocidadeA.ToString();
        critico.text = "Critico : " + mon.critico.ToString();
        chCritico.text = "Chance Cr. : " + mon.chCritico.ToString();
        specialFogo.text = "Special Fogo : " + mon.specialFogo.ToString();
        specialAgua.text = "Special Agua : " + mon.specialAgua.ToString();
        specialSombra.text = "Special Sombra : " + mon.specialSombra.ToString();
        specialLuz.text = "Special Luz : " + mon.specialLuz.ToString();
        specialFada.text = "Special Fada : " + mon.specialFada.ToString();
        defesaAgua.text = "Defesa Agua : " + mon.defesaAgua.ToString();
        defesaFogo.text = "Defesa Fogo : " + mon.defesaFogo.ToString();
        defesaSombra.text = "Defesa Sombra : " + mon.defesaSombra.ToString();
        defesaLuz.text = "Defesa Luz : " + mon.defesaLuz.ToString();
        defesaFada.text = "Defesa Fada : " + mon.defesaFada.ToString();
         status = new GraphRadarStatus(mon.rosa, mon.azul,mon.vermelho,mon.verde, mon.roxo, mon.preto, mon.laranja);
        
        uiStatsRadar.SetStats(status);


    } 
}
