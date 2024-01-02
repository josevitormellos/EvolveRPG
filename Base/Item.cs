using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "evolve/item", order = 0)]
public class Item : ScriptableObject
{
    public int id;
   public string nome;
    public int vida;
    public Sprite icon;
    public string tipo;
    public int peso;
    public int valor;
}
