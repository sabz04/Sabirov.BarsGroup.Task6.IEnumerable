﻿using Sabirov.BarsGroup.Task6.IEnumerable.Collections.Models;
using Sabirov.BarsGroup.Task6.IEnumerable.Models;
using System.Collections;
//Задание 1. Обобщения
GetLogger<Student>();
GetLogger<Photo>();
GetLogger<BarsGroup>();

void GetLogger<T>()
{
    LocalFileLogger<T> logger = new LocalFileLogger<T>();
    logger.LogInfo("info method trigger");
    logger.LogWarning("warning method trigger");
    logger.LogError("error!", new Exception());
}
//Задание 2. Коллекции.
List<Entity> entities = new List<Entity>() {
    new Entity() {Id = 1, ParentId = 0, Name = "Root entity"},
    new Entity() {Id = 2, ParentId = 1, Name = "Child of 1 entity"},
    new Entity() {Id = 3, ParentId = 1, Name = "Child of 1 entity"},
    new Entity() {Id = 4, ParentId = 2, Name = "Child of 2 entity"},
    new Entity() {Id = 5, ParentId = 4, Name = "Child of 4 entity"}
};

var dict = GetEntites(entities);
string ss = "";
foreach (var item in dict)
{
    ss += $"Key = {item.Key}";
    item.Value.ForEach(x => ss += $"Value = List {{Entity {{id = {x.Id}}}}}");
    ss += "\n";
}
Console.Write(ss);

Dictionary<int, List<Entity>> GetEntites(List<Entity> entities)
{
    Dictionary<int, List<Entity>> dict
        = new Dictionary<int, List<Entity>>();
    
    var list = entities
        .GroupBy(x => x.ParentId)
        .Select(y => y.OrderBy(f => f.Id)
        .First())
        .ToList();
    entities.ForEach(x=>dict.Add(x.ParentId, entities
                    .Where(y => y.ParentId == x.ParentId)
                    .ToList()));
    return dict;

}
public class Student{
    public int Id { get; set; }
    public string? Name { get; set; }
}
public class Photo{
    public int Id { get; set; }
    public int? Size { get; set; }
    public byte[]? Data { get; set; }
}
public class BarsGroup{
    public int Id { get; set; }
    public List<Student> students { get; set; } 
}