using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphRadarStatus
{
    public event EventHandler onStatsChanged;
    public static int STAT_MIN = 0;
    public static int STAT_MAX = 100;

    public enum Type
    {
        Azul,
        Vermelho,
        Laranja,
        Preto,
        Roxo,
        Verde,
        Rosa,
    }

    private SingleStat rosaStat;
    private SingleStat azulStat;
    private SingleStat vermelhoStat;
    private SingleStat verdeStat;
    private SingleStat roxoStat;
    private SingleStat laranjaStat;
    private SingleStat pretoStat;


    

    public GraphRadarStatus(int rosaStatAmount, int azulStatAmount, int vermelhoStatAmount, int verdeStatAmount, int roxoStatAmount, int pretoStatAmount, int laranjaStatAmount){
        rosaStat = new SingleStat(rosaStatAmount);
        azulStat = new SingleStat(azulStatAmount);
        vermelhoStat = new SingleStat(vermelhoStatAmount);
        verdeStat = new SingleStat(verdeStatAmount);
        pretoStat = new SingleStat(pretoStatAmount);
        laranjaStat = new SingleStat(laranjaStatAmount);
        roxoStat = new SingleStat(roxoStatAmount);
        
      
        
    }

    private SingleStat GetSingleStat(Type statType){
        switch(statType){
            default:
            case Type.Azul: return azulStat;
            case Type.Vermelho: return vermelhoStat;
            case Type.Laranja: return laranjaStat;
            case Type.Preto: return pretoStat;
            case Type.Roxo: return roxoStat;
            case Type.Verde: return verdeStat;
            case Type.Rosa: return rosaStat;
        }
    }

    public void SetStatAmount(Type statType, int statAmount){
        GetSingleStat(statType).SetStatAmount(statAmount);
            
            if (onStatsChanged != null) onStatsChanged(this, EventArgs.Empty);
        }

    public int GetStatAmount(Type statType)
    {
        return GetSingleStat(statType).GetStatAmount();
    }
        public float GetStatAmountNormalized(Type statType){
            return GetSingleStat(statType).GetStatAmountNormalized();
        }

        public void IncreaseStatAmount(Type statType){
            SetStatAmount(statType, GetStatAmount(statType) + 1);
             
        }
        public void DecreaseStatAmount(Type statType){
            SetStatAmount(statType, GetStatAmount(statType) - 1);
             
        }


    private class SingleStat{
        private int stat;


        public SingleStat(int statAmount){
            SetStatAmount(statAmount);
        }
        public void SetStatAmount(int statAmount){
            stat = Mathf.Clamp(statAmount, STAT_MIN, STAT_MAX);
            
        }

        public int GetStatAmount(){
            return stat;
        }

        public float GetStatAmountNormalized(){
            return (float)stat / STAT_MAX;
        }

    }

  
    
}
