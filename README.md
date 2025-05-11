<p align="center">
  <img src="https://github.com/user-attachments/assets/6f91d2f6-6a1c-438d-8d9b-a0a622ae10d7" alt="Agri Connect Banner" />
</p>

# Agri-Energy Connect

**Agri-Energy Connect** is more than a platform,  it's a movement. Rooted in the South African landscape, it reimagines the future of farming by seamlessly blending agriculture with renewable energy. Built on a dynamic MVC architecture, it empowers farmers and innovators to collaborate, implement sustainable practices, and unlock the true potential of green technology. Agri-Energy Connect lights the path toward a smarter, cleaner, and more resilient agricultural future.

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

---

# 🟢 Introduction

In response to the growing need for sustainable agricultural practices and the integration of green energy solutions in South Africa, the visionary initiative named "Agri-Energy Connect" has been conceptualized. This initiative aims to develop an innovative web platform that connects the agricultural sector with green energy technology providers. Key features of the platform include a Green Energy Marketplace and a platform for farmers to sell their products.

<img src="https://media.baamboozle.com/uploads/images/604865/1676058321_96119_gif-url.gif" />

### Green Energy Marketplace

- A marketplace for green energy solutions tailored to agricultural needs, such as solar-powered irrigation systems, wind turbines for farms, and biogas energy solutions.

### Farmer Product Selling Platform

- A platform where farmers can sell their products.

## 🟠 Functionality Requirements

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

## 🟢 Setup Instructions

1. **Tools Required:**
   - Visual Studio (latest)
   - .NET Framework
   - Microsoft.EntityFrameworkCore

2. **Clone the App:**
   ```bash
   git clone https://github.com/YOUR-USERNAME/Agri-Energy-Connect.git
   ```

3. **Dependencies:**
   - Open the project in Visual Studio.
   - Restore NuGet packages.

<img src="https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/aa9d2b73-a2e7-4148-b638-2b258ffe7644/dfulzfg-1f018aa1-8021-4fc7-9032-710dd7953e43.gif"/>

## 🟠 Installation and Setup

1. Navigate to the project root.
2. Run dependency restore.
3. Update `appsettings.json` with your DB string.
4. Run database migrations.
5. Build and run.

## Building and Running the Prototype

1. Build in Visual Studio.
2. Run the app or deploy to server.

## System Functionalities and User Roles

**Farmers:**
- Add/view their products.

**Employees:**
- Add new farmers.
- View/filter farmer products.

![gif](https://cdn.pixabay.com/animation/2023/06/29/06/23/06-23-06-393_512.gif)

## 🟢 Roadmap

### Completed
- [x] DB schema and integration
- [x] Auth system with roles
- [x] CRUD for users
- [x] Marketplace feature
- [x] Search/filtering

### In Progress
- [ ] Payment gateway

### Planned
- [ ] UI improvements
- [ ] Weather API
- [ ] Analytics dashboard

## 🟢 Images

### Teasers
![img1](https://github.com/VCDN-2024/prog7311-part-2-Leighche/assets/104209100/a1a8c6bc-3b77-4ed1-ae35-63b3d2577bd1)
![img2](https://github.com/VCDN-2024/prog7311-part-2-Leighche/assets/104209100/f0a20c23-ae14-4f83-8425-1fd4b2ed9b3d)
![img3](https://github.com/VCDN-2024/prog7311-part-2-Leighche/assets/104209100/11d15d28-a35e-4f62-a10f-a0fc2f47ed1d)
![img4](https://github.com/VCDN-2024/prog7311-part-2-Leighche/assets/104209100/44061aae-a047-40e1-826c-53a715f8ecdc)
![img5](https://github.com/VCDN-2024/prog7311-part-2-Leighche/assets/104209100/38560584-a169-405f-955b-99b015f0dc93)
![img6](https://github.com/VCDN-2024/prog7311-part-2-Leighche/assets/104209100/7c36fc5d-b873-493e-bbe5-a6f04de9633c)

## Demo Video

[![Watch the Demo](https://github.com/VCDN-2024/prog7311-part-2-Leighche/assets/104209100/23b172e4-a4f5-4bd7-90fe-d4eba3a63e24)](https://youtu.be/anhSqbKigp8)

## 📈 Technology Stack

<table>
  <tr>
    <td align="center">
      <img src="https://cdn.worldvectorlogo.com/logos/c--4.svg" width="48" height="48" alt="C#"/><br/>C#
    </td>
    <td align="center">
      <img src="https://cdn-icons-png.flaticon.com/512/2772/2772128.png" width="48" height="48" alt="SQL Server"/><br/>SQL
    </td>
    <td align="center">
      <img src="https://cdn-icons-png.flaticon.com/512/732/732212.png" width="48" height="48" alt="HTML"/><br/>HTML
    </td>
    <td align="center">
      <img src="https://cdn-icons-png.flaticon.com/512/732/732190.png" width="48" height="48" alt="CSS"/><br/>CSS
    </td>
    <td align="center">
      <img src="https://cdn-icons-png.flaticon.com/512/5968/5968292.png" width="48" height="48" alt="JavaScript"/><br/>JavaScript
    </td>
  </tr>
</table>

<img src="https://cdn.pixabay.com/animation/2023/08/21/15/08/15-08-12-734_512.gif" />

## Get Started

To get started, go to [Installation and Setup](#installation-and-setup).

## 🟠 Contributing

We welcome contributions! To contribute:
1. Fork the repo
2. Create a new branch
3. Commit your changes
4. Push your branch
5. Submit a pull request

<img src="https://media.tenor.com/u4RZrIbwcwEAAAAj/pokemon-miltank.gif" />

## 🟢 Reference List

- Bootswatch. *Minty* theme: https://bootswatch.com/minty/  
- Dindi, S. (2023). *Hidden Search Bar Tutorial*: https://www.makeuseof.com/search-bar-html-css-javascript/  
- GeeksForGeeks (2022). *Fade-In JavaScript*: https://www.geeksforgeeks.org/how-to-add-fade-in-effect-using-pure-javascript/  
- StackOverflow (2017). *EmailJS Help*: https://stackoverflow.com/questions/58791656/send-email-directly-from-javascript-using-emailjs  
- W3Schools (2024). *Fixed Sidebar*: https://www.w3schools.com/howto/howto_css_fixed_sidebar.asp  
- W3Schools (2024). *Date Input*: https://www.w3schools.com/TAGS/att_input_type_date.asp

