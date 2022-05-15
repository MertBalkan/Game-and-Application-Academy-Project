using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemlerBilgi : MonoBehaviour
{
    public List<ItemlerBilgisi> Itemlerým;
    public Transform slot;
    public GameObject ItemPrefab;
    private void Start()
    {
        ItemVer();
    }
    public void ItemVer()
    {
        for (int i = 0; i < Itemlerým.Count; i++)
        {
            GameObject cogalan = Instantiate(ItemPrefab, slot.transform);
            cogalan.GetComponent<Image>().sprite = Itemlerým[i].Itemphoto;
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

    public ItemlerBilgisi(string ýtemName, Sprite ýtemphoto, int itemId, int neydenOlacak)
    {
        ItemName = ýtemName;
        Itemphoto = ýtemphoto;
        this.itemId = itemId;
        NeydenOlacak = neydenOlacak;
    }

}
    

