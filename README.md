
# 📚 BazzarBook - E-commerce Web Application for Book Sales

**BazzarBook** is a feature-rich e-commerce web application tailored for book sales, built using **ASP.NET Core MVC**. The platform allows users to browse books by category, add items to their shopping cart or wishlist, and securely complete purchases via **Stripe** payment integration. It includes robust features like order tracking, user authentication, and role-based access control for admins, employees, and customers.

Administrators have access to an intuitive dashboard for managing books, categories, companies, and order statuses. The application uses **Entity Framework Core** for seamless database interactions and follows best practices, including **SOLID principles** and responsive design, ensuring a scalable, user-friendly experience.

Demo Video: <a href="https://drive.google.com/file/d/1OIcpWsdZxpv8poATz4KT3QY3MJGhFZt6/view?usp=sharing">
    Show the demo
  </a>

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

- .NET SDK 8.0+
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

![image](https://github.com/user-attachments/assets/3c9614c3-976a-4ffc-b7b9-23bd5eb6766e)


### 🛍️ Shopping Cart  

![image](https://github.com/user-attachments/assets/983f68f8-538d-4daa-960d-4ed40c5cdfb9)

### 🔐 Login / Register  

![image](https://github.com/user-attachments/assets/eceda6dd-d758-4e5f-aa65-9a17baf7348f)
![image](https://github.com/user-attachments/assets/7a01deac-e413-4d9e-8354-ff722a02e5d7)

### 📦 Admin Dashboard  
![image](https://github.com/user-attachments/assets/8e34415d-c8fa-43dc-a548-79558807bdfa)
![image](https://github.com/user-attachments/assets/0e7d84ff-7bcd-4a5d-938a-b6a0498a9e7a)
![image](https://github.com/user-attachments/assets/1e073856-3031-44f6-89b0-9ef0af766da1)
![image](https://github.com/user-attachments/assets/095bd196-07f8-4f60-a9b0-59ceafa9fd02)
![image](https://github.com/user-attachments/assets/06746707-0082-4f0f-a03e-8892b2612fcd)
![image](https://github.com/user-attachments/assets/a5bd37f0-e768-4b68-ad90-fb3e7258b467)

### 💳 Checkout with Stripe  

![image](https://github.com/user-attachments/assets/388d6f99-e0b1-4aed-b049-2d32dad6d7c5)


