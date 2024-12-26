# RestaurantERP - Development <img src="https://img.shields.io/badge/C%23-Developer-blue?style=flat-square&logo=c-sharp" alt="C#"> <img src="https://img.shields.io/badge/.NET-Core_Framework-blueviolet?style=flat-square&logo=dotnet" alt=".NET"> <img src="https://img.shields.io/badge/SQL%20Server-Database-red?style=flat-square&logo=microsoft-sql-server" alt="SQL Server"> 


<img src="https://github.com/r2dev24/RestaurantERP/blob/main/Blank%20diagram.png">

## Development Progress

### Dec 27, 2024

1. View (Add New Employee Form)
   - Form Creation: Created a form to input branch, role, and employee information.

2. Dropdown Lists:
   - Populated the dropdown lists with branch and role data from the database.

3. Controller (EmployeeController)
   - Index: Returns the main view.
   - AddEmployee: Fetches branch and role lists from the database and passes them to the view.
   - AddNewMember: Validates form data, then saves the new employee and their address and role information to the database.

---

### Dec 26, 2024
#### Features Added
1. **Detail Button Update**
   - Added `data-email` attribute to pass each user's email dynamically.
   - Configured Ajax requests for seamless server communication.

2. **Ajax Request with JavaScript**
   - Used `fetch` to retrieve Partial View data from the server upon Detail button click.
   - Dynamically inserted the received data into the Modal content.

3. **Controller Implementation**
   - Created the `GetUserDetail` action to fetch user details by email and return a Partial View.

4. **Partial View**
   - Designed `_UserDetail.cshtml` to display user details like name, email, and contact information.

5. **Database Design**
   - Designed tables for `Branch` and `BranchAddress` with proper foreign key relationships.

6. **Branch Management**
   - Created `BranchController` and implemented the `AddNewBranch` action.
   - Fetched the logged-in user's account via email and saved branch data.

7. **Add Branch View**
   - Built the `AddBranch` Razor View with a form for branch creation.
   - Used `asp-for` with Bootstrap for UI styling and validation.

8. **Bug Fixes**
   - Logged validation errors for better debugging.
   - Fixed issues related to foreign key relationships and data saving.

---

### Dec 25, 2024
#### Delete Functionality
- Implemented logic to delete a user based on their email.
- Used `FirstOrDefaultAsync` to fetch and delete user data.
- Redirected to the User List after successful deletion.

---

### Dec 24, 2024
#### SignIn View
1. **Public and Authorized Access**
   - Public access: `Home/Index`
   - Authorized users only: `Main/Index`
   - Managed authentication using claims.

2. **Controllers**
   - `Home` and `Main`: View controllers.
   - `AuthController`: Handles sign-in and sign-out.

3. **ERP User Management**
   - Displays user roles, email, full name, and contact details in a Bootstrap-styled table.
   - Includes Delete and Detail buttons for each user.
   - Implements dynamic role display using a `switch` statement.
   - Supports pagination for large datasets with Bootstrap design.

4. **Planned Enhancements**
   - Add functionalities for Delete, Detail, Search, and Filtering.

