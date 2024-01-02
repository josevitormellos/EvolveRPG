using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private UI_STATUS_RADAR uiStatsRadar;
    private GraphRadarStatus status;
    void Start()
    {
        int rosa = Random.Range(0, 100);
        int laranja = Random.Range(0, 100);
        int azul = Random.Range(0, 100);
        int vermelhor = Random.Range(0, 100);
        int verde = Random.Range(0, 100);
        int roxa = Random.Range(0, 100);
        int preto = Random.Range(0, 100);
        status = new GraphRadarStatus(100, 100, 100,100, 100, 100, 100);
        
        uiStatsRadar.SetStats(status);
        
    }

    public void IncreaseRosaStatAmount(){
        status.IncreaseStatAmount(GraphRadarStatus.Type.Rosa);
    }
    public void DecreaseRosaStatAmount(){
        status.DecreaseStatAmount(GraphRadarStatus.Type.Rosa);
    }
     public void IncreaseLaranjaStatAmount(){
        status.IncreaseStatAmount(GraphRadarStatus.Type.Laranja);
    }
    public void DecreaseLaranjaStatAmount(){
        status.DecreaseStatAmount(GraphRadarStatus.Type.Laranja);
    }

}
