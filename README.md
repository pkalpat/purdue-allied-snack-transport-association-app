# Purdue Allied Snack Transport Association (Purdue PASTA) App
<div align="center">

# 📱 P.A.S.T.A. Student App
### **P**urdue **A**llied **S**nack **T**ransport **A**ssociation — Mobile Client

**Track your autonomous campus delivery, unlock your food hatch, and order straight to your dorm.**

![Status](https://img.shields.io/badge/Status-In_Development-orange?style=for-the-badge)
![Language](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Framework](https://img.shields.io/badge/.NET_MAUI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Platform](https://img.shields.io/badge/iOS_%7C_Android-000000?style=for-the-badge&logo=apple&logoColor=white)
![Purdue](https://img.shields.io/badge/Purdue-Boiler_Up-CEB888?style=for-the-badge&labelColor=000000)

</div>

---

## About This Repo

This repository holds the student-facing mobile app for **P.A.S.T.A.**, built entirely in **C#**. 

While the robots themselves run on Python, C++, and Rust, this app is what Purdue students use on their phones to place DoorDash-backed orders, watch their bot cross campus in real time, and pop the cargo hatch when it arrives outside their dorm.

---

## Core Features

* **DoorDash API Checkout** — Browse participating campus spots and local restaurants without leaving the app.
* **Live Campus Map Tracking** — Real-time GPS telemetry showing your bot's route across West Lafayette sidewalks and crosswalks.
* **One-Tap Hatch Unlock** — Securely unlocks the bot's cargo bay via Bluetooth/API handshake once it pulls up to your dorm (Harrison, McCutcheon, Shreve, Wiley, etc.).
* **Delivery Alerts** — Push notifications when your food is picked up, crossing State Street, and arriving outside.

---

## Tech Stack (100% C#)

| Component | C# Tool / Library | Role |
| :--- | :--- | :--- |
| **UI & Cross-Platform** | **.NET MAUI** | Single C# codebase compiling natively to both iOS and Android. |
| **Architecture** | **MVVM (CommunityToolkit.Mvvm)** | Clean separation between app screens, order state, and live telemetry data. |
| **API & Telemetry** | **HttpClient & SignalR** | Talks to the Python DoorDash bridge and streams live bot coordinates from the Rust fleet server. |
| **Hardware Handshake** | **Plugin.BLE (C#)** | Local Bluetooth Low Energy fallback to unlock the cargo hatch if campus cell signal drops. |

---

## App-to-Bot Flow

```mermaid
graph LR
    A[📱 C# Student App] -->|Places Order| B[🍔 DoorDash API Bridge]
    B -->|Dispatches Bot| C[🤖 P.A.S.T.A. Fleet]
    C -->|Live GPS Stream| A
    A -->|BLE / API Unlock| D[🔓 Cargo Hatch Opens]
