using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "evolve/equip", order = 0)]
public class Equip : ScriptableObject
{
   public int id;
     public string nome;
    public Sprite icon;
    public int vida;
    public int mana;
    public int dano;
    public int defesa;
    public float velocidade;
    public int gold;
    public Equips tipo;

   public enum Equips {Arma, Armadura, Botas};

}
