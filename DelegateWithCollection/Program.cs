using System;
using System.Collections.Generic;

var Heros = new List<Hero>
        {
            new("wade", "william","Deadpool", false),
            new(string.Empty,string.Empty,"Superman",true),
            new("Bruce","wayen","Batman",false),
            new(string.Empty,string.Empty,"Homelander",true)
        };

var result = Filter(Heros, h => h.canFly);
var herosWhoCanFly = string.Join(',', result);
Console.WriteLine(herosWhoCanFly);

IEnumerable<T> Filter<T>(IEnumerable<T> items, filterfunc<T> f)
{
    foreach (var item in items)
    {
        if (f(item))
        {
            yield return item;
        }
    }
}

delegate bool filterfunc<T>(T item);


record Hero(string firstName, string lastName, string HeroName, bool canFly);
