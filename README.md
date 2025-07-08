
# 📚 BazzarBook - E-commerce Web Application for Book Sales

**Bulky Book** is a feature-rich e-commerce web application tailored for book sales, built using **ASP.NET Core MVC**. The platform allows users to browse books by category, add items to their shopping cart or wishlist, and securely complete purchases via **Stripe** payment integration. It includes robust features like order tracking, user authentication, and role-based access control for admins, employees, and customers.

Administrators have access to an intuitive dashboard for managing books, categories, companies, and order statuses. The application uses **Entity Framework Core** for seamless database interactions and follows best practices, including **SOLID principles** and responsive design, ensuring a scalable, user-friendly experience.

---

## 🚀 Features

- 🛒 Shopping cart and wishlist
- 🔐 Role-based authentication (Admin, Employee, Customer)
- 📦 Order placement and tracking
- 🧾 Admin dashboard for managing books, categories, and companies
- 💳 Stripe payment integration
- 📱 Responsive UI with Bootstrap
- 🗂️ Clean architecture using Repository and Unit of Work patterns

---

## 🧰 Tech Stack

- **Frontend:** HTML, CSS, Bootstrap, JavaScript
- **Backend:** ASP.NET Core MVC, C#
- **Database:** SQL Server, Entity Framework Core
- **Payment Gateway:** Stripe API
- **Tools:** Visual Studio, Git

---

## 🛠️ Getting Started

### Prerequisites

- .NET SDK 6.0+
- SQL Server
- Stripe account (for API keys)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/YourUsername/BulkyBook.git
   cd BulkyBook
   ```

2. Update `appsettings.json` with your connection string and Stripe keys.

3. Apply migrations and update the database:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Visit `http://localhost:5000` in your browser.

---

## 📸 Screenshots

### 🏠 Home Page  
<!-- Add screenshot here -->  
![Home Page](screenshots/home.png)

### 🛍️ Shopping Cart  
<!-- Add screenshot here -->  
![Cart](screenshots/cart.png)

### 🔐 Login / Register  
<!-- Add screenshot here -->  
![Auth](screenshots/auth.png)

### 📦 Admin Dashboard  
<!-- Add screenshot here -->  
![Admin Dashboard](screenshots/admin.png)

### 💳 Checkout with Stripe  
<!-- Add screenshot here -->  
![Checkout](screenshots/checkout.png)

---

## 📬 Contact

Feel free to reach out for collaboration or questions!  
**Ahmed Nasser** – [LinkedIn](https://linkedin.com/in/ahmed-nasser-91aab6279) | [GitHub](https://github.com/AhmedNasser23)
