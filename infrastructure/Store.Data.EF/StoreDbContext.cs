using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;

namespace Store.Data.EF
{
    public class StoreDbContext:DbContext
    {
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<OrderItemDto> OrderItems { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(9000);

        }
        private static readonly ValueComparer DictionaryComparer =
       new ValueComparer<Dictionary<string, string>>(
           (dictionary1, dictionary2) => dictionary1.SequenceEqual(dictionary2),
           dictionary => dictionary.Aggregate(
               0,
               (a, p) => HashCode.Combine(HashCode.Combine(a, p.Key.GetHashCode()), p.Value.GetHashCode())
           )
       );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildProducts(modelBuilder);
            BuildOrders(modelBuilder);
            BuildOrderItems(modelBuilder);
            BuildUsers(modelBuilder);
        }
        private void BuildOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemDto>(action =>
            {
                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasOne(dto => dto.Order)
                      .WithMany(dto => dto.Items)
                      .IsRequired();
            });
        }
        private static void BuildOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDto>(action =>
            {
                action.Property(dto => dto.CellPhone).HasMaxLength(30);
                action.Property(dto => dto.DeliveryUniqueCode).HasMaxLength(40);
                action.Property(dto => dto.PaymentServiceName).HasMaxLength(40);
                action.Property(dto => dto.DeliveryPrice).HasColumnType("money");
                action.Property(dto => dto.DeliveryParameters).HasConversion(value => JsonConvert.SerializeObject(value), value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value)).Metadata.SetValueComparer(DictionaryComparer);
                action.Property(dto => dto.PaymentParameters).HasConversion(value => JsonConvert.SerializeObject(value), value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value)).Metadata.SetValueComparer(DictionaryComparer);

            });
        }

        private static void BuildUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDto>(action =>
            {
                action.Property(dto => dto.CellPhone).HasMaxLength(30);
                action.Property(dto => dto.Name).HasMaxLength(30);
                action.Property(dto => dto.Email).HasMaxLength(30);
                action.Property(dto => dto.Password).HasMaxLength(30);
                action.Property(dto => dto.Errors).HasConversion(value => JsonConvert.SerializeObject(value), value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value)).Metadata.SetValueComparer(DictionaryComparer);

            });
        }
        private static void BuildProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDto>(action =>
            {
                action.Property(dto => dto.imgsrc).IsRequired();
                action.Property(dto => dto.name).IsRequired();
                action.Property(dto => dto.characteristic).IsRequired();
                action.Property(dto => dto.price).HasColumnType("money");
                action.Property(dto => dto.gender).IsRequired();
                action.Property(dto => dto.description).IsRequired();
                action.Property(dto => dto.category).IsRequired();
                action.HasData(new ProductDto
                {
                    Id = 1,
                    category = "Толстовка",
                    description = ( " Мужская толстовка-полузамок прямого кроя из мягкой, " +
                    "приятной к телу хлопковой ткани с тонким начсом     \n    - Круглый вырез горловины с высоким воротником-стойкой и застежкой на молнию.Свободные длинные рукава с манжетами в рубчик и спущенной линией плеча. \r\n      " +
                    "                  - Толстовка в базовых и ярких расцветках с зимним принтом в стиле old money. Теплая, уютная мужская худи с воротником на молнии для комфортных занятий спортом, прогулок на свежем воздухе и просто на каждый день. Универсальный Джемпер с надписями и зимним принтом идеально подойдет для стильных аутфитов на учебу или в офис. Толстовка half zip с прин" +
                    "том станет отличным подарком для родных и друзей на Новый год или Рождество   \n                    - Размер на модели: L \n" +
                    "  - Параметры модели: рост 185, грудь 87, талия 70, бедра 91 \n -цена: 3500 rub \n"),
                    characteristic = "состав : хлопок 80%\n полиэстер: 20%\r\nоттенок: чёрный принт графика\r\nпокрой: прямой\r\nдлина: средний\r\nлиния: Befree Young\n",
                    gender = "Мужское",
                    imgsrc =
                    "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2443123028/BF2443123028_55_2.webp",
                    name = "Мужская толстовка-полузамок прямого кроя",
                    price = 3500
                },
                    new ProductDto
                    {
                        Id = 2,
                        category = "Футболка",
                        name = "Удлиненная мужская футболка прямого кроя ",
                        description = ("- Удлиненная мужская футболка прямого кроя из 100% хлопковой ткани средней плотности с гладкой трикотажной фактурой \r\n- Круглый вырез горловины без воротника. Свободные короткие рукава чуть выше локтя с прямыми манжетами и немного спущенной линией плеча. Прямой нижний край без разрезов и декоративных элементов\r\n- Футболка с новогодним принтом для самых праздничных аутфитов. Стильная и удобная дышащая футболка из хлопка, в которой ты будешь комфортно чувствовать себя во время распаковки подарков или домашнего отдыха за просмотром новогодних фильмов. Футболка из хлопка с принтом подойдет для привлекательных аутфитов на каждый день и по особым поводам. Создавай с ней аутфиты в разных стилях: официальные, но акцентные на учебу или в офис, спортивные на тренировки, базовые повседневные на каждый день. Идеально в качестве подарка для друзей и родных на Новый год и Рождество\r\n- Размер на модели: L \r\n- Параметры модели: рост 185, грудь 87, талия 70, бедра 91\n -цена: 3500 rub\n"),
                        characteristic = "состав: хлопок 100%\r\nоттенок: небесно-голубой\r\nпокрой: прямой\r\nдлина: средний\r\nвырез: nкруглый\r\nлиния: Befree Young\n",
                        gender = "Мужское",
                        imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2443120012/BF2443120012_49_2.webp",
                        price = 3500
                    }, new ProductDto { Id = 3, category = "Джемпер", characteristic = "состав: акрил 80%, полиэстер 20% \r\nоттенок: nмультиколор\r\nпокрой: свободный\r\nвырез: круглый\r\nлиния: Befree Young \n", description = ("- Вязаный мужской джемпер свободного кроя из теплой, мягкой, приятной к телу пряжи\r\n             - Высокий круглый вырез горловины в рубчик без воротника. Длинные свободные рукава с широкими манжетами в рубчик и спущенной линией плеча. Прямой нижний край в рубчик без разрезов и декоративных элементов \r\n             - Мягкий вязаный свитер в полоску для максимально удобных и привлекательных аутфитов в школу, университет, офис или просто на каждый день. Сочетай этот удлиненный вязаный пуловер с любимым низом и создавай самые комфортные и расслабленные повседневные образы под любое настроение. Носи его отдельно или в трендовых многослойных образах. Используй его как второй слой в борьбе с холодами и морозами. Свитер в полоску станет идеальным подарком на Новый год и Рождество. Заверши образ удобной обувью и стильными аксессуарами Befree \r\n             - Размер на модели: L \r\n             - Параметры модели: рост 187, грудь 96, талия 76, бедра 96 \n-цена: 3500 rub"), gender = "Мужское", imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2443128007/BF2443128007_99_1.webp", name = "Вязаный мужской джемпер свободного кроя", price = 3500 }
                    , new ProductDto { Id = 4, imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2441414019/BF2441414019_7_4.webp", category = "Платье", characteristic = "состав: полиэстер 94%, эластан 6%\r\nоттенок: серебро\r\nтип платья: с тонкими бретельками\r\nдлина платья: миди\r\nвырез: на бретелях\r\nрукава: без рукавов\r\nталия: средняя", description = (" - Длинное женское платье миди облегающего кроя из сверкающих пайеток с приятной к телу подкладкой \r\n- Глубокий круглый вырез на груди, открытая спина с вырезом-борцовкой. Тонкие бретели без регулировки по длине. Прямая юбка со средней линией талии \r\n- Стильное облегающее миди-платье подчеркнет твою фигуру и точно не оставит без внимания. Идеальное платье-чулок для походов в клуб, на вечеринки и на концерты. Сочетай платье с открытыми босоножками и шубой, чтобы воссоздать легкий образ Кэрри Бредшоу. Платье с пайетками идеально подойдет для встречи Нового года, Рождества, проведения корпоративов и походов на свидания. После выхода в сверкающем платье с пайетками о тебе еще долго будут вспоминать с восхищением. Заверши образ стильными аксессуарами из новогодней коллекции Befree и отправляйся покорять сердца \r\n- Размер на модели: S \r\n- Параметры модели: рост 177, бюст 81, талия 60, бедра 90\n-цена: 3600 rub"), price = 3600, gender = "Женское", name = " Длинное женское платье миди облегающего кроя " },
                    new ProductDto { Id = 5, imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2441312017/BF2441312017_50_1.webp", price = 2600, category = "Юбка", name = "Короткая женская юбка-карандаш мини облегающего кроя", description =( "- Короткая женская юбка-карандаш мини облегающего кроя из плотной, теплой твидовой ткани с пайетками \r\n- Классическая средняя посадка подчеркивает фигуру и акцентирует внимание на талии. Потайная застежка на молнию сбоку. Прямой нижний край без разрезов, декор из пайеток по всей длине \r\n- Удобная и очень практичная твидовая мини-юбка с пайетками облегающего кроя подчеркнет твою фигуру и идеально подойдет к любому стилю, образу и настроению. Сочетай юбку с бомбером из комплекта, чтобы получить сверкающий праздничный образ. Сочетай ее также с классическим верхом для более строгих образов с изюминкой или с оверсайз-верхом для расслабленных повседневных луков. Внеси стильное разнообразие в свои повседневные аутфиты для учебы или офиса и экспериментируй с образами каждый день \r\n- Размер на модели: S \r\n- Параметры модели: рост 177, бюст 81, талия 60, бедра 90 \n-цена: 2600 rub"), characteristic = "состав: основной материал: полиэстер 100%\r\nоттенок: черный\r\nпосадка: средняя\r\nмодель юбки: oблегающая\r\nдлина юбки: мини\r\nвид застежки: молния", gender = "Женское" },
                    new ProductDto { Id = 6, imgsrc = "https://imgcdn.befree.ru/rest/V1/images/768/product/images/BF2441305008/BF2441305008_50_5.webp", price = 5000, gender = "Женское", category = "Жакет", characteristic = "состав:основной материал: полиэстер 100%; подкладка: полиэстер 100%\r\nоттенок:черный\r\nпокрой:оверсайз", description = ("- Укороченный женский жакет-бомбер свободного кроя oversize из плотной твидовой ткани со сверкающими пайетками\r\n             - Круглый вырез горловины без воротника. Длинные объемные рукава со спущенной линией плеча и прямыми манжетами. Застежка на кнопки по всей длине. Присборенный нижний край на резинке. Блестящие пайетки по всей длине. \r\n             - Черный жакет с пайетками станет основой твоих зимних образов. Жакет-бомбер станет дополнением сдержанных образов на учебу или в офис. Жакет можно накинуть вечером поверх комбинации и отправиться на свидание или в театр. Он отлично будет смотреться и в кэжуал-образах с объемным низом на низкой посадке. Сочетай его с твидовой юбкой из коллекции, чтобы получить цельный образ на Новый год или Рождество. Заверши образ удобной обувью и стильными аксессуарами из новой коллекции Befree \r\n             - Размер на модели: S \r\n             - Параметры модели: рост 177, бюст 81, талия 60, бедра 90 \n -цена: 5000 rub\n"), name = "Укороченный женский жакет-бомбер свободного кроя" });


            });
        }
    }
}
