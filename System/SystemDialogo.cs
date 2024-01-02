using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SystemDialogo : MonoBehaviour
{
    public static SystemDialogo system;
    public Text dialog, name, button;
    public Dialog global;
    public GameObject mob;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        system = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ConfirmarId(){
        switch(global.id){
            case 2: 
                Dados.instance.IncluirMob(21);
                SystemBase.system.mob.SetActive(false);
                Dados.instance.BuscarMobs();
                break;
            default:
                break;
        }
    }

    public void InserirDados(string nick, string texto)
    {
        
        dialog.text = texto;
        name.text = nick;
    }
    public void InserirDialog(Dialog info){
        global = info;
        InserirDados(global.nome, global.dialog[0]);
        if(global.invertido){
            mob.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 180, 0);
        }
        else{
            mob.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
        }
        mob.GetComponent<Image>().sprite = global.pele;
        count = 0;
        ProximoDialog();
        
    }
    public void ProximoDialog(){
        count++;
        if(count >= global.dialog.Count){
            button.text = "Confirmar";
        }
        else{
            button.text = "Continuar";
        }

    }
    public void InformarDialog(){
        if(count >= global.dialog.Count){
            ConfirmarId();
            this.gameObject.SetActive(false);
        } 
        else{
            InserirDados(global.nome, global.dialog[count]);
            ProximoDialog();
        }
    }
}
