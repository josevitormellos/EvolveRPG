using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "evolve/dungeon", order = 1)]
public class Dungeon : ScriptableObject
{
   public string nome;
   public int id;
   public List<Monster> monstros;
   public List<Monster> boss;
   public Sprite map;
   public int xMax;
   public int yMax;
   [TextAreaAttribute]
   public string historia;
   public List<Evento> eventos;


   [System.Serializable]
   public class Evento{
    public int x;
    public int y;
    public string evento;
    
    
    
   }
}
