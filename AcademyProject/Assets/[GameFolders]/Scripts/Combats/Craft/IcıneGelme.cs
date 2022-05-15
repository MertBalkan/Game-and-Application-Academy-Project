using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IcıneGelme : MonoBehaviour
{
    public GameObject ItemlerBilgi;
    public GameObject CraftSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            this.GetComponent<Image>().sprite = ItemlerBilgi.GetComponent<ItemlerBilgi>().Itemlerım[collision.GetComponent<Tasima>().ItemId].Itemphoto;
            CraftSystem.GetComponent<CraftSystem>().ItemGeldi(collision.gameObject);
            collision.gameObject.GetComponent<Image>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
