using Sabirov.BarsGroup.Task6.IEnumerable.Collections.Models;


List<Entity> entities = new List<Entity>() { 
    new Entity() {Id = 1, ParentId = 0, Name = "Root entity"},
    new Entity() {Id = 2, ParentId = 1, Name = "Child of 1 entity"},
    new Entity() {Id = 3, ParentId = 1, Name = "Child of 1 entity"},
    new Entity() {Id = 4, ParentId = 2, Name = "Child of 2 entity"},
    new Entity() {Id = 5, ParentId = 4, Name = "Child of 4 entity"}
};

var dict = GetEntites(entities);
string ss = "";
foreach(var item in dict)
{
    ss += $"Key = {item.Key} ";
    foreach(var entity in item.Value)
    {
        ss += $"Value = List {{Entity {{id = {entity.Id}}}}} ";
        
    }
    ss += "\n";
}
Console.Write(ss);

Dictionary<int, List<Entity>> GetEntites(List<Entity> entities)
{
    Dictionary<int, List<Entity>> dict 
        = new Dictionary<int, List<Entity>>();
    var list = entities
        .GroupBy(x=>x.ParentId)
        .Select(y => y.OrderBy(f => f.Id)
        .First())
        .ToList();
    foreach(var item in list)
    {
        dict.Add(item.ParentId, entities
                    .Where(x=>x.ParentId == item.ParentId)
                    .ToList());
    }
    return dict;

}