using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemlerBilgi : MonoBehaviour
{
    public List<ItemlerBilgisi> Itemlerim;
    public Transform slot;
    public GameObject ItemPrefab;
    private void Start()
    {
        ItemVer();
    }
    public void ItemVer()
    {
        for (int i = 0; i < Itemlerim.Count; i++)
        {
            GameObject cogalan = Instantiate(ItemPrefab, slot.transform);
            cogalan.GetComponent<Image>().sprite = Itemlerim[i].Itemphoto;
            cogalan.GetComponent<Tasima>().ItemId = i;
        }
    }
}
[System.Serializable]
public class ItemlerBilgisi
{
    public string ItemName;
    public Sprite Itemphoto;
    public int itemId;
    public int NeydenOlacak;

    public ItemlerBilgisi(string itemName, Sprite itemphoto, int itemId, int neydenOlacak)
    {
        ItemName = itemName;
        Itemphoto = itemphoto;
        this.itemId = itemId;
        NeydenOlacak = neydenOlacak;
    }

}
    

