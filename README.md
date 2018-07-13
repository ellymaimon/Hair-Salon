# Salon Management Tool

#### Epicodus C# Code Review, July 13, 2018

#### By Elly Maimon

## Description

Salon Management Tool is a .NET web application that allows a user to add, update, and delete stylists and add clients to particular stylists.

## How to Recreate Database

* To recreate the main database, enter the following commands into terminal:
    * > mysql -uroot -proot;
    * > CREATE DATABASE eliran_maimon;
    * > USE eliran_maimon;
    * > CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), experience VARCHAR(255), specialty VARCHAR(255), phone VARCHAR(255));
    * > CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), gender VARCHAR(255), stylist_id INT)
* To recreate the test database, enter the following commands into terminal:
    * > mysql -uroot -proot;
    * > CREATE DATABASE eliran_maimon_test;
    * > USE eliran_maimon_test;
    * > CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), experience VARCHAR(255), specialty VARCHAR(255), phone VARCHAR(255));
    * > CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), gender VARCHAR(255), stylist_id INT)

## Setup on OSX

* Download and install .Net Core 1.1.4
* Download and install Mono
* Clone the repo
* Recreate the main database and test database using the instructions above
* Run `dotnet restore` from project directory and test directory to install packages
* Run `dotnet build` from project directory and fix any build errors
* Run `dotnet test` from the test directory to run the testing suite
* Run `dotnet run` to start the server

## Technologies Used

* .Net Core 1.1.4
* mySQL
* phpMyAdmin

## Links

* Repository: https://github.com/ellymaimon/Hair-Salon

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Elly Maimon**
