using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NIslemSonuc
/// </summary>
public class NIslemSonuc<T>
{
    public bool Basarilimi { get; set; }
    public T Veri { get; set; }
    public string Mesaj { get; set; }
    public NHata HataBilgi { get; set; }
}