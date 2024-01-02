using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "evolve/skill", order = 0)]
public class Skill : ScriptableObject
{
    public string nome;
    public int dano;
    public int vida;
    public int mana;
    public Sprite icon;
    public float time;
}
