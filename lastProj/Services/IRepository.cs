using lastProj.Data;
using lastProj.Models;

namespace lastProj.Services
{
    public interface IRepository
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimalByName(string name);
        Animal GetAnimalById(int id);
        IEnumerable<Category> GetCategories();
        IEnumerable<Animal> GetAnimalsByCategory(int categoryId);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetCommentsByAnimal(Animal animal);
        List<Animal> GetTopTwo();
        void InsertAnimal(Animal animal);
        void DeleteAnimal(int id);
        void InsertComment(Comment comment);
        void DeleteComment(int id);

        void UpdateAnimal(int id, Animal animal);

    }
}
