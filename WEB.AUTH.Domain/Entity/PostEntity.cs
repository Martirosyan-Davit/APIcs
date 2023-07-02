namespace WEB.AUTH.Domain;

public class PostEntity : BaseEntity
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Info { get; set; }
    
    // Many-to-one relation with user
    public string UserId { get; set; }
    public UserEntity User { get; set; }

    // public PostEntity(CreatePostDTO createPostDTO)
    // {
    //     this
    // }
}