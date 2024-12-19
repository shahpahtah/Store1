﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data.EF;

#nullable disable

namespace Store.Data.EF.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20241217182232_e")]
    partial class e
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Store.data.OrderDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CellPhone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DeliveryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryParameters")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnType("money");

                    b.Property<string>("DeliveryUniqueCode")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PaymentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentParameters")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentServiceName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Store.data.OrderItemDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Store.data.ProductDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("characteristic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgsrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            category = "Толстовка",
                            characteristic = "sss",
                            description = " Мужская толстовка-полузамок прямого кроя из мягкой, приятной к телу хлопковой ткани с тонким начсом     \n    - Круглый вырез горловины с высоким воротником-стойкой и застежкой на молнию.Свободные длинные рукава с манжетами в рубчик и спущенной линией плеча. \r\n                        - Толстовка в базовых и ярких расцветках с зимним принтом в стиле old money. Теплая, уютная мужская худи с воротником на молнии для комфортных занятий спортом, прогулок на свежем воздухе и просто на каждый день. Универсальный Джемпер с надписями и зимним принтом идеально подойдет для стильных аутфитов на учебу или в офис. Толстовка half zip с принтом станет отличным подарком для родных и друзей на Новый год или Рождество   \n                    - Размер на модели: L \n  - Параметры модели: рост 185, грудь 87, талия 70, бедра 91 <br> -цена: 3500 rub \n",
                            gender = "Мужское",
                            imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2443123028/BF2443123028_55_2.webp",
                            name = "Мужская толстовка-полузамок прямого кроя",
                            price = 3500m
                        },
                        new
                        {
                            Id = 2,
                            category = "Футболка",
                            characteristic = "sss",
                            description = "- Удлиненная мужская футболка прямого кроя из 100% хлопковой ткани средней плотности с гладкой трикотажной фактурой \r\n- Круглый вырез горловины без воротника. Свободные короткие рукава чуть выше локтя с прямыми манжетами и немного спущенной линией плеча. Прямой нижний край без разрезов и декоративных элементов\r\n- Футболка с новогодним принтом для самых праздничных аутфитов. Стильная и удобная дышащая футболка из хлопка, в которой ты будешь комфортно чувствовать себя во время распаковки подарков или домашнего отдыха за просмотром новогодних фильмов. Футболка из хлопка с принтом подойдет для привлекательных аутфитов на каждый день и по особым поводам. Создавай с ней аутфиты в разных стилях: официальные, но акцентные на учебу или в офис, спортивные на тренировки, базовые повседневные на каждый день. Идеально в качестве подарка для друзей и родных на Новый год и Рождество\r\n- Размер на модели: L \r\n- Параметры модели: рост 185, грудь 87, талия 70, бедра 91<br> -цена: 3500 rub\n",
                            gender = "Мужское",
                            imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2443120012/BF2443120012_49_2.webp",
                            name = "Удлиненная мужская футболка прямого кроя ",
                            price = 3500m
                        },
                        new
                        {
                            Id = 3,
                            category = "Джемпер",
                            characteristic = "sss",
                            description = "- Вязаный мужской джемпер свободного кроя из теплой, мягкой, приятной к телу пряжи\r\n             - Высокий круглый вырез горловины в рубчик без воротника. Длинные свободные рукава с широкими манжетами в рубчик и спущенной линией плеча. Прямой нижний край в рубчик без разрезов и декоративных элементов <br>\r\n             - Мягкий вязаный свитер в полоску для максимально удобных и привлекательных аутфитов в школу, университет, офис или просто на каждый день. Сочетай этот удлиненный вязаный пуловер с любимым низом и создавай самые комфортные и расслабленные повседневные образы под любое настроение. Носи его отдельно или в трендовых многослойных образах. Используй его как второй слой в борьбе с холодами и морозами. Свитер в полоску станет идеальным подарком на Новый год и Рождество. Заверши образ удобной обувью и стильными аксессуарами Befree <br>\r\n             - Размер на модели: L \r\n             - Параметры модели: рост 187, грудь 96, талия 76, бедра 96 \n-цена: 3500 rub",
                            gender = "Мужское",
                            imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2443128007/BF2443128007_99_1.webp",
                            name = "Вязаный мужской джемпер свободного кроя",
                            price = 3500m
                        },
                        new
                        {
                            Id = 4,
                            category = "Платье",
                            characteristic = "sss",
                            description = " - Длинное женское платье миди облегающего кроя из сверкающих пайеток с приятной к телу подкладкой \r\n- Глубокий круглый вырез на груди, открытая спина с вырезом-борцовкой. Тонкие бретели без регулировки по длине. Прямая юбка со средней линией талии \r\n- Стильное облегающее миди-платье подчеркнет твою фигуру и точно не оставит без внимания. Идеальное платье-чулок для походов в клуб, на вечеринки и на концерты. Сочетай платье с открытыми босоножками и шубой, чтобы воссоздать легкий образ Кэрри Бредшоу. Платье с пайетками идеально подойдет для встречи Нового года, Рождества, проведения корпоративов и походов на свидания. После выхода в сверкающем платье с пайетками о тебе еще долго будут вспоминать с восхищением. Заверши образ стильными аксессуарами из новогодней коллекции Befree и отправляйся покорять сердца \r\n- Размер на модели: S \r\n- Параметры модели: рост 177, бюст 81, талия 60, бедра 90<br> -цена: 3600 rub",
                            gender = "Женское",
                            imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2441414019/BF2441414019_7_4.webp",
                            name = " Длинное женское платье миди облегающего кроя ",
                            price = 3600m
                        },
                        new
                        {
                            Id = 5,
                            category = "Юбка",
                            characteristic = "sss",
                            description = "- Короткая женская юбка-карандаш мини облегающего кроя из плотной, теплой твидовой ткани с пайетками \r\n- Классическая средняя посадка подчеркивает фигуру и акцентирует внимание на талии. Потайная застежка на молнию сбоку. Прямой нижний край без разрезов, декор из пайеток по всей длине \r\n- Удобная и очень практичная твидовая мини-юбка с пайетками облегающего кроя подчеркнет твою фигуру и идеально подойдет к любому стилю, образу и настроению. Сочетай юбку с бомбером из комплекта, чтобы получить сверкающий праздничный образ. Сочетай ее также с классическим верхом для более строгих образов с изюминкой или с оверсайз-верхом для расслабленных повседневных луков. Внеси стильное разнообразие в свои повседневные аутфиты для учебы или офиса и экспериментируй с образами каждый день \r\n- Размер на модели: S \r\n- Параметры модели: рост 177, бюст 81, талия 60, бедра 90 \n-цена: 2600 rub",
                            gender = "Женское",
                            imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2441312017/BF2441312017_50_1.webp",
                            name = "Короткая женская юбка-карандаш мини облегающего кроя",
                            price = 2600m
                        },
                        new
                        {
                            Id = 6,
                            category = "Жакет",
                            characteristic = "sss",
                            description = "- Укороченный женский жакет-бомбер свободного кроя oversize из плотной твидовой ткани со сверкающими пайетками\r\n             - Круглый вырез горловины без воротника. Длинные объемные рукава со спущенной линией плеча и прямыми манжетами. Застежка на кнопки по всей длине. Присборенный нижний край на резинке. Блестящие пайетки по всей длине. \r\n             - Черный жакет с пайетками станет основой твоих зимних образов. Жакет-бомбер станет дополнением сдержанных образов на учебу или в офис. Жакет можно накинуть вечером поверх комбинации и отправиться на свидание или в театр. Он отлично будет смотреться и в кэжуал-образах с объемным низом на низкой посадке. Сочетай его с твидовой юбкой из коллекции, чтобы получить цельный образ на Новый год или Рождество. Заверши образ удобной обувью и стильными аксессуарами из новой коллекции Befree \r\n             - Размер на модели: S \r\n             - Параметры модели: рост 177, бюст 81, талия 60, бедра 90 \n -цена: 5000 rub\n",
                            gender = "Женское",
                            imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2441305008/BF2441305008_50_5.webp",
                            name = "Укороченный женский жакет-бомбер свободного кроя",
                            price = 5000m
                        });
                });

            modelBuilder.Entity("Store.data.OrderItemDto", b =>
                {
                    b.HasOne("Store.data.OrderDto", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Store.data.OrderDto", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
