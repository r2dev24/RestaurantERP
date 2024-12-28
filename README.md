# RestaurantERP - Development <img src="https://img.shields.io/badge/C%23-Developer-blue?style=flat-square&logo=c-sharp" alt="C#"> <img src="https://img.shields.io/badge/.NET-Core_Framework-blueviolet?style=flat-square&logo=dotnet" alt=".NET"> <img src="https://img.shields.io/badge/SQL%20Server-Database-red?style=flat-square&logo=microsoft-sql-server" alt="SQL Server"> 

1. Database Modelling(Last Update: Dec 27, 2024)
<img src="https://github.com/r2dev24/RestaurantERP/blob/main/Blank%20diagram.png">

## Development History

### Dec 28, 2024
1. **Employee List View**
   * Displays BranchMemberViewModel data in a structured table format.
   * Includes columns for:
      - Branch
      - Role
      - Name
      - Birth Date
      - Contact
      - Actions (Detail and Delete buttons).
        
2. **Detail Modal**
   * A Bootstrap-based modal to display detailed information for a selected employee.
   * Dynamically updates modal content when the Detail button is clicked.
     
3. **Dynamic Data Loading**
   * Utilizes the data-id attribute on the Detail button to identify the selected employee.
   * Uses JavaScript (fetch API) to fetch employee details from the server via a dedicated endpoint (/Employee/GetEmployeeDetail).
   * Injects the fetched Partial View into the modal dynamically.

4. **Partial View Integration**
   * A Partial View (_EmployeeDetailPartial) displays:
      - Employee Name
      - Role
      - Branch
      - Birth Date
      - Contact Information
        
5. **Pagination**
   * Added pagination for the employee list.
   * Displays:
      - Page numbers.
      - Previous/Next buttons.
   * Maintains proper state using CurrentPage and TotalPages values passed to the view.

6. **Bug Fixes**
   * Resolved JavaScript errors related to attribute handling (this.getAttribute).
   * Corrected missing #modalContent issue by targeting .modal-content for updates.


7. **Delete Button Update**
   - Updated the `Delete` button in the Razor View:
     - Replaced `asp-route-email` with `asp-route-id` to correctly pass the `MemberID` to the controller.

8. **Controller Logic Enhancement**
   - **`DeleteEmployee` Method**:
     - Searches for the employee using the provided `MemberID`.
     - Handles the following scenarios:
       - If the employee record does not exist:
         - Logs an informational message.
         - Redirects the user to the `Index` page.
       - If the deletion is successful:
         - Removes the employee from the database.
         - Redirects to the `EmployeeList` page.
       - If the deletion fails:
         - Logs the error.
         - Redirects the user to an error page for further assistance.

9. **Improved Razor View**
   - Simplified the `Delete` button by using the `asp-route-id` attribute for consistent data transfer.
   - Organized the `Detail` and `Delete` buttons for clarity in the table structure.

10. **Enhanced Error Handling**
   - Ensured the `DeleteEmployee` method:
     - Redirects immediately if the employee record is `null`.
     - Handles exceptions gracefully, logging detailed error messages for debugging.


---

### Dec 27, 2024

1. **View (Add New Employee Form)**
   - Form Creation: Created a form to input branch, role, and employee information.

2. **Dropdown Lists:**
   - Populated the dropdown lists with branch and role data from the database.

3. **Controller (EmployeeController)**
   - Index: Returns the main view.
   - AddEmployee: Fetches branch and role lists from the database and passes them to the view.
   - AddNewMember: Validates form data, then saves the new employee and their address and role information to the database.

Extra Work 

4. **Fetching Data from Database**
   - Asynchronously fetches data from BranchMembers, MemberRoles, MemberAddresses, BranchRoles, and Branches.
     
5. **Combining Data and Creating ViewModel**
   - Combines address, role, and branch information for each member to create a `BranchMemberViewModel` list.
     
6. **Displaying Data in Razor View**
   - Displays the `BranchMemberViewModel` list in a table format in the Razor view.
   - Additionally, displays the branch list to show each member's branch information.

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

