using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BibliotekMinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishingYear = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "IsAvailable", "PublishingYear", "Title" },
                values: new object[,]
                {
                    { new Guid("12ddea37-649a-4317-9d8a-fa96da4ded25"), "Liu Cixin", "This novel begins with China's Cultural Revolution and spans into the future, exploring humanity's first contact with an alien civilization and the ensuing consequences.", "Science Fiction", true, 2008, "The Three-Body Problem" },
                    { new Guid("2467b668-7f1a-4f73-8a64-eb3c83fad91d"), "J.R.R Tolkien", "Continuing the story begun in The Hobbit, all three parts of the epic masterpiece, The Lord of the Rings, in one paperback. Features the definitive edition of the text, fold-out flaps with the original two-colour maps, and a revised and expanded index. Sauron, the Dark Lord, has gathered to him all the Rings of Power the means by which he intends to rule Middle-earth. All he lacks in his plans for dominion is the One Ring the ring that rules them all which has fallen into the hands of the hobbit, Bilbo Baggins. In a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as the Ring is entrusted to his care. He must leave his home and make a perilous journey across the realms of Middle-earth to the Crack of Doom, deep inside the territories of the Dark Lord. There he must destroy the Ring forever and foil the Dark Lord in his evil purpose. Since it was first published in 1954, The Lord of the Rings has been a book people have treasured. Steeped in unrivalled magic and otherworldliness, its sweeping fantasy has touched the hearts of young and old alike. This single-volume paperback edition is the definitive text, fully restored with almost 400 corrections with the full co-operation of Christopher Tolkien and features a striking new cover.", "Fantasy", true, 1954, "The Lord of The Rings" },
                    { new Guid("511bab00-11d8-4aa7-bcc8-f6a3d2607e42"), "George R.R. Martin", "An epic fantasy series that inspired the hit TV show 'Game of Thrones.' The series is known for its complex characters, intricate political plots, and a richly detailed world. It begins with 'A Game of Thrones,' where noble families vie for control of the Iron Throne in the Seven Kingdoms of Westeros.", "Fantasy", true, 1996, "A Song of Ice and Fire" },
                    { new Guid("62dd3f93-8ef4-4595-99ff-bfb41fb7b8e1"), "Stieg Larsson", "A journalist and a hacker team up to solve the mystery of a missing woman, uncovering dark secrets and corruption along the way. This novel is the first in the 'Millennium' series.", "Thriller", true, 2005, "The Girl with the Dragon Tattoo" },
                    { new Guid("881eb9c7-288c-4284-a3cb-0807e794867e"), "Orson Scott Card", "A young boy named Ender Wiggin is recruited into a military academy to prepare for an impending alien invasion. The novel explores themes of war, strategy, and the ethics of training children for combat.", "Science Fiction", true, 1985, "Ender's Game" },
                    { new Guid("88f5f7aa-9afa-4470-b05c-bb55e51f9579"), "William Gibson", "A seminal work in the cyberpunk genre, 'Neuromancer' follows a washed-up computer hacker named Case as he is hired for one last job that takes him deep into cyberspace.", "Science Fiction", true, 1984, "Neuromancer" },
                    { new Guid("9d8a26f7-e816-4040-b559-450b84279757"), "Tom Clancy", "A thrilling Cold War-era novel about a Soviet submarine captain who wishes to defect to the United States, and the ensuing cat-and-mouse game between the US and Soviet navies.", "Thriller", true, 1984, "The Hunt for Red October" },
                    { new Guid("aee88208-540a-411e-841a-2d66a07e394f"), "C.S. Lewis", "A classic series of seven fantasy novels that takes readers on a magical journey through the land of Narnia. The series begins with 'The Lion, the Witch and the Wardrobe,' where four children discover a magical wardrobe that leads to a world of talking animals, mythical creatures, and epic battles between good and evil.", "Fantasy", true, 1950, "The Chronicles of Narnia" },
                    { new Guid("b0c2f05a-28dd-4411-9036-c095378f766f"), "Gillian Flynn", "A psychological thriller that delves into the complexities of marriage and the dark secrets that can lie beneath the surface. The story unfolds with twists and turns that keep readers on the edge of their seats.", "Thriller", true, 2012, "Gone Girl" },
                    { new Guid("b146ba6e-7dfe-4694-8ef8-3006ea20c182"), "Robert Ludlum", "An amnesiac man is found floating in the Mediterranean Sea. As he recovers, he discovers he has extraordinary combat skills and must piece together his identity while being pursued by assassins.", "Thriller", true, 1980, "The Bourne Identity" },
                    { new Guid("b1c4f473-691c-4799-a740-be4264e3f747"), "Frank Herbert", "Set in the distant future amidst a huge interstellar empire, 'Dune' tells the story of young Paul Atreides as he navigates a complex political and ecological landscape on the desert planet Arrakis.", "Science Fiction", true, 1965, "Dune" },
                    { new Guid("e7f7d493-0c96-4433-8d23-d3da7bc14daa"), "J.K Rowling", "Join Harry Potter on the magical journey of a lifetime in the second book in J.K. Rowlings multi-award-winning series. Harry Potters summer has included the worst birthday ever, doomy warnings from a house-elf called Dobby and rescue from the Dursleys by his friend Ron Weasley in a magical flying car! Back at Hogwarts School of Witchcraft and Wizardry for his second year, Harry hears strange whispers echo through empty corridors and then the attacks start. Students are found as though turned to stone Dobbys sinister predictions seem to be coming true. J.K. Rowlings internationally bestselling Harry Potter books continue to captivate new generations of readers. Harrys second adventure alongside his friends, Ron and Hermione, invites you to explore even more of the wizarding world; from the waving, walloping branches of the Whomping Willow to the thrills of a rain-streaked Quidditch pitch.", "Fantasy", false, 1998, "Harry Potter and the Chamber of Secrets" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
