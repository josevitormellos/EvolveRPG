using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupMenu : MonoBehaviour
{

    public GameObject status, bag, equips;
    public static GameObject evolve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMoonPanels(){
        status.SetActive(false);
        
        bag.SetActive(false);
        equips.SetActive(false);
        evolve.SetActive(false);
    }

    public void LigarPanel(GameObject panel){
        SetMoonPanels();
        panel.SetActive(true);
    }
    public void LigarEvolve(){
        SetMoonPanels();
        evolve.SetActive(true);
    }
}
