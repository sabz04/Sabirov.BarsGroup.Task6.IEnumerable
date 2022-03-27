using Sabirov.BarsGroup.Task6.IEnumerable.Models;
using System.Collections;
File.Delete(LocalFileLogger<Student>.path);

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