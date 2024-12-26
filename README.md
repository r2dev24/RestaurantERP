# RestaurantERP - Development | C#, ASP.NET Core MVC, SQL Server
<img src="https://github.com/r2dev24/RestaurantERP/blob/main/Blank%20diagram.png">

## Dec 26, 2024<br>
* Detail Button Update:<br>
  - Added data-email attribute to pass each user's email.<br>
  - Configured Ajax requests for server communication.<br>
  
* Ajax Request with JavaScript:<br>
  - Used fetch to retrieve Partial View data from the server when the Detail button is clicked.
  - Dynamically inserted the received data into the Modal content.
     
* Controller Implementation:
  - Created the GetUserDetail action to fetch user data by email and return a Partial View.
    
* Partial View Creation:
  - Designed _UserDetail.cshtml to display user details such as name, email, and contact information.

* Database Design
  - Designed tables for Branch and BranchAddress with proper relationships.

* Controller Implementation
  - Created BranchController and implemented the AddNewBranch action.
  - Fetched the logged-in user's account via email and saved branch data.

* Razor View
  - Built the AddBranch view with a form for branch creation.
  - Used asp-for with Bootstrap for UI and validation.

* Problem Solved
  - Logged errors for validation failures.
  - Fixed issues related to foreign key relationships and data saving.
    
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
