using SQLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Table("Money")]
public class Money
{
    [PrimaryKey]
    [Column("moneyItemID")]
    public int CollectionItemID { get; set; }

    [Column("count")]
    public int Count { get; set; }

}
