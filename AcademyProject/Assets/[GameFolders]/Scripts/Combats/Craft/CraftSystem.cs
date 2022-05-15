using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    public GameObject GelenItem1, GelenItem2;
    public Image Giren1UI, Giren2UI, CikanUI;
    public string IlkId;
    public GameObject ItemlerBilgi;
    public int GelenItem;
    public void ItemGeldi(GameObject gelenItems)
    {
        GelenItem++;
        switch (GelenItem)
        {
            case 1:
                GelenItem1 = gelenItems;
                break;
            case 2:
                GelenItem2 = gelenItems;
                 IlkId += GelenItem1.GetComponent<Tasima>().ItemId;
                 IlkId += GelenItem2.GetComponent<Tasima>().ItemId;
                int countKactane = ItemlerBilgi.GetComponent<ItemlerBilgi>().Itemlerým.Count;
                for (int i = 0; i < countKactane; i++)
                {
                    if (IlkId == ItemlerBilgi.GetComponent<ItemlerBilgi>().Itemlerým[i].NeydenOlacak.ToString())
                    {
                        CikanUI.sprite = ItemlerBilgi.GetComponent<ItemlerBilgi>().Itemlerým[i].Itemphoto;
                    }
                }


                StartCoroutine(Wait());

                GelenItem = 0;
                break;

            
        }
    }
   IEnumerator Wait()
    {
      
        yield return new WaitForSeconds(5); 
        Giren1UI.sprite = null;
        Giren2UI.sprite = null;
        CikanUI.sprite = null;
    }
}
