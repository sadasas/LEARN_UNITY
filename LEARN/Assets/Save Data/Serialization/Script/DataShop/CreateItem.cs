using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public struct ImageItem
{
    public Sprite PedangEskalibur;
    public Sprite celuritSakti;
    public Sprite sevenblestLur;
    public Sprite spearMagic;

    public ImageItem(Sprite pedangEskalibur, Sprite celuritSakti, Sprite sevenblestLur, Sprite spearMagic)
    {
        this.PedangEskalibur = pedangEskalibur;
        this.celuritSakti = celuritSakti;
        this.sevenblestLur = sevenblestLur;
        this.spearMagic = spearMagic;
    }
}

public struct DetailItem
{
    public String detailPedangEskalibur;
    public String detailceluritSakti;
    public String detailsevenblestLur;
    public String detailspearMagic;

    public DetailItem(String detailPedangEskalibur, String detailceluritSakti, String detailsevenblestLur, String detailspearMagic)
    {
        this.detailPedangEskalibur = detailPedangEskalibur;
        this.detailceluritSakti = detailceluritSakti;
        this.detailsevenblestLur = detailsevenblestLur;
        this.detailspearMagic = detailspearMagic;
    }
}

public struct dataShop
{
    public List<Item> allItemInSHop;
}

public class DBShop : DatabaseShop
{
    public List<Item> data = new List<Item>();

    private void UpdateData()
    {
        data = _allItem.allItemInSHOP;
    }

    public void addItem(Item item)
    {
        allitem.allItemInSHOP.Add(item);
        UpdateData();
    }
}

public class DBItem : DatabaseItem
{
    public Item item;
}

public class CreateItem : MonoBehaviour
{
    public static ImageItem imageItem;
    public static DetailItem detailItem;
    private static dataShop data;

    private List<Sprite> listImage;

    //Data public
    public List<Sprite> _listImage { get { return listImage; } }

    public dataShop _data { get { return data; } }

    private DBItem dbItem;
    private DBShop dbShop;

    //value

    [SerializeField] private Sprite pedangEskalibur;
    [SerializeField] private Sprite celuritSakti;
    [SerializeField] private Sprite sevenblestLur;
    [SerializeField] private Sprite spearMagic;

    [SerializeField] private String detailPedangEskalibur;
    [SerializeField] private String detailceluritSakti;
    [SerializeField] private String detailsevenblestLur;
    [SerializeField] private String detailspearMagic;

    private void Awake()
    {
        dbItem = new DBItem();
        dbShop = new DBShop();
    }

    private void Start()
    {
        SetAtributItem();
        dbShop.CeckItemDatabase();
        AddItem();
        UpdateDataShop();
    }

    private void UpdateDataShop()
    {
        data.allItemInSHop = dbShop.data;
    }

    private void SetAtributItem()
    {
        imageItem = new ImageItem(pedangEskalibur, celuritSakti, sevenblestLur, spearMagic);
        detailItem = new DetailItem(detailPedangEskalibur, detailceluritSakti, detailsevenblestLur, detailspearMagic);
        listImage = new List<Sprite> { imageItem.PedangEskalibur, imageItem.celuritSakti, imageItem.sevenblestLur, imageItem.spearMagic };
        data = new dataShop();
    }

    private void AddItem()
    {
        dbItem.item = new Item("Pedang Eskalibur", TypeItem.EPIC, 100, detailItem.detailPedangEskalibur, 0, Owner.SHOP);
        dbShop.addItem(dbItem.item);
        dbItem.item = new Item("Celurit Sakti", TypeItem.RARE, 100, detailItem.detailceluritSakti, 1, Owner.SHOP);
        dbShop.addItem(dbItem.item);
    }
}