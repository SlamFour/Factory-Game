using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGen : MonoBehaviour
{
    public GameObject desertTile;
    public GameObject plainsTile;
    public GameObject forestTile;
    public GameObject mountainTile;

    public int tileAmount;
    public int incrementValue = 0;

    public int posX = 0;
    public int posZ = 0;

    public int rng;



    enum Dir
    {
        Up,
        Right,
        Left,
        Down
    }

    Dir currentDir = Dir.Up;
    // Start is called before the first frame update
    void Start()
    {
        loadMap();
    }

    public void loadMap()
    {
        for(int i = 0; i < tileAmount; i++)
        {

            for (int j = 0; j < 2; j++)
            {


                for (int k = 0; k < incrementValue; k++)
                {
                    rng = Random.Range(1, 5);

                    switch (rng)
                    {
                        case 1:
                            GameObject newDesertTile = Instantiate(desertTile, new Vector2(posX, posZ), Quaternion.identity);
                            // For setting generic name instead of have the (clone) affix
                            newDesertTile.name = "Desert";
                            // Inserting the stats for levels and productionRate
                            newDesertTile.AddComponent<Stats>();
                            break;
                        case 2:
                            GameObject newPlainsTile =  Instantiate(plainsTile, new Vector2(posX, posZ), Quaternion.identity);
                            newPlainsTile.name = "Plains";

                            newPlainsTile.AddComponent<Stats>();
                            break;
                        case 3:
                            GameObject newForestTile = Instantiate(forestTile, new Vector2(posX, posZ), Quaternion.identity);
                            newForestTile.name = "Forest";

                            newForestTile.AddComponent<Stats>();
                            break;
                        case 4:
                            GameObject newMountainTile = Instantiate(mountainTile, new Vector2(posX, posZ), Quaternion.identity);
                            newMountainTile.name = "Mountain";

                            newMountainTile.AddComponent<Stats>();
                            break;
                    }

                    switch(currentDir)
                    {
                        case Dir.Up:
                            posX ++;
                            break;
                        case Dir.Right:
                            posZ ++;
                            break;
                        case Dir.Down:
                            posX --;
                            break;
                        case Dir.Left:
                            posZ --;
                            break;
                    }
                }

                switch (currentDir)
                {
                    case Dir.Up:
                        currentDir = Dir.Right;
                        break;
                    case Dir.Right:
                        currentDir = Dir.Down;
                        break;
                    case Dir.Down:
                        currentDir = Dir.Left;
                        break;
                    case Dir.Left:
                        currentDir = Dir.Up;
                        break;
                }
                tileAmount -= incrementValue;
            }
            incrementValue++;
        }
    }
}

