using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellPhone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DeliveryUniqueCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DeliveryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryPrice = table.Column<decimal>(type: "money", nullable: false),
                    DeliveryParameters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentServiceName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentParameters = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imgsrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characteristic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "category", "characteristic", "description", "gender", "imgsrc", "name", "price" },
                values: new object[,]
                {
                    { 1, "Толстовка", "sss", " Мужская толстовка-полузамок прямого кроя из мягкой, приятной к телу хлопковой ткани с тонким начсом      s                 - Круглый вырез горловины с высоким воротником-стойкой и застежкой на молнию.Свободные длинные рукава с манжетами в рубчик и спущенной линией плеча. \r\n                        - Толстовка в базовых и ярких расцветках с зимним принтом в стиле old money. Теплая, уютная мужская худи с воротником на молнии для комфортных занятий спортом, прогулок на свежем воздухе и просто на каждый день. Универсальный Джемпер с надписями и зимним принтом идеально подойдет для стильных аутфитов на учебу или в офис. Толстовка half zip с принтом станет отличным подарком для родных и друзей на Новый год или Рождество   s                      - Размер на модели: L s                       - Параметры модели: рост 185, грудь 87, талия 70, бедра 91 <br> -цена: 3500 rub s", "Мужское", "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2443123028/BF2443123028_55_2.webp", "Мужская толстовка-полузамок прямого кроя", 3500m },
                    { 2, "Футболка", "sss", "- Удлиненная мужская футболка прямого кроя из 100% хлопковой ткани средней плотности с гладкой трикотажной фактурой \r\n- Круглый вырез горловины без воротника. Свободные короткие рукава чуть выше локтя с прямыми манжетами и немного спущенной линией плеча. Прямой нижний край без разрезов и декоративных элементов\r\n- Футболка с новогодним принтом для самых праздничных аутфитов. Стильная и удобная дышащая футболка из хлопка, в которой ты будешь комфортно чувствовать себя во время распаковки подарков или домашнего отдыха за просмотром новогодних фильмов. Футболка из хлопка с принтом подойдет для привлекательных аутфитов на каждый день и по особым поводам. Создавай с ней аутфиты в разных стилях: официальные, но акцентные на учебу или в офис, спортивные на тренировки, базовые повседневные на каждый день. Идеально в качестве подарка для друзей и родных на Новый год и Рождество\r\n- Размер на модели: L \r\n- Параметры модели: рост 185, грудь 87, талия 70, бедра 91<br> -цена: 3500 rub\n", "Мужское", "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2443120012/BF2443120012_49_2.webp", "Удлиненная мужская футболка прямого кроя ", 3500m },
                    { 3, "Джемпер", "sss", "- Вязаный мужской джемпер свободного кроя из теплой, мягкой, приятной к телу пряжи\r\n             - Высокий круглый вырез горловины в рубчик без воротника. Длинные свободные рукава с широкими манжетами в рубчик и спущенной линией плеча. Прямой нижний край в рубчик без разрезов и декоративных элементов <br>\r\n             - Мягкий вязаный свитер в полоску для максимально удобных и привлекательных аутфитов в школу, университет, офис или просто на каждый день. Сочетай этот удлиненный вязаный пуловер с любимым низом и создавай самые комфортные и расслабленные повседневные образы под любое настроение. Носи его отдельно или в трендовых многослойных образах. Используй его как второй слой в борьбе с холодами и морозами. Свитер в полоску станет идеальным подарком на Новый год и Рождество. Заверши образ удобной обувью и стильными аксессуарами Befree <br>\r\n             - Размер на модели: L \r\n             - Параметры модели: рост 187, грудь 96, талия 76, бедра 96 \n-цена: 3500 rub", "Мужское", "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2443128007/BF2443128007_99_1.webp", "Вязаный мужской джемпер свободного кроя", 3500m },
                    { 4, "Платье", "sss", " - Длинное женское платье миди облегающего кроя из сверкающих пайеток с приятной к телу подкладкой \r\n- Глубокий круглый вырез на груди, открытая спина с вырезом-борцовкой. Тонкие бретели без регулировки по длине. Прямая юбка со средней линией талии \r\n- Стильное облегающее миди-платье подчеркнет твою фигуру и точно не оставит без внимания. Идеальное платье-чулок для походов в клуб, на вечеринки и на концерты. Сочетай платье с открытыми босоножками и шубой, чтобы воссоздать легкий образ Кэрри Бредшоу. Платье с пайетками идеально подойдет для встречи Нового года, Рождества, проведения корпоративов и походов на свидания. После выхода в сверкающем платье с пайетками о тебе еще долго будут вспоминать с восхищением. Заверши образ стильными аксессуарами из новогодней коллекции Befree и отправляйся покорять сердца \r\n- Размер на модели: S \r\n- Параметры модели: рост 177, бюст 81, талия 60, бедра 90<br> -цена: 3600 rub", "Женское", "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2441414019/BF2441414019_7_4.webp", " Длинное женское платье миди облегающего кроя ", 3600m },
                    { 5, "Юбка", "sss", "- Короткая женская юбка-карандаш мини облегающего кроя из плотной, теплой твидовой ткани с пайетками \r\n- Классическая средняя посадка подчеркивает фигуру и акцентирует внимание на талии. Потайная застежка на молнию сбоку. Прямой нижний край без разрезов, декор из пайеток по всей длине \r\n- Удобная и очень практичная твидовая мини-юбка с пайетками облегающего кроя подчеркнет твою фигуру и идеально подойдет к любому стилю, образу и настроению. Сочетай юбку с бомбером из комплекта, чтобы получить сверкающий праздничный образ. Сочетай ее также с классическим верхом для более строгих образов с изюминкой или с оверсайз-верхом для расслабленных повседневных луков. Внеси стильное разнообразие в свои повседневные аутфиты для учебы или офиса и экспериментируй с образами каждый день \r\n- Размер на модели: S \r\n- Параметры модели: рост 177, бюст 81, талия 60, бедра 90 \n-цена: 2600 rub", "Женское", "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2441312017/BF2441312017_50_1.webp", "Короткая женская юбка-карандаш мини облегающего кроя", 2600m },
                    { 6, "Жакет", "sss", "- Укороченный женский жакет-бомбер свободного кроя oversize из плотной твидовой ткани со сверкающими пайетками\r\n             - Круглый вырез горловины без воротника. Длинные объемные рукава со спущенной линией плеча и прямыми манжетами. Застежка на кнопки по всей длине. Присборенный нижний край на резинке. Блестящие пайетки по всей длине. \r\n             - Черный жакет с пайетками станет основой твоих зимних образов. Жакет-бомбер станет дополнением сдержанных образов на учебу или в офис. Жакет можно накинуть вечером поверх комбинации и отправиться на свидание или в театр. Он отлично будет смотреться и в кэжуал-образах с объемным низом на низкой посадке. Сочетай его с твидовой юбкой из коллекции, чтобы получить цельный образ на Новый год или Рождество. Заверши образ удобной обувью и стильными аксессуарами из новой коллекции Befree \r\n             - Размер на модели: S \r\n             - Параметры модели: рост 177, бюст 81, талия 60, бедра 90 \n -цена: 5000 rub\n", "Женское", "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2441305008/BF2441305008_50_5.webp", "Укороченный женский жакет-бомбер свободного кроя", 5000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
