# COMPANY-API-ASP-NET

In this API, my objective is to create a management system focused on returning information about all branches, areas within these branches, employees, and equipment that are part of these areas. The system will also list all costs in specific areas and display the total expenses for the company.

## Features

- Manage branches and areas within branches
- Track employees and equipment in specific areas
- List costs associated with specific areas
- Display total expenses for the company

## Technologies Used

- C#

## Getting Started

### Prerequisites

- .NET SDK
- SQL Server (or any other supported database)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/JonathanQuaint/COMPANY-API-ASP-NET.git
   ```
2. Navigate to the project directory:
   ```sh
   cd COMPANY-API-ASP-NET
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Update the database connection string in `appsettings.json`.

### Running the Application

1. Build the project:
   ```sh
   dotnet build
   ```
2. Run the application:
   ```sh
   dotnet run
   ```

## API Endpoints

### Company Management

- **Create Company**
  - `POST /Company/CreateCompany`
  - Creates a new company.
  - Parameters: `CreateCompanyDTO companyCreate`

- **Edit Company**
  - `PUT /Company/EditCompany/{companyId}`
  - Edits the details of an existing company.
  - Parameters: `EditCompanyDTOS companyInfos`

- **Get Company Details**
  - `GET /Company/CompanyDetails/{companyId}`
  - Retrieves details about a specific company.
  - Parameters: `int companyID`

- **List Expenses in Company**
  - `GET /Company/ListExpenseInCompany/{companyId}`
  - Lists expenses in a specific company.
  - Parameters: `int companyId`

- **List All in Company**
  - `GET /Company/ListAllInCompany/{companyId}`
  - Lists all entities in a specific company.
  - Parameters: `int companyId`

- **Delete Company**
  - `DELETE /Company/DeleteCompany/{companyId}`
  - Deletes a specific company.
  - Parameters: `int companyId`

### Branch Management

- **Create Branch**
  - `POST /Branchs/CreateFilial`
  - Creates a new branch.
  - Parameters: `CreateBranchDto branchInfos`

- **Edit Branch**
  - `PUT /Branchs/EditFilial`
  - Edits the details of an existing branch.
  - Parameters: `EditBranchDto branchInfos`

- **Get Branch Details**
  - `GET /Branchs/FilialDetails`
  - Retrieves details about a specific branch.
  - Parameters: `int branchID`

- **List All Branches in Company**
  - `GET /Branchs/AllBranchs`
  - Lists all branches in a specific company.
  - Parameters: `int companyID`

- **List All Expenses in Branch**
  - `GET /Branchs/AllExpense`
  - Lists all expenses in a specific branch.
  - Parameters: `int branchid`

- **Delete Branch**
  - `DELETE /Branchs/DeleteFilial/{branchID}`
  - Deletes a specific branch.
  - Parameters: `int branchID`

### Area Management

- **Create Area**
  - `POST /Areas/CreateArea`
  - Creates a new area.
  - Parameters: `CreateAreaDto areaDto`

- **Edit Area**
  - `PUT /Areas/EditArea/{id}`
  - Edits the details of an existing area.
  - Parameters: `EditAreaDto areaDto`

- **Get Area Details**
  - `GET /Areas/AreaDetails`
  - Retrieves details about a specific area.
  - Parameters: `int id`

- **List All Areas**
  - `GET /Areas/AllAreas`
  - Lists all areas.
  - Parameters: `None`

- **List All Areas in Company**
  - `GET /Areas/AllAreasInCompany`
  - Lists all areas in a specific company.
  - Parameters: `int company`

- **List All Areas in Branch**
  - `GET /Areas/AllAreasInBranch`
  - Lists all areas in a specific branch.
  - Parameters: `int branch`

- **List All Expenses in Area**
  - `GET /Areas/AllExpenseInArea`
  - Lists all expenses in a specific area.
  - Parameters: `int areaId`

- **Delete Area**
  - `DELETE /Areas/DeleteArea/{id}`
  - Deletes a specific area.
  - Parameters: `int id`

### Employee Management

