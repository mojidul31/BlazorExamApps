namespace BlazorExamApps.Shared.Models
{
    public interface IElementRepository
    {
        Elements GetElements(int id);
        bool CreateElements(Elements elements);
        bool UpdateElements(Elements elements);
        bool DeleteElements(int id);
        List<Elements> GetElementList();
    }
}
