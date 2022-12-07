namespace MVC_WebApplication.Models
{
    public interface IAssessment2DatabaseSetting
    {
        string PlayersCollectionName { get; set; }
        string CharactersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string AdminUserCollection { get; set; }

    }
}
