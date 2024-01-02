using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialog", menuName = "Evolve Monster/Dialog", order = 0)]
public class Dialog : ScriptableObject {
    public int id;
    public string nome;
    public Sprite pele;
    public List<string> dialog;
    public bool invertido;
}

