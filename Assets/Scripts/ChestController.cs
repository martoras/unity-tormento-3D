using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChestController : MonoBehaviour
{
    [SerializeField]
    private ItemListSO itemList;
    [SerializeField]
    private RarityListSO rarityList;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Chest: ");
        Debug.Log(other.name);
        var items = Loot();
        foreach (var item in items)
        {
            Instantiate(item.rarity.prefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private List<ItemSO> Loot()
    {
        rarityList.rarities.Sort(
            (RaritySO r, RaritySO s) => r.baseProbability.CompareTo(s.baseProbability));

        var rnd = Random.Range(0f, 100.0f);
        RaritySO lootRarity = rarityList.rarities.Last();
        foreach (var rarity in rarityList.rarities)
        {
            if (rnd < rarity.baseProbability)
            {
                lootRarity = rarity;
                break;
            }
            rnd -= rarity.baseProbability;
        }
        var items = itemList.items.Where((ItemSO so) => so.rarity.name == lootRarity.name).ToList();
        Debug.Log("Loot: ");
        Debug.Log(lootRarity.name);
        Debug.Log(items.First().name);
        return items;
    }
}
