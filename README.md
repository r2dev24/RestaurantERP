# RestaurantERP - Development | C#, ASP.NET Core MVC, SQL Server

## Dec 25, 2024<br>
#### Delete Functionality:

* Implemented logic to delete a user based on their email.
* Used FirstOrDefaultAsync to fetch and delete user data.
* Redirected to the User List after successful deletion.

## Dec 24, 2024<br>
### SignIn View
* Public Access: Home/Index
* Authorized Users Only: Main/Index
* Authentication: Managed using claims
* Controllers:
* Home and Main: View controllers
* AuthController: Handles sign-in and sign-out
### ERP User Management
* Features:
  * Displays user roles, email, full name, and contact details in a Bootstrap-styled table
  * Includes Delete and Detail buttons for each user
  * Dynamic role display using a switch statement
  * Pagination for large datasets with Bootstrap design
* Data Integration:
  * Combines Account, Personal, and Address data for efficient management
### Planned Enhancements
  * Add functionalities for Delete, Detail, Search, and Filtering.
