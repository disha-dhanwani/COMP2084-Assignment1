# COMP2084 - Server Side Scripting ASP.NET

## Title: SNEAKERBOX E-commerce Website

This assignment is a part of my ASP.NET course at Georgian College. There are 3 components to this assignment. 
1. CRUD functionalities
2. Authentication and Authorization
3. Shopping Cart & Stripe Payment

SNEAKERBOX is a retail website specifically for sneakers. Users can purchase sneakers of various brands and get information about different sneakers on this site.

## Authentication & Authorization:

  - Anonymous users can view a lot of information along with the price for all sneakers. However, if they want to add any sneaker to their cart they will have to login first.

  - Any registered customer with valid credentials (local or social login) is authorized to view all products and proceed with any item by adding it to cart, if they wish. They can later also view all sneakers in the shopping cart.

  - An admin is authorized to control the entire site by adding or modifying any detail, such as: creating/adding a new sneaker product or brand, edit any existing information or deleting any sneaker/brand. Admin can also view any order details if any.

(A few methods like 'adding the product to cart' or 'viewing the order details' are not fully functional for now.)

As of now, this site is hosted on my local server. 

## Shopping Cart

- Users can now add products to their shopping cart, by specififying the quantity and sizes. Anonymous users would have to register/login in order to checkout with their items.

*The payment part of the project could not be completed due to unexpected errors.*

## Details:
This web application was built by me on Visual studio using MVC Entity Frameworks and connecting to the database 'SneakerBoxStore' on my local server.
The application includes the following languages: C#, Javascript, HTML and CSS.

*A part of the code - Session Extension - is from https://www.talkingdotnet.com/store-complex-objects-in-asp-net-core-session/ *
*The site layout (CSS) is from https://bootswatch.com/lux/*

SNEAKERBOX © Disha Dhanwani (200434069) - Georgian College
