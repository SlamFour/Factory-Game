using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private static GameObject woodAmountText;
    private static GameObject stoneAmountText;
    private static GameObject wheatAmountText;

    public int _level = 0;
    public bool landBought = false;


    private static int _woodAmount = 50;

    public static int WoodAmount
    {
        get {  return _woodAmount; }
        set { 
            _woodAmount = value;
            OnWoodChanged();
        }
    }

    private static void OnWoodChanged()
    {
        ChangeWoodAmount.EditText(WoodAmount.ToString());
    }

    private static int _stoneAmount = 50;

    public static int StoneAmount
    {
        get { return _stoneAmount; }
        set
        {
            _stoneAmount = value;
            OnStoneChanged();
        }
    }

    private static void OnStoneChanged()
    {
        ChangeStoneAmount.EditText(StoneAmount.ToString());
    }

    private static int _wheatAmount = 50;

    public static int WheatAmount
    {
        get { return _wheatAmount; }
        set
        {
            _wheatAmount = value;
            OnWheatChanged();
        }
    }

    private static void OnWheatChanged()
    {
        ChangeWheatAmount.EditText(WheatAmount.ToString());
    }


    private int productionRate;
    private int upgradeCost;


    private float nextUpdate = 0;
    private float updateInterval = 1f;

    private void Update()
    {
        if (Time.time >= nextUpdate) {

            nextUpdate = Time.time + updateInterval;
            SecondUpdate();
        }
    }

    void SecondUpdate()
    {
        switch (gameObject.name)
        {
            case "Forest":
                _woodAmount += productionRate;
                break;
            case "Plains":
                _wheatAmount += productionRate;
                break;
            case "Mountains":
                _stoneAmount += productionRate;
                break;
        }

        //Debug.Log("Amounts: wood " + woodAmount + "stone " + stoneAmount + "wheat " + wheatAmount);
    }


    public void LandBuy()
    {
        landBought = true;
        _level = 1;
    }

    public int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            UpdateStats();
        }
    }

    private void UpdateStats()
    {
        productionRate = _level + (_level * 5);
        upgradeCost = 25 + (_level * 5) - 5;
    }

    // Will result in it only being able to be read.
    public int ProductionRate
    {
        get { return productionRate; }
    }

    public int UpgradeCost
    {
        get { return upgradeCost; }
    }
}
