using _9Dars.Models;
namespace _9Dars.Services;

public class PostService
{
    private List<Post> posts;

    public PostService()
    {
        posts = new List<Post>();
    }

    public Post AddPost(Post post)
    {
        post.Id = Guid.NewGuid();
        posts.Add(post);

        return post;
    }

    public Post GetPostById(Guid postId)
    {
        foreach (var post in posts)
        {
            if (post.Id == postId)
            {
                return post;
            }
        }
        return null;
    }
    public bool DeletePost(Guid postId)
    {
        var postFromDb = GetPostById(postId);
        if (postFromDb is null)
        {
            return false;
        }
        posts.Remove(postFromDb);
        return true;
    }

    public bool UpdatePost(Post updatingPost)
    {
        var postFromDb = GetPostById(updatingPost.Id);
        if (postFromDb is null)
        {
            return false;
        }
        var index = posts.IndexOf(postFromDb);
        posts[index] = updatingPost;
        return true;
    }

    public List<Post> GetAllPosts()
    {
        return posts;
    }


    public Post GetMostViewedPost()
    {
        var responsePost = new Post();

        foreach (var post in posts)
        {
            if (responsePost.ViewerNames.Count < post.ViewerNames.Count)
            {
                responsePost = post;
            }
        }

        return responsePost;
    }

    public Post GetMostLikedPost()
    {
        var responsePost = new Post();
        var mostLikes = 0;

        foreach (var post in posts)
        {
            if (mostLikes < post.QuantityLikes)
            {
                mostLikes = post.QuantityLikes;
                responsePost = post;
            }
        }
        return responsePost;
    }

    public Post GetMostCommentedPost()
    {
        var responsePost = new Post();
        var mostComment = 0;

        foreach (var post in posts)
        {
            if (mostComment < post.Comments.Count)
            {
                mostComment = post.Comments.Count;
                responsePost = post;
            }
        }
        return responsePost;
    }

    public List<Post> GetPostsByComment(string comment)
    {
        var responsePost = new List <Post>();
        foreach (var post in posts)
        {
            if (post.Comments.Contains(comment) is true)
            {
                responsePost.Add(post);
            }
        }
        return responsePost;
    }

    public bool AddCommentToPost(Guid postId, string comment)
    {
        var post = GetPostById(postId);
        if (post is null)
        {
            return false;
        }
        post.Comments.Add(comment);
        return true;
    }

    public bool AddViewerNameToPost(Guid postId, string viewerName)
    {
        var post = GetPostById(postId);
        if (post is null)
        {
            return false;
        }
        post.ViewerNames.Add(viewerName);
        return true;
    }

    public bool AddLikeToPost(Guid postId)
    {
        var post = GetPostById(postId);
        if (post is null)
        {
            return false;
        }
        post.QuantityLikes++;
        return true;
    }
}



