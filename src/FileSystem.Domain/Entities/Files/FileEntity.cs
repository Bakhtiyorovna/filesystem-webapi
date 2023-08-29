namespace FileSystem.Domain.Entities.Files;

public class FileEntity
{
    public long Id { get; set; }
    public string FileName { get; set; }
    public byte[] FileBytea { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
