using SQLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Table("Inventory")]
public class Inventory 
{
    [PrimaryKey]
    [Column("inventoryItemID")]
    public int InventoryItemID { get; set; }

    [Column("count")]
    public int Count { get; set; }

}
