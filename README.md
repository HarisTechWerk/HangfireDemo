# HangfireDemo

A **.NET 8** application demonstrating **background task processing** with [Hangfire](https://www.hangfire.io/). Easily schedule recurring jobs (e.g., daily newsletters) or fire-and-forget tasks (e.g., sending emails) without blocking your main web requests.

## Table of Contents

1. [Overview](#overview)
2. [Features](#features)
3. [Prerequisites](#prerequisites)
4. [Getting Started](#getting-started)

## Overview

**HangfireDemo** is a simple ASP.NET Core project using the **Hangfire** library for managing background jobs. It supports:

- **One-off tasks** (fire-and-forget)
- **Recurring jobs** (cron-based scheduling)
- Real-time **monitoring** via the Hangfire Dashboard

This setup is typical in enterprise apps needing asynchronous tasks, like processing images, sending notifications, or cleaning up databases.

## Features

1. **Hangfire Integration** - Configured with `Hangfire.AspNetCore` and `Hangfire.SqlServer`.
2. **SQL Database Storage** - Optionally uses **Azure SQL** or a local SQL Server for storing job data.
3. **Dashboard** - Access a user-friendly admin interface at `/hangfire`.
4. **Recurring & Fire-and-Forget** - Example endpoints demonstrate both styles of background jobs.

## Prerequisites

- **.NET 8 SDK**
- **SQL Server** (LocalDB, SQL Express, or Azure SQL)
- **Git**

## Getting Started

1. **Clone** the repository:
   ```bash
   git clone https://github.com/HarisTechWerk/HangfireDemo.git
   cd HangfireDemo
   ```
