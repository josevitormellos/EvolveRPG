using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drop : MonoBehaviour
{   
    public Item item;
    public static bool drop = false;
    public float time = 0;
    public float random;
    public float spac;
    
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0.3f, 1f);
        int rand = Random.Range(0, 2);
        if(rand == 0){
            spac =  0.001f ;
        }
        else{
            spac =  0.001f * (-1f);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(time < 4f){
            if(time <= 1f){
                gameObject.transform.localScale =new Vector3(time, time, time);
            }
            if(time < random){
                gameObject.transform.position = new Vector3(gameObject.transform.position.x +spac, gameObject.transform.position.y + 0.001f, gameObject.transform.position.z);
            }
            time += Time.deltaTime * 0.8f;
        }
        else{
            Destroir();
        }
    }

    public void Destroir(){
        Dados.instance.AddItem(item.id);
     
        Destroy(gameObject);
    }
    public void DropItem(Item item){
        this.item = item;
        gameObject.GetComponent<Image>().sprite = this.item.icon;
    }
}
