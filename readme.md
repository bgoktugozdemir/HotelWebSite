# Hotel Web Site with Admin Panel & Database

## Which technologies I used?
I used 
* **ASP.NET MVC** *(for back-end)*
* **MSSQL** *(for database)*

## What can you do?
You can do lots of things.
For example:
```
 Booking Management
 Blog Management
 Testimonial Management
 Room Management
 Room Type Management
 Customer Management
 Employee Management
 Setting Management
```

## How can you connect DB?
First of all, database needs to be created.
```
Use "WebOtel.bak" backup file for it.
```
After that, connect the project to DB.
```
Open "Web.config" in project.
```
Find
```
<add name="OTELEntities" connectionString="metadata=res://*/DataModel.HotelModel.csdl|res://*/DataModel.HotelModel.ssdl|res://*/DataModel.HotelModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\MSSQLSERVER02;initial catalog=WebOtel;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
```
Remove **data source** and write **your server name** li.
Optionally, remove **initial catalog** and write **your DB name**
