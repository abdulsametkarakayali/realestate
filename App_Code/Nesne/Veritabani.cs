using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Veritabani
/// </summary>
public class Veritabani
{
    protected adhibeEntities _entity;
    protected adhibeEntities Entity
    {
        get
        {
            if (_entity == null)
                _entity = new adhibeEntities();
            return _entity;
        }
    }
   
}