using lastProj.Data;
using lastProj.Models;
using Microsoft.EntityFrameworkCore;

namespace lastProj.Services
{
    public class Repository : IRepository
    {
        private readonly MyContext _data;

        public Repository(MyContext data)
        {
            _data = data;
        }

        //Get
        public IEnumerable<Animal> GetAnimals() => _data.Animals!;
        public IEnumerable<Category> GetCategories() => _data.Categories!;
        public IEnumerable<Comment> GetComments() => _data.Comments!;
        public Animal GetAnimalByName(string name) => _data.Animals!.First(a => a.Name == name);
        public Animal GetAnimalById(int Id) => _data.Animals!.First(a => a.AnimalId == Id);
        public IEnumerable<Comment> GetCommentsByAnimal(Animal animal) => _data.Comments!.Where(a => a.AnimalId == animal.AnimalId);
        public List<Animal> GetTopTwo() => _data.Animals!.Include(c => c.Comments).OrderByDescending(c => c.Comments!.Count).Take(2).ToList();
        public IEnumerable<Animal> GetAnimalsByCategory(int categoryId) => _data.Animals!.Where(c => c.CategoryId == categoryId).ToList();
        public IEnumerable<Animal> GetTopTwoByCategory(int categoryId) => _data.Animals!.Where(c => c.CategoryId == categoryId).Include(c => c.Comments).OrderByDescending(c => c.Comments!.Count).Take(2).ToList();


        //Inserting
        public void InsertAnimal(Animal animal)
        {
            _data.Animals!.Add(animal);
            _data.SaveChanges();
        }
        public void InsertComment(Comment comment)
        {
            _data.Comments!.Add(comment);
            _data.SaveChanges();
        }

        //Deleting
        public void DeleteAnimal(int id)
        {
            var animal = _data.Animals!.Single(a => a.AnimalId == id);
            _data.Animals!.Remove(animal);
            _data.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            var comment = _data.Comments!.Single(a => a.CommentId == id);
            _data.Comments!.Remove(comment);
            _data.SaveChanges();
        }

        //Update
        public void UpdateAnimal(int id, Animal animal)
        {
            var AnimalInDB = _data.Animals!.Single(a => a.AnimalId == id);
            AnimalInDB.Name = animal.Name;
            AnimalInDB.Type = animal.Type;
            AnimalInDB.Age = animal.Age;
            AnimalInDB.PictureSrc = animal.PictureSrc;
            AnimalInDB.Description = animal.Description;
            AnimalInDB.Category = animal.Category;
            _data.SaveChanges();
        }
    }
}
