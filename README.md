# 🧾 Asset Tracking Console Application

This is a simple C# console application for tracking company assets such as computers and smartphones.  
It allows users to input asset data, organize it by office, and view upcoming expirations based on a 3-year asset lifespan.

---

## 📦 Features

- Add assets manually via console
- Track computers and smartphones
- Group assets by office (USA, Sweden, Germany)
- Automatic currency conversion based on ECB live rates
- Colored output to show assets near end-of-life:
  - 🔴 Red: less than 3 months remaining
  - 🟡 Yellow: less than 6 months remaining
- Clean, sorted table display by office, type, and date

---

## 🏗️ Project Structure

/Models
├── Asset.cs
├── Computer.cs
├── Smartphone.cs
├── Office.cs
├── Price.cs
AssetManager.cs
CurrencyConverter.cs
Program.cs

---

## 🖥️ Technologies

- C# (.NET 8)
- Console-based user interface


