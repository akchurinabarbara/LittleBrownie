using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite;

[Table("Collection")]
public class Collection 
{
   [PrimaryKey]
   [Column("collectionItemID")]
   public int CollectionItemID { get; set; }

    [Column("count")]
    public int Count { get; set; }

}
