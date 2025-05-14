![agri_energy_linkedin_banner](https://github.com/user-attachments/assets/53803da0-f6d6-4ce0-b584-cb0790a6adbf)


## Agri-Energy Connect

<span style="color:green;"><strong>Agri-Energy Connect</strong></span> is more than a platform, it's a movement. Rooted in the South African landscape, it reimagines the future of farming by seamlessly blending agriculture with renewable energy. Built on a dynamic MVC architecture, it empowers farmers and innovators to collaborate, implement sustainable practices, and unlock the true potential of green technology. Agri-Energy Connect lights the path toward a smarter, cleaner, and more resilient agricultural future.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Table of Contents

1. [Introduction](#introduction)
2. [Functionality Requirements](#functionality-requirements)
3. [Setup Instructions](#setup-instructions)
4. [Installation and Setup](#installation-and-setup)
5. [Building and Running the Prototype](#building-and-running-the-prototype)
6. [System Functionalities and User Roles](#system-functionalities-and-user-roles)
7. [Roadmap](#roadmap)
8. [Images](#images)
9. [Demo Video](#demo-video)
10. [Technology Stack](#technology-stack)
11. [Get Started](#get-started)
12. [Contributing](#contributing)
13. [Reference List](#reference-list)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Introduction

Driven by the urgent demand for eco-friendly farming and the adoption of renewable energy in South Africa, the project known as "Agri Energy Connect" was created with a purpose. This platform is designed to unite the agricultural community with green technology providers through an intuitive and innovative web solution. Its core features include a digital marketplace for clean energy tools and a dedicated space for farmers to market their produce directly.. This initiative aims to develop an innovative web platform that connects the agricultural sector with green energy technology providers. Key features of the platform include a Green Energy Marketplace and a platform for farmers to sell their products.

### Clean Energy Market

- A digital hub where users can explore eco-friendly solutions made specifically for farms, including solar irrigation tools, wind-powered systems, and bioenergy technologies.

### Produce Exchange Zone

- A feature that allows local farmers to list and promote their fresh produce directly to potential buyers simply and securely.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Functionality Requirements

1. **Database Development and Integration:**
   - Design and integrate a relational database to manage information about farmers and their products.
   - Populate the database with sample data to simulate real-world scenarios.

2. **User Role Definition and Authentication System:**
   - Two user roles:
     - Farmer: Can add and view their products.
     - Employee: Can add farmer profiles and view/filter all farmer products.
   - Secure login and role-based access.

3. **Functional Features:**
   - **Farmers:**
     - Add products with name, category, and production date.
   - **Employees:**
     - Add farmer profiles.
     - View/filter products by date range and type.

  
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Setup Instructions

1. **Tools Required:**
   - <img src="https://visualstudio.microsoft.com/wp-content/uploads/2021/10/Product-Icon.svg" width="20" /> Visual Studio 2022
   - <img src="https://cdn-icons-png.flaticon.com/512/5968/5968292.png" width="20" /> .NET Framework
   - <img src="https://cdn-icons-png.flaticon.com/512/5968/5968292.png" width="20" /> Microsoft.EntityFrameworkCore

2. **Clone the App:**
  ```bash
git clone https://github.com/stxphanx30/Poe-part-2-Prog7311.git
```
or use the zip file provided

<img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExeWI2NG8xMmxkZjc2eXowMjVlaWxqYjBqdTQyeW1zbGxpNXF5YWd1cSZlcD12MV9naWZzX3NlYXJjaCZjdD1n/TlK63EA6F1qRb7lll6M/giphy.gif" width="400"/>

4. **Dependencies:**
   - Open the project in Visual Studio.
   - Restore NuGet packages.
     Make sure these packages are added:
   - Microsoft.AspNetCore.Identity.EntityFrameworkCore
   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools

<img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExMWMwMmtwcmc4ZHg0N3gzaWR5dzVnenZxMXRtNWN6ZTkweDdwa21qeiZlcD12MV9naWZzX3NlYXJjaCZjdD1n/VHHxxFAeLaYzS/giphy.gif"  width="400"/>


-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Installation and Setup

1. Navigate to the project root.
2. Run dependency restore.
4. In the package manager console, run: Update-database.
5. Build and run.

   
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Building and Running the Prototype

1. Build in Visual Studio.
2. Run the app
3. Use these credentials to log in:
   - as a farmer: Email:farmer1@agrienergy.com, Password: Farmer@123
   - as an employee:Email: employee1@agrienergy.com, Password: Employee@123
You can also find these credentials under Data/DbInitialiser.cs file
-- there we go you can now see,add farmers and see product as an employee,and add,see product as a farmer-----

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## System Functionalities and User Roles

**Farmers:**
- Register their produce with essential details.
- Track and review their product listings.

**Employees:**
- Onboard farmers and manage their profiles.
- Browse and filter produce listings by various criteria.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

  ##  Roadmap

Here's our roadmap for Agri-Energy Connect, with an overview of completed tasks and planned features.

### Completed
- [x] Database schema design and integration.
- [x] User authentication system with role-based access control.
- [x] Basic CRUD functionality for farmers and employees.
- [x] Implementation of search and filtering functionality for products.
- [x] Implementation of Green Energy Marketplace.
### In Progress
- [ ] none
  
### Planned
- [ ] Under Review.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Images
![image](https://github.com/user-attachments/assets/94bd48e2-4a3d-46df-9f59-a91d2b9b5d2c)
![image](https://github.com/user-attachments/assets/90556144-f551-4032-bccc-27b46d0e3f16)
![image](https://github.com/user-attachments/assets/d6005939-7600-4951-9dfe-ab7b1e6469b9)
![image](https://github.com/user-attachments/assets/482d259a-73af-462d-adc8-20c7b7ff898d)
![image](https://github.com/user-attachments/assets/e68da4f6-49aa-4b6d-9063-949be9a91fb6)
![image](https://github.com/user-attachments/assets/4a854337-569f-4691-8104-7d9baa940a66)
![image](https://github.com/user-attachments/assets/2771efbc-37c2-45b0-8c22-8317488cd493)










-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Demo Video





-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Technology Stack

> Tools and languages used.

<table>
  <tr>
    <td align="center" width="120">
      <img src="https://cdn.worldvectorlogo.com/logos/c--4.svg" width="48" height="48" alt="C#"/><br/>C#
    </td>
    <td align="center" width="120">
      <img src="https://cdn-icons-png.flaticon.com/512/2772/2772128.png" width="48" height="48" alt="SQL Server"/><br/>SQL
    </td>
    <td align="center" width="120">
      <img src="https://cdn-icons-png.flaticon.com/512/732/732212.png" width="48" height="48" alt="HTML"/><br/>HTML
    </td>
    <td align="center" width="120">
      <img src="https://cdn-icons-png.flaticon.com/512/732/732190.png" width="48" height="48" alt="CSS"/><br/>CSS
    </td>
    <td align="center" width="120">
      <img src="https://cdn-icons-png.flaticon.com/512/5968/5968292.png" width="48" height="48" alt="JavaScript"/><br/>JavaScript
    </td>
    <td align="center" width="120">
      <img src="https://visualstudio.microsoft.com/wp-content/uploads/2021/10/Product-Icon.svg" width="48" height="48" alt="Visual Studio"/><br/>Visual Studio 2022
    </td>
    <td align="center" width="120">
      <img src="https://upload.wikimedia.org/wikipedia/commons/2/2f/Google_2015_logo.svg" width="48" height="48" alt="Google"/><br/>Google
    </td>
  </tr>
</table>

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

 ## Get Started

To get started, go to [Installation and Setup](#installation-and-setup).

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Reference List

- Bootstrap, 2024. Introduction to Bootstrap 5.3. [online] Available at: https://getbootstrap.com/docs/5.3/getting-started/introduction/ [Accessed 14 May 2025].
- GeeksforGeeks, 2023. Virtual LAN (VLAN). [online] Available at: https://www.geeksforgeeks.org/virtual-lan-vlan/ [Accessed 14 May 2025].
- Microsoft, 2024. Entity Framework Core documentation. [online] Available at: https://learn.microsoft.com/en-us/ef/core/ [Accessed 14 May 2025].
- Mozilla, 2024. CSS: Cascading Style Sheets. MDN Web Docs. [online] Available at: https://developer.mozilla.org/en-US/docs/Web/CSS [Accessed 14 May 2025].
- W3Schools, 2024. HTML Tutorial. [online] Available at: https://www.w3schools.com/html/ [Accessed 14 May 2025].
- VMware, 2023. What is a Virtual Machine? [online] Available at: https://www.vmware.com/topics/virtual-machine [Accessed 14 May 2025].
  
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
<p align="center">
  <a href="#Agri-Energy-Connect" title="Back to top">
    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOB8sltDfs2k4I4C2rWExK4al1Zd7fqw8wUQ&s" width="40" alt="Farm arrow up"/>
  </a>
</p>
<p align="center">
  <span style="color:green;"><strong>Back to top</strong></span>
</p>
