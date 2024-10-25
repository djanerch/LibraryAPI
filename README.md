# Jupiter Library🚀
## The project represent online Library.

## 🗹Prerequisites

Before you begin, ensure you have met the following requirements:
* <a href="https://visualstudio.microsoft.com/">Visual Studio</a>
* <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">Sql Server</a>
* <a href="https://dotnet.microsoft.com/en-us/download/dotnet/5.0">.net core 5.0</a>

## 🛠️Installing Jupiter Library

To install Jupiter-Library, follow these steps:

Clone this git repository
```
https://github.com/djanerch/LibraryAPI.git
```

To run API

1. Open Visual Studio
2. Click `CTRL + F5` or press the button shown in the image to start
<img src="https://user-images.githubusercontent.com/96980908/196473526-a8034784-897a-4d68-a8d7-432492b221a9.png" height = "500" alt=""/>
3. Now api is working on url: https://localhost:5001

4. You can use my postman test collection to test API
link for postman collection: https://www.postman.com/collections/5e2285318951d0980114

## :star:Roles

* Reader
* Admn

Library API have default profiles for reader and admin
you can use them

<img src="https://user-images.githubusercontent.com/96980908/196482243-3273a1be-125c-48c1-9060-f4108e519f2f.png" alt=""/>

## :zap:Getting started

* Let's make our first API request to the Library API!
* I will use postman for demonstration

* Request to home page

request:
<img src="https://user-images.githubusercontent.com/96980908/196477349-d49334d5-6aa1-4864-be2c-8fa584b08a76.png" alt=""/>

response:
<img src="https://user-images.githubusercontent.com/96980908/196477999-6ce457ab-96da-4190-b7a0-ae9855d2c2b3.png" alt=""/>

* Request to books page `without` filter

request:
<img src="https://user-images.githubusercontent.com/96980908/196478953-a0a5edb2-26b7-4ceb-96ca-d2b5bf5d5174.png" alt=""/>

response:
<img src="https://user-images.githubusercontent.com/96980908/196479278-7743f715-da0c-47d8-8d11-87bbe56bf87e.png" alt=""/>

* Request to books page `with` filter

request:
<img src="https://user-images.githubusercontent.com/96980908/196483845-bc4f90bd-e935-4f72-bc71-16f546363dbf.png" alt=""/>

response:
<img src="https://user-images.githubusercontent.com/96980908/196484245-cd97e4f8-6112-43ee-a95e-ebb8d8903ad6.png" alt=""/>

* Тhese are only a small part of all possible requests. You can see all posible requests at the next point.

## :mailbox_with_mail:All posible endpoints

* For admins
`https://localhost:5001/api/checkbooks`
`https://localhost:5001/api/addbook`
`https://localhost:5001/api/removebook`
`https://localhost:5001/api/addpointstouser`

* For users
`https://localhost:5001/api/takebook`
`https://localhost:5001/api/givebackbook`

* For both
`https://localhost:5001/api/books?header=string&isFree=true&fromPages=0&toPages=400&page=1`
`https://localhost:5001/api/books?page=1`
`https://localhost:5001/api/myprofile`
`https://localhost:5001/api/allprofiles`
`https://localhost:5001/api/`
`https://localhost:5001/api/login`
`https://localhost:5001/api/register`
