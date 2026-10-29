using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Product
{
    public string Name;
    public float Price;
}

public class Variabletest : MonoBehaviour
{
   [SerializeField] public int shopIndex = 0;

   #region INCAPSULAMENTO
   //INCAPSULAMENTO
   public int ShopIndex => shopIndex;
   public int ShopIndex2;
   #endregion
   //
   [SerializeField] float Shoprevenues = 50.5f;
   [SerializeField] bool shopOpen = false;

   enum ShopState {OPENING = 0, SELLING, RESTOCKING, CLOSING};

    [SerializeField] ShopState shopStateBase = ShopState.OPENING;
    [SerializeField] ShopState shopStateAdvanced = ShopState.RESTOCKING;

    [SerializeField] string shopName = "shop";

    [SerializeField] int[] productArray = new int[5];
    [SerializeField] List<int> productList = new List<int>();

    Dictionary<string, float> productDictionary = new Dictionary<string, float>();
    HashSet<Product> productsHashSet = new HashSet<Product>(); 

    [SerializeField] List<Product> productsList = new List<Product>();

}