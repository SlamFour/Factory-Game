using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseHit : MonoBehaviour
{
    // Windows for buying
    public GameObject LogFactory;
    public GameObject Farm;
    public GameObject Mine;

    // Windows for upgrading
    public GameObject LogFactoryUp;
    public GameObject FarmUp;
    public GameObject MineUp;

    private GameObject focusedTile;
    public Stats tileStats;

    public Vector3 position;

    public bool landBought;

    private GameObject newLogFactory;
    private GameObject newMine;
    private GameObject newFarm;

    Ray ray;
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void DestroyAllShops()
    {
        Destroy(newLogFactory);
        Destroy(newMine);
        Destroy(newFarm);
    }

    public void InstantiateLogFactory()
    {
        DestroyAllShops();

        if (landBought)
        {
            newLogFactory = Instantiate(LogFactoryUp, new Vector2(position.x, position.y + 1.75f), Quaternion.identity);
            newLogFactory.name = "LogFactoryUpgrade";
        }
        // Open buy window if land hasn't been bought yet
        else
        {
            newLogFactory = Instantiate(LogFactory, new Vector2(position.x, position.y + 1.75f), Quaternion.identity);
            newLogFactory.name = "LogFactory";
        }
    }

    public void InstantiateMine()
    {
        DestroyAllShops();

        if (landBought)
        {
            newFarm = Instantiate(MineUp, new Vector2(position.x, position.y + 1.75f), Quaternion.identity);
            newFarm.name = "MineUpgrade";
        }
        else
        {
            newMine = Instantiate(Mine, new Vector2(position.x, position.y + 1.75f), Quaternion.identity);
            newMine.name = "Mine";
        }
    }

    public void InstantiateFarm()
    {
        DestroyAllShops();
        if (landBought)
        {
            newFarm = Instantiate(FarmUp, new Vector2(position.x, position.y + 1.75f), Quaternion.identity);
            newFarm.name = "FarmUpgrade";
        }
        else
        {
            newFarm = Instantiate(Farm, new Vector2(position.x, position.y + 1.75f), Quaternion.identity);
            newFarm.name = "Farm";
        }
    }


    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.GetRayIntersection(ray);

        if(hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;

            if (Input.GetMouseButtonDown(0))
            {
                position = hitObject.transform.position;

                focusedTile = hitObject;

                // To check if the focused tile's land has already been bought, so to open the upgrade window I/O the buy window

                if (hitObject.name == "Forest" || hitObject.name == "Plains" || hitObject.name == "Mountain")
                {
                    tileStats = focusedTile.GetComponent<Stats>(); // Assign the component to the existing tileStats variable
                    landBought = focusedTile.GetComponent<Stats>().landBought;


                    switch (hitObject.name)
                    {
                        case "Forest":
                            InstantiateLogFactory();
                            break;

                        case "Plains":
                            InstantiateFarm();
                            break;

                        case "Mountain":
                            InstantiateMine();
                            break;
                    }
                }

                if (hitObject.name == "LogBuy")
                {
                    Debug.Log("Log bought");
                    if (Stats.WoodAmount >= 50)
                    {
                        tileStats.LandBuy();
                        Stats.WoodAmount -= 50;

                        InstantiateLogFactory();
                    }
                }

                if (hitObject.name == "FarmBuy")
                {
                    Debug.Log("Farm bought");
                    if (Stats.WheatAmount >= 50)
                    {
                        tileStats.LandBuy();
                        Stats.WheatAmount -= 50;

                        InstantiateFarm();
                    }
                }

                if (hitObject.name == "MineBuy")
                {
                    if (Stats.StoneAmount >= 50)
                    {
                        Debug.Log("Mine bought");
                        tileStats.LandBuy();
                        Stats.StoneAmount -= 50;

                        InstantiateMine();
                    }
                }

            }
        }
    }
}
