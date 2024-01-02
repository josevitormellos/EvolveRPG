using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class SystemTime : MonoBehaviour
{
    public Tempo clima;
    public float time;
    public int x,y,z, total;


    //Lua
    public GameObject lua;
    public bool luaBool = false;
   

    public Image background, player, enemy;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 0.5f;

        switch((int) clima){
            case 1:
                Dia();
                break;
            case 2:
                Diurno();
                break;
            case 3:
                Sangrento();
                break;
            case 4:
                NuvemAcido();
                break;
            default:
                break;
        }
    }


    public void Diurno(){
       if(time > 0.5f){
        if(x > 63){
            x--;
        }
        if(y > 43){
            y--;
             if(y ==80){
                
                if(!luaBool){
                    
                    lua.transform.DOMoveY(1.8f, 70f).SetLoops(2, LoopType.Yoyo).OnComplete(() => {
                        luaBool = false;
                    });
                    luaBool = true;
                    
                }
            }
        }
        if(z > 79){
            z--;
        }
       
        total ++;
         time = 0;
         CarregarColor();
       }
       
       if(total >= 400){
        
        

        clima = Tempo.Dia;
        total = 0;
       }
        
       
    }

    public void Dia(){
       if(time > 0.5f){
        if(x < 255){
            x++;
        }
        if(y < 255){
            y++;
             if(y ==180){
                
            }
        }
        if(z < 255){
            z++;
        }
      
        total ++;
        time = 0;
        CarregarColor();
       }
       
       if(total >= 400){
         int random = Random.Range(2, 5);
        switch(random){
           
            case 2:
                clima = Tempo.Noite;
                break;
            case 3:
               clima = Tempo.LuaSangrenta;
                break;
            case 4:
                 clima = Tempo.NuvemAcida;
                break;
            default:
                break;
        }

        total = 0;
       }
        
       
    }
    public void Sangrento(){
        if(time > 0.5f){
                if(x > 207){
                    x--;
                }
                if(y > 74){
                    y--;
                }
                if(z > 95){
                    z--;
                }
                total ++;
                time = 0;
                CarregarColor();
            }
            
            if(total >= 400){
                clima = Tempo.Dia;
                total = 0;

            }
        
    }

    public void NuvemAcido(){
              if(time > 0.5f){
                if(x > 109){
                    x--;
                }
                if(y > 133){
                    y--;
                }
                if(z > 103){
                    z--;
                }
                total ++;
                time = 0;
                CarregarColor();
            }
            
            if(total >= 400){
                clima = Tempo.Dia;
                total = 0;

            }

    }

    public enum Tempo{
        Dia = 1,
        Noite = 2,
        LuaSangrenta = 3,
        NuvemAcida = 4
    }

    public void CarregarColor(){
         background.color = new Color32((byte)x,(byte)y,(byte)z,(byte)255);
        player.color =  new Color32((byte)x,(byte)y,(byte)z,(byte)255);
        enemy.color =  new Color32((byte)(x - 5),(byte)(z - 5),(byte)(y - 5),(byte)255);
    }
}
