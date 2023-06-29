using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite;

[Table("Energy")]
public class Energy
{
    [PrimaryKey]
    [Column("ID")]
    public int ID { get; set; }

    [Column("count")]
    public int count { get; set; }
}
