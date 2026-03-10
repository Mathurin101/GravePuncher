using System.Collections;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [Header("Platform")]                              //NumberColumn| 
    [SerializeField] GameObject[] Tiles;//6x8(48)     //            |Letter row  
    //[SerializeField] GameObject[] Tiles;   //            |Letter row  
    //[SerializeField] GameObject[] TilesC2;
    //[SerializeField] GameObject[] TilesC3;
    //[SerializeField] GameObject[] TilesC4;
    //[SerializeField] GameObject[] TilesC5;
    //[SerializeField] GameObject[] TilesC6;
    //[SerializeField] GameObject[] TilesC7;
    //[SerializeField] GameObject[] TilesC8;

    [Header("Environment")]
    [SerializeField] GameObject Item;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        StartCoroutine(SpawnItemOnRow1(Item));
        StartCoroutine(SpawnItemOnRow2(Item));
        StartCoroutine(SpawnItemOnRow3(Item));
        StartCoroutine(SpawnItemOnRow4(Item));
        StartCoroutine(SpawnItemOnRow5(Item));
        StartCoroutine(SpawnItemOnRow6(Item));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnItemOnRow1(GameObject item)
    {
        GameObject NewItemClone;
        //__________________________
        // 8  7  6  5  4  3  2  1  |Column
        // 8A 7A 6A 5A 4A 3A 2A 1A |row A 
        // 8B 7B 6B 5B 4B 3B 2B 1B |row B
        // 8C 7C 6C 5C 4C 3C 2C 1C |row C
        // 8D 7D 6D 5D 4D 3D 2D 1D |row D
        // 8E 7E 6E 5E 4E 3E 2E 1E |row E
        // 8F 7F 6F 5F 4F 3F 2F 1F |row F

        for (int i = 0; i < Tiles.Length; i += 6)
        {
            NewItemClone = Instantiate(item, Tiles[i].transform.position, Tiles[i].transform.rotation);

            Debug.Log("Cloned " + Tiles[i].name + " Spawn at: " + NewItemClone.transform.position.x + ","
                                                              + NewItemClone.transform.position.y + ","
                                                              + NewItemClone.transform.position.z);

            yield return new WaitForSeconds(0.5f);
            Destroy(NewItemClone);
        }

    }

    IEnumerator SpawnItemOnRow2(GameObject item)
    {
        GameObject NewItemClone;
        //__________________________
        // 8  7  6  5  4  3  2  1  |Column
        // 8A 7A 6A 5A 4A 3A 2A 1A |row A 
        // 8B 7B 6B 5B 4B 3B 2B 1B |row B
        // 8C 7C 6C 5C 4C 3C 2C 1C |row C
        // 8D 7D 6D 5D 4D 3D 2D 1D |row D
        // 8E 7E 6E 5E 4E 3E 2E 1E |row E
        // 8F 7F 6F 5F 4F 3F 2F 1F |row F

        for (int i = 1; i < Tiles.Length; i += 6)
        {
            NewItemClone = Instantiate(item, Tiles[i].transform.position, Tiles[i].transform.rotation);

            Debug.Log("Cloned " + Tiles[i].name + " Spawn at: " + NewItemClone.transform.position.x + ","
                                                              + NewItemClone.transform.position.y + ","
                                                              + NewItemClone.transform.position.z);

            yield return new WaitForSeconds(0.5f);
            Destroy(NewItemClone);
        }

    }

    IEnumerator SpawnItemOnRow3(GameObject item)
    {
        GameObject NewItemClone;
        //__________________________
        // 8  7  6  5  4  3  2  1  |Column
        // 8A 7A 6A 5A 4A 3A 2A 1A |row A 
        // 8B 7B 6B 5B 4B 3B 2B 1B |row B
        // 8C 7C 6C 5C 4C 3C 2C 1C |row C
        // 8D 7D 6D 5D 4D 3D 2D 1D |row D
        // 8E 7E 6E 5E 4E 3E 2E 1E |row E
        // 8F 7F 6F 5F 4F 3F 2F 1F |row F

        for (int i = 2; i < Tiles.Length; i += 6)
        {
            NewItemClone = Instantiate(item, Tiles[i].transform.position, Tiles[i].transform.rotation);

            Debug.Log("Cloned " + Tiles[i].name + " Spawn at: " + NewItemClone.transform.position.x + ","
                                                              + NewItemClone.transform.position.y + ","
                                                              + NewItemClone.transform.position.z);

            yield return new WaitForSeconds(0.5f);
            Destroy(NewItemClone);
        }

    }

    IEnumerator SpawnItemOnRow4(GameObject item)
    {
        GameObject NewItemClone;
        //__________________________
        // 8  7  6  5  4  3  2  1  |Column
        // 8A 7A 6A 5A 4A 3A 2A 1A |row A 
        // 8B 7B 6B 5B 4B 3B 2B 1B |row B
        // 8C 7C 6C 5C 4C 3C 2C 1C |row C
        // 8D 7D 6D 5D 4D 3D 2D 1D |row D
        // 8E 7E 6E 5E 4E 3E 2E 1E |row E
        // 8F 7F 6F 5F 4F 3F 2F 1F |row F

        for (int i = 3; i < Tiles.Length; i += 6)
        {
            NewItemClone = Instantiate(item, Tiles[i].transform.position, Tiles[i].transform.rotation);

            Debug.Log("Cloned " + Tiles[i].name + " Spawn at: " + NewItemClone.transform.position.x + ","
                                                              + NewItemClone.transform.position.y + ","
                                                              + NewItemClone.transform.position.z);

            yield return new WaitForSeconds(0.5f);
            Destroy(NewItemClone);
        }

    }
    
    IEnumerator SpawnItemOnRow5(GameObject item)
    {
        GameObject NewItemClone;
        //__________________________
        // 8  7  6  5  4  3  2  1  |Column
        // 8A 7A 6A 5A 4A 3A 2A 1A |row A 
        // 8B 7B 6B 5B 4B 3B 2B 1B |row B
        // 8C 7C 6C 5C 4C 3C 2C 1C |row C
        // 8D 7D 6D 5D 4D 3D 2D 1D |row D
        // 8E 7E 6E 5E 4E 3E 2E 1E |row E
        // 8F 7F 6F 5F 4F 3F 2F 1F |row F

        for (int i = 4; i < Tiles.Length; i += 6)
        {
            NewItemClone = Instantiate(item, Tiles[i].transform.position, Tiles[i].transform.rotation);

            Debug.Log("Cloned " + Tiles[i].name + " Spawn at: " + NewItemClone.transform.position.x + ","
                                                              + NewItemClone.transform.position.y + ","
                                                              + NewItemClone.transform.position.z);

            yield return new WaitForSeconds(0.5f);
            Destroy(NewItemClone);
        }

    }
    
    IEnumerator SpawnItemOnRow6(GameObject item)
    {
        GameObject NewItemClone;
        //__________________________
        // 8  7  6  5  4  3  2  1  |Column
        // 8A 7A 6A 5A 4A 3A 2A 1A |row A 
        // 8B 7B 6B 5B 4B 3B 2B 1B |row B
        // 8C 7C 6C 5C 4C 3C 2C 1C |row C
        // 8D 7D 6D 5D 4D 3D 2D 1D |row D
        // 8E 7E 6E 5E 4E 3E 2E 1E |row E
        // 8F 7F 6F 5F 4F 3F 2F 1F |row F

        for (int i = 5; i < Tiles.Length; i += 6)
        {
            NewItemClone = Instantiate(item, Tiles[i].transform.position, Tiles[i].transform.rotation);

            Debug.Log("Cloned " + Tiles[i].name + " Spawn at: " + NewItemClone.transform.position.x + ","
                                                              + NewItemClone.transform.position.y + ","
                                                              + NewItemClone.transform.position.z);

            yield return new WaitForSeconds(0.5f);
            Destroy(NewItemClone);
        }

    }
}
