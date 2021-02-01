namespace todo.API.Models
{
    public class Todo
    {
        //Should be a guid but for testing purposes leaving it as an int
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}