- **Create Employee**
  - `POST /Employees/CreateEmployee`
  - Creates a new employee.
  - Parameters: `CreateEmployeeDto employeeDto`

- **Edit Employee**
  - `PUT /Employees/EditEmployee`
  - Edits the details of an existing employee.
  - Parameters: `EditEmployee employeeDto`

- **Get Employee Details**
  - `GET /Employees/DetailsEmployee/{employeeId:int}`
  - Retrieves details about a specific employee.
  - Parameters: `int employeeId`

- **Get Employee**
  - `GET /Employees/GetEmployee/{employeeId:int}`
  - Retrieves a specific employee.
  - Parameters: `int employeeId`

- **List All Employees**
  - `GET /Employees/AllEmployees`
  - Lists all employees.
  - Parameters: `None`

- **List All Employees in Company**
  - `GET /Employees/AllEmployeesInCompany/{companyId:int}`
  - Lists all employees in a specific company.
  - Parameters: `int companyId`

- **List All Employees in Branch**
  - `GET /Employees/AllEmployeesInBranch/{branchId:int}`
  - Lists all employees in a specific branch.
  - Parameters: `int branchId`

- **List All Employees in Area**
  - `GET /Employees/AllEmployeesInArea/{areaId:int}`
  - Lists all employees in a specific area.
  - Parameters: `int areaId`

- **List All Employee Expenses in Area**
  - `GET /Employees/AllEmployeesExpenseInArea/{areaId:int}`
  - Lists all employee expenses in a specific area.
  - Parameters: `int areaId`

- **List All Employee Expenses in Branch**
  - `GET /Employees/AllEmployeesExpenseInBranch/{branchId:int}`
  - Lists all employee expenses in a specific branch.
  - Parameters: `int branchId`

- **Delete Employee**
  - `DELETE /Employees/DeleteEmployee/{employeeId:int}`
  - Deletes a specific employee.
  - Parameters: `int employeeid`

### Equipment Management

- **Create Equipment**
  - `POST /Equipments/CreateEquipment`
  - Creates a new equipment.
  - Parameters: `CreateEquipmentDto createEquipment`

- **Edit Equipment**
  - `PUT /Equipments/{id}`
  - Edits the details of an existing equipment.
  - Parameters: `EditEquipmentDto editEquipment`

- **Get Equipment**
  - `GET /Equipments/{id}`
  - Retrieves a specific equipment.
  - Parameters: `int id`

- **List All Equipment Expenses in Area**
  - `GET /Equipments/AllEquipmentExpenseInArea`
  - Lists all equipment expenses in a specific area.
  - Parameters: `int areaId`

- **List All Equipment Expenses in Branch**
  - `GET /Equipments/AllEquipmentExpenseInBranch`
  - Lists all equipment expenses in a specific branch.
  - Parameters: `int branchId`

- **List All Equipments**
  - `GET /Equipments/AllEquipments`
  - Lists all equipments.
  - Parameters: `None`

- **Delete Equipment**
  - `DELETE /Equipments/Equipment{id}`
  - Deletes a specific equipment.
  - Parameters: `int id`

For more details, you can view the source files for each controller:
- [BranchsController](https://github.com/JonathanQuaint/COMPANY-API-ASP-NET/blob/26002a5d687683399387146545b5c315b5fbab36/CompanyAPI/CompanyAPI/Controllers/BranchsController.cs)
- [EmployeesController](https://github.com/JonathanQuaint/COMPANY-API-ASP-NET/blob/26002a5d687683399387146545b5c315b5fbab36/CompanyAPI/CompanyAPI/Controllers/EmployeesController.cs)
- [AreasController](https://github.com/JonathanQuaint/COMPANY-API-ASP-NET/blob/26002a5d687683399387146545b5c315b5fbab36/CompanyAPI/CompanyAPI/Controllers/AreasController.cs)
- [EquipmentsController](https://github.com/JonathanQuaint/COMPANY-API-ASP-NET/blob/26002a5d687683399387146545b5c315b5fbab36/CompanyAPI/CompanyAPI/Controllers/EquipmentsController.cs)
