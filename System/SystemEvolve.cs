using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemEvolve : MonoBehaviour
{

    public List<GameObject> panels;
    // Start is called before the first frame update
    void Start()
    {
        VerificarPanel();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerificarPanel(){
        for(int i = 0; i < panels.Count; i++){
            if(i == (int)MonsterBase.monstro.specie){
                
                SetupMenu.evolve = panels[i];
            }
           
        }
    }
}
