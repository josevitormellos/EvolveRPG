using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuConfig : MonoBehaviour
{
    public Slider volume;
    public Slider efeito;

    public AudioSource volumeA;
    public AudioSource efeitoA;

    public Toggle mudo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SairGame(){
        Application.Quit();
    }

    public void Mutar(){
        if(mudo.isOn){
              volumeA.Stop();
            efeitoA.Stop();
        }
        else{
             volumeA.Play();
            efeitoA.Play();
        }
      
    }

    public void AlterarVolume(){
        volumeA.volume = volume.value;
    }
    public void AlterarEfeito(){
        efeitoA.volume = efeito.value;
    } 
}
