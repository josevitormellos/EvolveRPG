using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "evolve/monster", order = 0)]
public class Monster : ScriptableObject
{

    public int id;
    public string nome;
    public List<Evoluir> evoluir;

    /*
        STATUS BASE
    */
    public int vida;
    public int energia;
    public int ataqueF;
    public int specialE;
    public int defesaF;
    public int defesaE;
    
    public float chanceCritico;
    public float critico;
    public float velocidade;
    public int velocidadeM;

    /*
        STATUS ELEMENTAL
    */
    public float specialFogo;
    public float specialAgua;
    public float specialLuz;
    public float specialSombra;
    public float specialFada;

    public float defesaFogo;
    public float defesaAgua;
    public float defesaLuz;
    public float defesaSombra;
    public float defesaFada;

    

    
    
    public Sprite pele;
    public int gold;
    public int xp;
   
    public List<Skills> skills;
    public bool visible;
    public Raridade raridade;
    public float x;
    public bool inverte;
    public Specie specie;


    public List<Item> drops;

[System.Serializable]
public class Skills{
    public int nivel;
    public Skill skill;
}

[System.Serializable]
public class Evoluir{
    public Monster monstro;
    public int nivel;
    public List<Termos> termos;
    public string description;
    
    
}
[System.Serializable]
public class Termos{
    public string tipo;
    public int quantidade;
}

public enum Raridade{
    D = 1,
    C = 2,
    B = 3,
    A = 4,
    S = 5,
    SR = 6,
    SSR = 7,
    UR = 8
}

public enum Specie{
    Slime = 0,
    Golem = 1,
    Extras = 2,

    Plant = 3,
    Fish = 4
}




}


