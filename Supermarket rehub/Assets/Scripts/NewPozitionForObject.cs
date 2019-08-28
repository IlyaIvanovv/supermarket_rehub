using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class NewPozitionForObject : MonoBehaviour
{
    private List<Product> Products = new List<Product>();//{ "Water", "cook", "AppleBox", "Tee"};

    [SerializeField]
    private Text ProductText;

    class Product
    {
        public string Tag;
        public string Name;

        public Product(string tag, string name)
        {
            Tag = tag;
            Name = name;
        }

    }

    private void Start()
    {
        Products.Add(new Product("Water", "Вода в оранжевой бутылке"));
        Products.Add(new Product("AppleBox", "Яблоки в зеленой упаковке"));
        Products.Add(new Product("Tee", "Чай"));
        Products.Add(new Product("cook", "Печенье"));

        UpdateText();

    }


    void OnTriggerEnter(Collider col)
    {
        int Ind = Products.IndexOf(Products.FirstOrDefault(a => a.Tag == col.tag));
        if (Ind != -1)
        {
            col.GetComponent<Rigidbody>().isKinematic = true;
            //GetComponent<FixedJoint>().connectedBody = col.gameObject.GetComponent<Rigidbody>();
            col.gameObject.transform.parent = transform;
            if (Products[Ind].Name.Substring(Products[Ind].Name.Length - 7) != "Куплено")
                Products[Ind].Name += " - Куплено";
            UpdateText();
        }
    }

    void UpdateText()
    {
        ProductText.text = "";
        foreach(Product p in Products)
        {
            ProductText.text += p.Name + "\n";
        }
    }
}
