using BibliotekMinimalAPI.Models;
using BibliotekMinimalAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BibliotekMinimalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "The Lord of The Rings",
                    Author = "J.R.R Tolkien",
                    Description = "Continuing the story begun in The Hobbit, all three parts of the epic masterpiece, The Lord of the Rings, in one paperback. Features the definitive edition of the text, fold-out flaps with the original two-colour maps, and a revised and expanded index. Sauron, the Dark Lord, has gathered to him all the Rings of Power the means by which he intends to rule Middle-earth. All he lacks in his plans for dominion is the One Ring the ring that rules them all which has fallen into the hands of the hobbit, Bilbo Baggins. In a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as the Ring is entrusted to his care. He must leave his home and make a perilous journey across the realms of Middle-earth to the Crack of Doom, deep inside the territories of the Dark Lord. There he must destroy the Ring forever and foil the Dark Lord in his evil purpose. Since it was first published in 1954, The Lord of the Rings has been a book people have treasured. Steeped in unrivalled magic and otherworldliness, its sweeping fantasy has touched the hearts of young and old alike. This single-volume paperback edition is the definitive text, fully restored with almost 400 corrections with the full co-operation of Christopher Tolkien and features a striking new cover.",
                    Genre = "Fantasy",
                    PublishingYear = 1954,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Harry Potter and the Chamber of Secrets",
                    Author = "J.K Rowling",
                    Description = "Join Harry Potter on the magical journey of a lifetime in the second book in J.K. Rowlings multi-award-winning series. Harry Potters summer has included the worst birthday ever, doomy warnings from a house-elf called Dobby and rescue from the Dursleys by his friend Ron Weasley in a magical flying car! Back at Hogwarts School of Witchcraft and Wizardry for his second year, Harry hears strange whispers echo through empty corridors and then the attacks start. Students are found as though turned to stone Dobbys sinister predictions seem to be coming true. J.K. Rowlings internationally bestselling Harry Potter books continue to captivate new generations of readers. Harrys second adventure alongside his friends, Ron and Hermione, invites you to explore even more of the wizarding world; from the waving, walloping branches of the Whomping Willow to the thrills of a rain-streaked Quidditch pitch.",
                    Genre = "Fantasy",
                    PublishingYear = 1998,
                    IsAvailable = false
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "The Chronicles of Narnia",
                    Author = "C.S. Lewis",
                    Description = "A classic series of seven fantasy novels that takes readers on a magical journey through the land of Narnia. The series begins with 'The Lion, the Witch and the Wardrobe,' where four children discover a magical wardrobe that leads to a world of talking animals, mythical creatures, and epic battles between good and evil.",
                    Genre = "Fantasy",
                    PublishingYear = 1950,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "A Song of Ice and Fire",
                    Author = "George R.R. Martin",
                    Description = "An epic fantasy series that inspired the hit TV show 'Game of Thrones.' The series is known for its complex characters, intricate political plots, and a richly detailed world. It begins with 'A Game of Thrones,' where noble families vie for control of the Iron Throne in the Seven Kingdoms of Westeros.",
                    Genre = "Fantasy",
                    PublishingYear = 1996,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Dune",
                    Author = "Frank Herbert",
                    Description = "Set in the distant future amidst a huge interstellar empire, 'Dune' tells the story of young Paul Atreides as he navigates a complex political and ecological landscape on the desert planet Arrakis.",
                    Genre = "Science Fiction",
                    PublishingYear = 1965,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Ender's Game",
                    Author = "Orson Scott Card",
                    Description = "A young boy named Ender Wiggin is recruited into a military academy to prepare for an impending alien invasion. The novel explores themes of war, strategy, and the ethics of training children for combat.",
                    Genre = "Science Fiction",
                    PublishingYear = 1985,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "The Three-Body Problem",
                    Author = "Liu Cixin",
                    Description = "This novel begins with China's Cultural Revolution and spans into the future, exploring humanity's first contact with an alien civilization and the ensuing consequences.",
                    Genre = "Science Fiction",
                    PublishingYear = 2008,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Neuromancer",
                    Author = "William Gibson",
                    Description = "A seminal work in the cyberpunk genre, 'Neuromancer' follows a washed-up computer hacker named Case as he is hired for one last job that takes him deep into cyberspace.",
                    Genre = "Science Fiction",
                    PublishingYear = 1984,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "The Bourne Identity",
                    Author = "Robert Ludlum",
                    Description = "An amnesiac man is found floating in the Mediterranean Sea. As he recovers, he discovers he has extraordinary combat skills and must piece together his identity while being pursued by assassins.",
                    Genre = "Thriller",
                    PublishingYear = 1980,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "The Hunt for Red October",
                    Author = "Tom Clancy",
                    Description = "A thrilling Cold War-era novel about a Soviet submarine captain who wishes to defect to the United States, and the ensuing cat-and-mouse game between the US and Soviet navies.",
                    Genre = "Thriller",
                    PublishingYear = 1984,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "The Girl with the Dragon Tattoo",
                    Author = "Stieg Larsson",
                    Description = "A journalist and a hacker team up to solve the mystery of a missing woman, uncovering dark secrets and corruption along the way. This novel is the first in the 'Millennium' series.",
                    Genre = "Thriller",
                    PublishingYear = 2005,
                    IsAvailable = true
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Gone Girl",
                    Author = "Gillian Flynn",
                    Description = "A psychological thriller that delves into the complexities of marriage and the dark secrets that can lie beneath the surface. The story unfolds with twists and turns that keep readers on the edge of their seats.",
                    Genre = "Thriller",
                    PublishingYear = 2012,
                    IsAvailable = true
                }
            );
        }
    }
}
