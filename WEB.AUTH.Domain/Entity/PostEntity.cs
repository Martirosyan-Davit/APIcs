using System.ComponentModel.DataAnnotations.Schema;
using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.Domain;
[Table("post")]
public class PostEntity : BaseEntity
{
    [Column]
    public string Title { get; set; }
    
    [Column]
    public string Description { get; set; }

    [Column]
    public string Info { get; set; }
    
    // Many-to-one relation with user
    public string UserId { get; set; }
    public UserEntity User { get; set; }

    // public PostEntity(CreatePostDTO createPostDTO)
    // {
    //     this
    // }
}