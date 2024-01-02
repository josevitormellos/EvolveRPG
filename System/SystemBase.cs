using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemBase : MonoBehaviour
{
    public static SystemBase system;
    public GameObject mob;
    public int cont = 0;
    // Start is called before the first frame update
    void Start()
    {
        system = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Viajar(){
        Application.LoadLevel("battler");
        PlayerPrefs.SetInt("x", 299);
        
    }

    public void IncluirMob(int id){
        Dados.instance.IncluirMob(id);
    }

    public void PegarMob(Dialog dialog){
        SystemDialogo.system.InserirDialog(dialog);
    }

    public static void TrocarMob(int cont){
       
        Dados.instance.AlterarMob(cont);
       
    }
}
