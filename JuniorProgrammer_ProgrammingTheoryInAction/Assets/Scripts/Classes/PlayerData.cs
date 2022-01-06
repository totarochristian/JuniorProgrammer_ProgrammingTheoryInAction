using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] private string username;
    [SerializeField] private int horses;
    [SerializeField] private int chickens;
    [SerializeField] private int roosters;
    [SerializeField] private int chicks;
    [SerializeField] private int cows;
    public PlayerData()
    {
        this.username = "";
        horses = 0;
        chickens = 0;
        roosters = 0;
        chicks = 0;
        cows = 0;
    }
    public PlayerData(string username)
    {
        this.username = username;
        horses = 0;
        chickens = 0;
        roosters = 0;
        chicks =0;
        cows = 0;
    }
    public PlayerData(PlayerData p)
    {
        username = p.username;
        horses = p.horses;
        chickens = p.chickens;
        roosters = p.roosters;
        chicks = p.chicks;
        cows = p.cows;
    }
    // ENCAPSULATION
    public string GetUsername() { return username; }
    // ENCAPSULATION
    public int GetHorses() { return horses; }
    // ENCAPSULATION
    public int GetChickens() { return chickens; }
    // ENCAPSULATION
    public int GetRoosters() { return roosters; }
    // ENCAPSULATION
    public int GetChicks() { return chicks; }
    // ENCAPSULATION
    public int GetCows() { return cows; }
    // ENCAPSULATION
    public void SetUsername(string var) { username = var; }
    // ENCAPSULATION
    public void SetHorses(int var) { horses = var; }
    // ENCAPSULATION
    public void SetChickens(int var) { chickens = var; }
    // ENCAPSULATION
    public void SetRoosters(int var) { roosters = var; }
    // ENCAPSULATION
    public void SetChicks(int var) { chicks = var; }
    // ENCAPSULATION
    public void SetCows(int var) { cows = var; }
}
