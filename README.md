# UserManagement
Prerequisites 
Git application, .NET SDK, Postman

1. Open a folder in your local directory. 
2. Clone the application from github to the local directory. 
(Open git bash in the folder and type the following command.
git clone https://github.com/RoshniCh/UserManagement.git)
3. Do a dotnet run of the application in the command prompt
(dotnet run) 
This will start the server and the database (SQLite) will be created
4. Use Postman Collection provided (User management) to run the endpoints. Import using Link.
(https://www.getpostman.com/collections/6f1c62a9c71264dc4fdc)
Please note that the values of id set in the postman will work for the first run of the application. 
If you are rerunning, please change the id to a value that exists. For eg, create a new user and use that id in the update/delete.

5. There is also a swagger file at https://localhost:5001/Swagger/index.html if you want to check the endpoint and the input/output options.