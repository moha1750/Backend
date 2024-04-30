using BackendTeamwork.Entities;

namespace BackendTeamwork.Databases
{
    public class DatabaseContext
    {
        public IEnumerable<User> Users;
        public IEnumerable<Payment> Payments;

        public IEnumerable<Address> Addresses;

        public IEnumerable<Product> Products;
        public IEnumerable<Product> products;
        public IEnumerable<Order> Orders;
        public IEnumerable<OrderStock> OrderStock;
        public IEnumerable<Review> Reviews;


        public DatabaseContext()
        {

            this.Users =
            [
                new User(
                    new Guid("11111111-1111-1111-1111-111111111111"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid(),
                    new Guid()
                ),
                new User(
                    new Guid("22222222-2222-2222-2222-222222222222"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid("99999999-9999-9999-9999-999999999999"),
                    new Guid()
                ),
                new User(
                    new Guid("33333333-3333-3333-3333-333333333333"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid(),
                    new Guid()
                ),
                new User(
                    new Guid("44444444-4444-4444-4444-444444444444"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid(),
                    new Guid()
                ),
                new User(
                    new Guid("55555555-5555-5555-5555-555555555555"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid(),
                    new Guid()
                ),
            ];


            Products = [
                new Product( new Guid("00000000-0000-0000-0000-000000000001"), "apple", 10, "image 1", "this is an apple"),
                new Product( new Guid("00000000-0000-0000-0000-000000000002"), "banana", 13, "image 2", "this is a banana"),
                new Product( new Guid("00000000-0000-0000-0000-000000000003"), "orange", 15, "image 3", "this is an orange"),
                new Product( new Guid("00000000-0000-0000-0000-000000000004"), "avocado", 20, "image 4", "this is an avocado"),
                new Product( new Guid("00000000-0000-0000-0000-000000000005"), "strawberyy", 8, "image 5", "this is a strawberry"),
            ];


            this.Payments = [
                new Payment (new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),145678923,"Cash",new DateTime(), new Guid()),
                new Payment (new Guid(),456,"free",new DateTime(), new Guid()),
                new Payment (new Guid(),789,"visa",new DateTime(), new Guid()),

                    ];

            this.Addresses = [
                new Address(new Guid("99999999-9999-9999-9999-999999999999"), "Riyadh", "12461", "Hisham Ibn Abd Al Malek, Al Mursalat", new Guid("22222222-2222-2222-2222-222222222222"))
            ];


            this.Orders = [
                new Order(new Guid(), "pending", DateTime.Now, new Guid(), new Guid("11111111-1111-1111-1111-111111111111")),
                new Order(new Guid(), "pending", DateTime.Now, new Guid(), new Guid("11111111-1111-1111-1111-111111111111")),
                new Order(new Guid(), "pending", DateTime.Now, new Guid(), new Guid("11111111-1111-1111-1111-111111111111")),
                new Order(new Guid(), "pending", DateTime.Now, new Guid(), new Guid("22222222-2222-2222-2222-222222222222")),
                new Order(new Guid(), "pending", DateTime.Now, new Guid(), new Guid("22222222-2222-2222-2222-222222222222")),
                new Order(new Guid(), "pending", DateTime.Now, new Guid(), new Guid("33333333-3333-3333-3333-333333333333")),
            ];

            this.OrderStock = [
                new OrderStock(new Guid(), 12, new Guid()),
                new OrderStock(new Guid(), 12, new Guid()),
                new OrderStock(new Guid(), 12, new Guid()),
                new OrderStock(new Guid(), 12, new Guid()),
                new OrderStock(new Guid(), 12, new Guid()),
                new OrderStock(new Guid(), 12, new Guid()),
            ];

            this.Reviews = [
                new Review (new Guid(),5,"hala",new Guid(),new Guid()),
                new Review (new Guid(),4,"Ola",new Guid(),new Guid()),
                new Review (new Guid(),3,"Ana",new Guid(),new Guid()),
            ];
        }


    }
}