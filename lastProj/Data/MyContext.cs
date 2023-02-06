using lastProj.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace lastProj.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Comment>? Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, CategoryName = "Mammals" },
                new { CategoryId = 2, CategoryName = "Retiles" },
                new { CategoryId = 3, CategoryName = "Fish" },
                new { CategoryId = 4, CategoryName = "Birds" }
                );
            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, CategoryId = 1, Name = "Oren", Type = "Dog", Age = 4, Description = "A dog is a domestic mammal of the family Canidae and the order Carnivora. Its scientific name is Canis lupus familiaris. Dogs are a subspecies of the gray wolf, and they are also related to foxes and jackals. Dogs are one of the two most ubiquitous and most popular domestic animals in the world. (Cats are the other.)", PictureSrc = "https://cdn.britannica.com/60/8160-050-08CCEABC/German-shepherd.jpg" }, 
                new { AnimalId = 2, CategoryId = 1, Name = "Faruk", Type = "Cat", Age = 2, Description = "A cat is a furry animal that has a long tail and sharp claws. Cats are often kept as pets. 2. countable noun. Cats are lions, tigers, and other wild animals in the same family.", PictureSrc = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/1200px-Cat03.jpg" },
                new { AnimalId = 3, CategoryId = 3, Name = "Joerge", Type = "fish", Age = 1, Description = "i have nothing to say", PictureSrc = "https://media.npr.org/assets/img/2016/06/17/whatafishknows_wide-e2b0800c202b1751ffddfae6394e3c7825e7d333-s1400-c100.jpg" }, 
                new { AnimalId = 4, CategoryId = 2, Name = "Pepe", Type = "Frog", Age = 9, Description = "pepe the frog is a nice and calm creature, you can find it mustly in memes :)", PictureSrc = "https://i.guim.co.uk/img/media/327e46c3ab049358fad80575146be9e0e65686e7/0_56_1023_614/master/1023.jpg?width=1200&height=900&quality=85&auto=format&fit=crop&s=1a1f3b8896b95c4590b3b7ae2d3b5d61" },
                new { AnimalId = 5, CategoryId = 1, Name = "Orian", Type = "Chita", Age = 4, Description = "a vary fast and beutiful animal, like a cat but better", PictureSrc = "https://media-cdn.tripadvisor.com/media/photo-m/1280/1a/40/71/87/chita-en-serengeti.jpg" }, 
                new { AnimalId = 6, CategoryId = 1, Name = "Zoe", Type = "black panther", Age = 2, Description = "blace panther is a magestic animal,and its a really bad movie", PictureSrc = "https://media.newyorker.com/photos/5a875e3f33aebd0cab9bab12/2:2/w_1079,h_1079,c_limit/Brody-Passionate-Politics-Black-Panther.jpg" },
                new { AnimalId = 7, CategoryId = 4, Name = "Fishy", Type = "Chiken", Age = 2, Description = "chicken is a vary heakthy food, you can also find it in nature all around the world", PictureSrc = "https://assets.bonappetit.com/photos/62f5674caf9bae430097be0f/5:4/w_2325,h_1860,c_limit/0810-no-fail-roast-chicken-v2.jpg" },
                new { AnimalId = 8, CategoryId = 1, Name = "Gabi", Type = "Chinchila", Age = 1, Description = "i love Chinchilas they are the best animals i love them more them my one chileds, they dont poop, eat, or cry. its basicly  like a plant", PictureSrc = "https://assets.petco.com/petco/image/upload/f_auto,q_auto/2788401-Center-1" },
                new { AnimalId = 9, CategoryId = 2, Name = "Yossi", Type = "Chameleon", Age = 3, Description = "In the reptile world, there are some bizarre shapes and colors, but some of the most striking variations are found in the chameleons. These colorful lizards are known for their ability to change their color; their long, sticky tongue; and their eyes, which can be moved independently of each other.", PictureSrc = "https://chameleonacademy.com/wp-content/uploads/2019/08/Jacksons-Chamleeon-2-to-1-scaled.jpg" },
                new { AnimalId = 10, CategoryId = 3, Name = "Jim", Type = "Tuna", Age = 1, Description = "A tuna is a saltwater fish that belongs to the tribe Thunnini, a subgrouping of the Scombridae (mackerel) family. The Thunnini comprise 15 species across five genera,[2] the sizes of which vary greatly, ranging from the bullet tuna (max length: 50 cm or 1.6 ft, weight: 1.8 kg or 4 lb) up to the Atlantic bluefin tuna (max length: 4.6 m or 15 ft, weight: 684 kg or 1,508 lb), which averages 2 m (6.6 ft) and is believed to live up to 50 years.", PictureSrc= "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Bluefin-big.jpg/1200px-Bluefin-big.jpg" },
                new { AnimalId = 11, CategoryId = 1, Name = "Hcay", Type = "Bear", Age = 1, Description = "if a bear run towards you don't run!! just give up!!!", PictureSrc = "https://i.natgeofe.com/n/04fcf985-fc13-4dd3-ac21-03ad540915c1/0000016c-25c4-d982-a7ff-fdf7352c0000_3x2.jpg" },
                new { AnimalId = 12, CategoryId = 1, Name = "Gur", Type = "whale", Age = 1, Description = "WAHLES ARE THE BIGGEST ANIMAL ON EARTH", PictureSrc = "https://www.aims.gov.au/sites/default/files/styles/featured/public/2022-07/whales_2000px_banner-2.jpg?itok=sOy0UZhB" },
                new { AnimalId = 13, CategoryId = 2, Name = "Micha", Type = "Master Splinter", Age = 1, Description = "Splinter, often referred to as Master Splinter or Sensei by his students/sons, is a fictional character from the Teenage Mutant Ninja Turtles comics and all related media", PictureSrc = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/5d976800-c0df-486f-b3c9-047f29e49f30/dbpzpo7-34cc4446-7fb3-4850-8a4e-cc8f45814036.png/v1/fill/w_1024,h_1341,q_80,strp/teenage_mutant_ninja_turtles__master_splinter__by_ryanshifflett_dbpzpo7-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9MTM0MSIsInBhdGgiOiJcL2ZcLzVkOTc2ODAwLWMwZGYtNDg2Zi1iM2M5LTA0N2YyOWU0OWYzMFwvZGJwenBvNy0zNGNjNDQ0Ni03ZmIzLTQ4NTAtOGE0ZS1jYzhmNDU4MTQwMzYucG5nIiwid2lkdGgiOiI8PTEwMjQifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uub3BlcmF0aW9ucyJdfQ.OwkUOGIFSuIslf_PDD3KrZrTaW88G4FLaulbkDCeHEg" },
                new { AnimalId = 14, CategoryId = 2, Name = "Odem", Type = " Dragon", Age = 1, Description = "the only know existing flying & fire spitting reptail know so far ", PictureSrc = "https://img.freepik.com/free-vector/hand-drawn-dragon_53876-88179.jpg?w=2000" },
                new { AnimalId = 15, CategoryId = 1, Name = "Odel", Type = "Dolphin", Age = 1, Description = "the nicest animal known on earth", PictureSrc = "https://thumbs.dreamstime.com/b/dolfin-boris-5541157.jpg" },
                new { AnimalId = 16, CategoryId = 4, Name = "Arik", Type = "Spur-winged lapwing", Age = 1, Description = "These are conspicuous and unmistakable birds. They are medium-large waders with black crown, chest, foreneck stripe and tail. The face, the rest of the neck and belly are white and the wings and back are light brown. The bill and legs are black. Its striking appearance is supplemented by its noisy nature, with a loud did-he-do-it call. The bird's common name refers to a small claw or spur hidden in each of its wings.", PictureSrc = "https://upload.wikimedia.org/wikipedia/commons/3/3b/Spur-winged_Lapwing_%28Vanellus_spinosus%29_%2821152292885%29.jpg" }
                );
            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 13, Comments = "creepy" },
                new { CommentId = 2, AnimalId = 13, Comments = "wierd!" },
                new { CommentId = 3, AnimalId = 13, Comments = "nice and deli!" },
                new { CommentId = 4, AnimalId = 13, Comments = "Amazing!" },
                new { CommentId = 5, AnimalId = 8, Comments = "So cute!" },
                new { CommentId = 6, AnimalId = 8, Comments = "Amazing!" },
                new { CommentId = 7, AnimalId = 8, Comments = "ok ish" },
                new { CommentId = 8, AnimalId = 8, Comments = "wow i never saw this kind of animal its so under rated!" },
                new { CommentId = 9, AnimalId = 1, Comments = "So cute!" },
                new { CommentId = 10, AnimalId = 1, Comments = "Cool!" },
                new { CommentId = 12, AnimalId = 15, Comments = "So cute!" },
                new { CommentId = 13, AnimalId = 9, Comments = "So cute!" },
                new { CommentId = 14, AnimalId = 13, Comments = "So cute!" },
                new { CommentId = 15, AnimalId = 4, Comments = "So cute!" },
                new { CommentId = 16, AnimalId = 9, Comments = "Amazing!" },
                new { CommentId = 17, AnimalId = 11, Comments = "So cute!" },
                new { CommentId = 18, AnimalId = 2, Comments = "ok what to say next i really dont know!" },
                new { CommentId = 19, AnimalId = 2, Comments = "So cute!" }

                );
        }
    }
}
