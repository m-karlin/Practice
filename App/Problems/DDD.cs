namespace App.Problems;

public class DDD
{
	// "DDD — это подход к разработке сложных систем через глубокое понимание предметной области.
	// Основная идея — создание единого языка между разработчиками и экспертами предметной области."

	// Aggregate Roots (Book, Order) - корни агрегатов, которые управляют своими внутренними сущностями
	//
	// Entity (OrderItem) - сущность с идентификатором
	//
	// Domain Service (BookStoreService) - сервис для координации бизнес-логики
	//
	// Value Objects (не показаны явно, но Price, Quantity могли бы быть ими)
	//
	// Инкапсуляцию бизнес-правил (проверка количества, обновление остатков)

	// Domain Layer - Ядро предметной области
	public class Book // Aggregate Root (Корень агрегата)
		(string title, string author, decimal price, int quantity)
	{
		public Guid Id { get; private set; } = Guid.NewGuid();
		public string Title { get; private set; } = title;
		public string Author { get; private set; } = author;
		public decimal Price { get; private set; } = price;
		public int Quantity { get; private set; } = quantity;

		public void UpdateQuantity(int newQuantity)
		{
			if (newQuantity < 0)
				throw new ArgumentException("Quantity cannot be negative");

			Quantity = newQuantity;
		}
	}

	public class Order // Aggregate Root (Корень агрегата)
	{
		public Guid Id { get; private set; } = Guid.NewGuid();
		public DateTime OrderDate { get; private set; } = DateTime.UtcNow;
		private readonly List<OrderItem> _items = [];
		public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
		public decimal TotalAmount => _items.Sum(item => item.TotalPrice);

		public void AddItem(Book book, int quantity)
		{
			if (book.Quantity < quantity)
				throw new InvalidOperationException("Not enough books in stock");

			var existingItem = _items.FirstOrDefault(item => item.BookId == book.Id);
			if (existingItem != null)
			{
				existingItem.UpdateQuantity(existingItem.Quantity + quantity);
			}
			else
			{
				_items.Add(new OrderItem(book.Id, book.Price, quantity));
			}

			book.UpdateQuantity(book.Quantity - quantity);
		}
	}

	public class OrderItem // Entity (Сущность)
		(Guid bookId, decimal unitPrice, int quantity)
	{
		public Guid BookId { get; private set; } = bookId;
		public decimal UnitPrice { get; private set; } = unitPrice;
		public int Quantity { get; private set; } = quantity;
		public decimal TotalPrice => UnitPrice * Quantity;

		public void UpdateQuantity(int newQuantity)
		{
			Quantity = newQuantity;
		}
	}

	// Application Layer - Прикладной слой (координация работы домена)
	public class BookStoreService // Domain Service (Сервис предметной области)
	{
		private readonly List<Book> _books =
		[
			new("Война и мир", "Лев Толстой", 500, 10),
			new("Преступление и наказание", "Федор Достоевский", 450, 5)
		];

		public Order CreateOrder(Dictionary<Guid, int> bookQuantities)
		{
			var order = new Order();
			foreach (var (bookId, quantity) in bookQuantities)
			{
				var book = _books.FirstOrDefault(b => b.Id == bookId);
				if (book != null)
				{
					order.AddItem(book, quantity);
				}
			}

			return order;
		}

		public List<Book> GetAvailableBooks() => _books;
	}

	public static void Run()
	{
		var bookStoreService = new BookStoreService();

		Console.WriteLine("Доступные книги:");
		foreach (var book in bookStoreService.GetAvailableBooks())
		{
			Console.WriteLine($"{book.Title} - {book.Author} - {book.Price} руб. (в наличии: {book.Quantity})");
		}

		// Создаем заказ
		var books = bookStoreService.GetAvailableBooks();
		var orderItems = new Dictionary<Guid, int>
		{
			{ books[0].Id, 2 }, // 2 экземпляра первой книги
			{ books[1].Id, 1 } // 1 экземпляр второй книги
		};

		try
		{
			var order = bookStoreService.CreateOrder(orderItems);

			Console.WriteLine($"\nЗаказ создан: {order.Id}");
			Console.WriteLine($"Общая сумма: {order.TotalAmount} руб.");
			Console.WriteLine($"Дата заказа: {order.OrderDate}");

			Console.WriteLine("\nОстатки после заказа:");
			foreach (var book in bookStoreService.GetAvailableBooks())
			{
				Console.WriteLine($"{book.Title}: {book.Quantity} шт.");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Ошибка при создании заказа: {ex.Message}");
		}
	}
}