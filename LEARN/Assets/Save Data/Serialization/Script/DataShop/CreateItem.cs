using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : DatabaseShop
{
    private List<Item> itemAvailable = new List<Item>();

    private Sprite pedangEskalibur;
    private Sprite celuritSakti;
    private Sprite sevenblestLur;
    private Sprite spearMagic;

    private String detailPedangEskalibur;
    private String detailceluritSakti;
    private String detailsevenblestLur;
    private String detailspearMagic;
    public List<Item> _itemAvailable { get { return itemAvailable; } }

    public CreateItem(Sprite pedangEskalibur, Sprite celuritSakti, Sprite sevenblestLur, Sprite spearMagic, String detailPedangEskalibur, String detailceluritSakti, String detailsevenblestLur, String detailspearMagic)
    {
        this.pedangEskalibur = pedangEskalibur;
        this.celuritSakti = celuritSakti;
        this.sevenblestLur = sevenblestLur;
        this.spearMagic = spearMagic;
        this.detailPedangEskalibur = detailPedangEskalibur;
        this.detailceluritSakti = detailceluritSakti;
        this.detailsevenblestLur = detailsevenblestLur;
        this.detailspearMagic = detailspearMagic;
    }

    public void AddItem()
    {
        //item = new Item("Pedang", TypeItem.RARE, 1000);
        allitem.allItemInSHOP.Add(item);
    }

    public void DefaultItem()
    {
        item = new Item("Pedang", TypeItem.RARE, 1000, pedangEskalibur, detailPedangEskalibur);
        allitem.allItemInSHOP.Add(item);
        item = new Item("tt", TypeItem.RARE, 1000, celuritSakti, detailceluritSakti);
        allitem.allItemInSHOP.Add(item);
        item = new Item("dd", TypeItem.RARE, 1000, spearMagic, detailspearMagic);
        allitem.allItemInSHOP.Add(item);
        /* item = new Item("dd", TypeItem.RARE, 1000);
         allitem.allItemInSHOP.Add(item);*/
    }

    public override DatabaseAdded CeckItemDatabase()
    {
        if (_isExist == base.CeckItemDatabase())
        {
            itemAvailable = _allItem.allItemInSHOP;
        }
        return base.CeckItemDatabase();
    }

    public override void Update()
    {
    }
}