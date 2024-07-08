### Auth Microservice Design

#### Classes and their attributes/methods

1. **User**
   - **Attributes**:
     - `userId: String`: Unique identifier for the user.
     - `username: String`: Username for the user.
     - `role: String`: Role of the user (Admin, BankEmployee, Customer).
     - `isActiveUser: boolean`: Indicates if the user is active. For Soft Delete.
  
   - **Methods**:
     - `setUsername(username: String): void`: Sets the username.
     - `getUsername(): String`: Gets the username.
     - `setRole(role: String): void`: Sets the role.
     - `setIsActiveUser(isActiveUser: boolean): void`: Sets the active status.
     - `getIsActiveUser(): boolean`: Gets the active status.
     - `getRole(): String`: Gets the role.

2. **Password**
   - **Attributes**:

     - `userId: String`: Primary Key (Foreign key to the User).
     - `passwordHash: String`: Hashed password.
   - **Methods**:
     - `setPasswordHash(passwordHash: String): void`: Sets the hashed password.
     - `getPasswordHash(): String`: Gets the hashed password.
     - `matchPassword(password: String): boolean`: Matches the provided password with the stored hash.

#### Layer-wise Interfaces and Methods

##### Controller Layer

**AuthController**
- **Endpoints**:
  - `POST /auth/register`: Registers a new user.
  - `POST /auth/login`: Authenticates a user.
  - `PUT /auth/change-password`: Changes the user's password.
- **Methods**:
  - `registerUser(userDTO: UserDTO, passwordDTO: PasswordDTO): ResponseEntity`
  - `login(credentialsDTO: CredentialsDTO): ResponseEntity`
  - `changePassword(userId: String, passwordDTO: PasswordDTO): ResponseEntity`

**AdminController**
- **Endpoints**:
  - `POST /admin/users`: Creates a new user (BankEmployee or Customer).
  - `PUT /admin/users/{userId}`: Updates an existing user.
  - `PUT /admin/users/{userId}`: Soft Deletes a user.
  - `GET /admin/users/{userId}`: Retrieves a user by ID.
  - `GET /admin/users`: Retrieves all users.
- **Methods**:
  - `createUser(userDTO: UserDTO): ResponseEntity`
  - `updateUser(userId: String, userDTO: UserDTO): ResponseEntity`
  - `deleteUser(userId: String): ResponseEntity`
  - `getUser(userId: String): ResponseEntity`
  - `getAllUsers(): ResponseEntity`

**BankEmployeeController**
- **Endpoints**:
  - `POST /employee/customers`: Creates a new customer.
  - `PUT /employee/customers/{userId}`: Updates an existing customer.
  - `PUT /employee/customers/{userId}`: Soft Deletes a customer.
  - `GET /employee/customers/{userId}`: Retrieves a customer by ID.
  - `GET /employee/customers`: Retrieves all customers.
  - `POST /employee/accounts`: Creates a new account.
- **Methods**:
  - `createCustomer(userDTO: UserDTO): ResponseEntity`
  - `updateCustomer(userId: String, userDTO: UserDTO): ResponseEntity`
  - `deleteCustomer(userId: String): ResponseEntity`
  - `getCustomer(userId: String): ResponseEntity`
  - `getAllCustomers(): ResponseEntity`
  - `createAccount(accountDTO: AccountDTO): ResponseEntity`

##### Service Layer

**AuthService**
- **Methods**:
  - `registerUser(userDTO: UserDTO, passwordDTO: PasswordDTO): User`: Registers a new user.
  - `login(credentialsDTO: CredentialsDTO): User`: Authenticates a user.
  - `changePassword(userId: String, passwordDTO: PasswordDTO): User`: Changes the user's password.

**AdminService**
- **Methods**:
  - `createUser(userDTO: UserDTO): User`: Creates a new user (BankEmployee or Customer).
  - `updateUser(userId: String, userDTO: UserDTO): User`: Updates an existing user.
  - `deleteUser(userId: String): void`: Soft Deletes a user.
  - `getUser(userId: String): User`: Retrieves a user by ID.
  - `getAllUsers(): List<User>`: Retrieves all users.

**BankEmployeeService**
- **Methods**:
  - `createCustomer(userDTO: UserDTO): User`: Creates a new customer.
  - `updateCustomer(userId: String, userDTO: UserDTO): User`: Updates an existing customer.
  - `deleteCustomer(userId: String): void`: Soft a customer.
  - `getCustomer(userId: String): User`: Retrieves a customer by ID.
  - `getAllCustomers(): List<User>`: Retrieves all customers.
  - `createAccount(accountDTO: AccountDTO): Account`: Creates a new account.

**DTOs (Data Transfer Objects)**

1. **UserDTO**
   - **Attributes**:
     - `userId: String`: Unique identifier for the user.
     - `username: String`: Username for the user.
     - `role: String`: Role of the user (Admin, BankEmployee, Customer).

2. **PasswordDTO**
   - **Attributes**:
     - `userId: String`: Primary Key (Foreign key to the User.)
     - `passwordHash: String`: Hashed password.

3. **CredentialsDTO**
   - **Attributes**:
     - `username: String`: Username for the user.
     - `password: String`: Password for the user.

4. **AccountDTO**
   - **Attributes**:
     - `accountId: String`: Unique identifier for the account.
     - `balance: double`: Current balance of the account.
     - `accountHolder: String`: Name of the account holder.
     - `typeOfAccount: String`: Type of the account (e.g., Savings, Checking).


**Endpoints and Corresponding DTOs**

1. **Register User Endpoint**
   - **URL**: `POST /auth/register`
   - **Request Body**: `UserDTO`, `PasswordDTO`
   - **Response Body**: `UserDTO`

2. **Login Endpoint**
   - **URL**: `POST /auth/login`
   - **Request Body**: `CredentialsDTO`
   - **Response Body**: `UserDTO`

3. **Change Password Endpoint**
   - **URL**: `PUT /auth/change-password`
   - **Request Body**: `PasswordDTO`
   - **Response Body**: `UserDTO`

4. **Create User Endpoint (Admin)**
   - **URL**: `POST /admin/users`
   - **Request Body**: `UserDTO`
   - **Response Body**: `UserDTO`

5. **Update User Endpoint (Admin)**
   - **URL**: `PUT /admin/users/{userId}`
   - **Request Body**: `UserDTO`
   - **Response Body**: `UserDTO`

6. **Delete User Endpoint (Admin)**
   - **URL**: `PUT /admin/users/{userId}`
   - **Response Body**: `void`

7. **Get User Endpoint (Admin)**
   - **URL**: `GET /admin/users/{userId}`
   - **Response Body**: `UserDTO`

8. **Get All Users Endpoint (Admin)**
   - **URL**: `GET /admin/users`
   - **Response Body**: `List<UserDTO>`

9. **Get All Users Endpoint (Admin)**
   - **URL**: `GET /admin/users`
   - **Response Body**: List of `UserDTO`

10. **Create Customer Endpoint (Bank Employee)**
    - **URL**: `POST /employee/customers`
    - **Request Body**: `UserDTO`
    - **Response Body**: `UserDTO`

11. **Update Customer Endpoint (Bank Employee)**
    - **URL**: `PUT /employee/customers/{userId}`
    - **Request Body**: `UserDTO`
    - **Response Body**: `UserDTO`

12. **Delete Customer Endpoint (Bank Employee)**
    - **URL**: `PUT /employee/customers/{userId}`
    - **Response Body**: `void`

13. **Get Customer Endpoint (Bank Employee)**
    - **URL**: `GET /employee/customers/{userId}`
    - **Response Body**: `UserDTO`

14. **Get All Customers Endpoint (Bank Employee)**
    - **URL**: `GET /employee/customers`
    - **Response Body**: List of `UserDTO`

15. **Create Account Endpoint (Bank Employee)**
    - **URL**: `POST /employee/accounts`
    - **Request Body**: `AccountDTO`
    - **Response Body**: `AccountDTO`

### Generic Process Flow for Auth Microservice

#### 1. User Registration

```plaintext
Actor -> Auth Service: registerUser(userDTO, passwordDTO)
Auth Service -> User Repository: save user details
Auth Service -> Password Repository: save hashed password
User Repository -> Auth Service: user saved confirmation
Password Repository -> Auth Service: password saved confirmation
Auth Service -> Actor: registration success response
```

#### 2. User Login

```plaintext
Actor -> Auth Service: login(credentialsDTO)
Auth Service -> User Repository: find user by username
User Repository -> Auth Service: user found
Auth Service -> Password Repository: find password by userId
Password Repository -> Auth Service: password found
Auth Service -> Actor: login success response with UserDTO
```

#### 3. Change Password

```plaintext
Actor -> Auth Service: changePassword(userId, passwordDTO)
Auth Service -> Password Repository: update passwordHash for userId
Password Repository -> Auth Service: password updated confirmation
Auth Service -> Actor: password change success response
```

#### 4. CRUD Operations by Admin on Users

```plaintext
Actor -> Admin Service: createUser(userDTO)
Admin Service -> User Repository: save user details
User Repository -> Admin Service: user saved confirmation
Admin Service -> Actor: creation success response

Actor -> Admin Service: updateUser(userId, userDTO)
Admin Service -> User Repository: update user details
User Repository -> Admin Service: user updated confirmation
Admin Service -> Actor: update success response

Actor -> Admin Service: deleteUser(userId)
Admin Service -> User Repository: update user by userId set isActiveUser=false
User Repository -> Admin Service: user update confirmation
Admin Service -> Actor: deletion success response

Actor -> Admin Service: getUser(userId)
Admin Service -> User Repository: find user by userId
User Repository -> Admin Service: return user details
Admin Service -> Actor: user details response

Actor -> Admin Service: getAllUsers()
Admin Service -> User Repository: find all users
User Repository -> Admin Service: return list of users
Admin Service -> Actor: list of users response
```

#### 5. CRUD Operations by Bank Employee on Customers

```plaintext
Actor -> Bank Employee Service: createCustomer(userDTO)
Bank Employee Service -> User Repository: save customer details
User Repository -> Bank Employee Service: customer saved confirmation
Bank Employee Service -> Actor: customer creation success response

Actor -> Bank Employee Service: updateCustomer(userId, userDTO)
Bank Employee Service -> User Repository: update customer details
User Repository -> Bank Employee Service: customer updated confirmation
Bank Employee Service -> Actor: update success response

Actor -> Bank Employee Service: deleteCustomer(userId)
Bank Employee Service -> User Repository: update customer by userId set isActiveUser=false
User Repository -> Bank Employee Service: customer deleted confirmation
Bank Employee Service -> Actor: deletion success response

Actor -> Bank Employee Service: getCustomer(userId)
Bank Employee Service -> User Repository: find customer by userId
User Repository -> Bank Employee Service: return customer details
Bank Employee Service -> Actor: customer details response

Actor -> Bank Employee Service: getAllCustomers()
Bank Employee Service -> User Repository: find all customers
User Repository -> Bank Employee Service: return list of customers
Bank Employee Service -> Actor: list of customers response
```

#### 6. Create Account by Bank Employee

```plaintext
Actor -> Bank Employee Service: createAccount(accountDTO)
Bank Employee Service -> Account Repository: save account details
Account Repository -> Bank Employee Service: account saved confirmation
Bank Employee Service -> Actor: account creation success response
```

### <------------ End Auth Module Microservice Design---------->

<br>
<br>


### Transactions Module Microservice Design

#### Classes and their attributes/methods

1. **Account**
   - Attributes:
     - `accountId: String`: Unique identifier for the account.
     - `balance: double`: Current balance of the account.
     - `accountHolder: String`: Name of the account holder.
     - `typeOfAccount: String`: Type of the account (e.g., Savings, Checking).
   - Methods:
     - `deposit(amount: double): void`: Adds the specified amount to the account balance.
     - `withdraw(amount: double): void`: Subtracts the specified amount from the account balance if funds are sufficient.
     - `transfer(toAccount: Account, amount: double): void`: Transfers the specified amount to another account.
     - `validateFunds(amount: double): boolean`: Checks if the account has sufficient funds for a transaction.

2. **Customer**
   - Attributes:
     - `customerId: String`: Unique identifier for the customer.
     - `userId: String`: Foreign key to the associated user.
     - `name: String`: Name of the customer.
     - `accounts: List<Account>`: List of accounts associated with the customer.
   - Methods:
     - `initiateTransaction(transaction: Transaction): void`: Initiates a transaction for the customer.

3. **BankEmployee**
   - Attributes:
     - `employeeId: String`: Unique identifier for the bank employee.
     - `name: String`: Name of the bank employee.
     - `role: String`: Role of the bank employee (e.g., Teller, Manager).
   - Methods:
     - `approveTransaction(transaction: Transaction): void`: Approves a transaction initiated by a customer.
     - `validateRole(role: String): boolean`: Validates if the employee has the correct role for performing a specific action.

4. **Transaction**
   - Attributes:
     - `transactionId: String`: Unique identifier for the transaction.
     - `fromAccountId: String`: Identifier for the account involved in the transaction.
     - `toAccountId: String`: Identifier for the target account in case of a transfer.
     - `type: String`: Type of the transaction (Deposit, Withdrawal, Transfer).
     - `amount: double`: Amount involved in the transaction.
     - `status: String`: Status of the transaction (Pending, Completed, Failed).
     - `date: Date`: Date and time when the transaction was created.
   - Methods:
     - `validate(): boolean`: Validates the transaction details.
     - `process(): void`: Processes the transaction.
     - `record(): void`: Records the transaction in the system.
     - `confirm(): void`: Confirms the transaction to the customer.

5. **System (Web Interface, Bank Branch, Mobile Application)**
   - Attributes:
     - `systemId: String`: Unique identifier for the system.
     - `location: String`: Location or identifier for the system's physical or virtual presence.
   - Methods:
     - `initiateTransaction(transaction: Transaction): void`: Initiates a transaction through the system.

6. **ATM**
   - Attributes:
     - `atmId: String`: Unique identifier for the ATM.
     - `location: String`: Physical location of the ATM.
   - Methods:
     - `initiateTransaction(transaction: Transaction): void`: Initiates a transaction through the ATM.

### Layer-wise Interfaces and Methods

#### Controller Layer

**TransactionController**
- **Endpoints**:
  - `POST /transactions/deposit`: Endpoint for initiating a deposit transaction.
  - `POST /transactions/withdrawal`: Endpoint for initiating a withdrawal transaction.
  - `POST /transactions/transfer`: Endpoint for initiating a transfer transaction.
- **Methods**:
  - `initiateDeposit(transactionDTO: TransactionDTO): ResponseEntity`: Handles deposit requests.
  - `initiateWithdrawal(transactionDTO: TransactionDTO): ResponseEntity`: Handles withdrawal requests.
  - `initiateTransfer(transactionDTO: TransactionDTO): ResponseEntity`: Handles transfer requests.

**AccountController**
- **Endpoints**:
  - `GET /accounts/{accountId}`: Endpoint for retrieving account details.
  - `POST /accounts`: Endpoint for creating a new account.
- **Methods**:
  - `getAccountDetails(accountId: String): ResponseEntity`: Retrieves account details based on the account ID.
  - `createAccount(accountDTO: AccountDTO): ResponseEntity`: Creates a new account based on the provided account details.

#### Service Layer

**TransactionService**
- **Methods**:
  - `processDeposit(transactionDTO: TransactionDTO): Transaction`: Processes a deposit transaction.
  - `processWithdrawal(transactionDTO: TransactionDTO): Transaction`: Processes a withdrawal transaction.
  - `processTransfer(transactionDTO: TransactionDTO): Transaction`: Processes a transfer transaction.

**AccountService**
- **Methods**:
  - `getAccountDetails(accountId: String): Account`: Retrieves account details based on the account ID.

#### Repository Layer

### Common Base Repository for CRUD Operations

### Base Repository Interface

#### BaseRepository<T, ID>

**Methods**:
- `save(entity: T): T`: Saves an entity to the database.
  - **Description**: Persists the provided entity to the database and returns the saved entity, including any auto-generated fields.
  - **Parameters**: 
    - `entity: T`: The entity to be saved.
  - **Returns**: 
    - `T`: The saved entity.
- `findById(id: ID): Optional<T>`: Finds an entity by its ID.
  - **Description**: Retrieves an entity from the database based on its unique identifier.
  - **Parameters**: 
    - `id: ID`: The unique identifier of the entity.
  - **Returns**: 
    - `Optional<T>`: An optional containing the found entity or empty if no entity is found.
- `findAll(): List<T>`: Retrieves all entities.
  - **Description**: Fetches all entities of the specified type from the database.
  - **Returns**: 
    - `List<T>`: A list of all entities.
- `update(entity: T): T`: Updates an existing entity in the database.
  - **Description**: Updates the provided entity in the database and returns the updated entity.
  - **Parameters**: 
    - `entity: T`: The entity to be updated.
  - **Returns**: 
    - `T`: The updated entity.
- `deleteById(id: ID): void`: Deletes an entity by its ID.
  - **Description**: Removes the entity with the specified ID from the database.
  - **Parameters**: 
    - `id: ID`: The unique identifier of the entity to be deleted.
  - **Returns**: 
    - `void`: No return value.

### Specific Repositories Extending Base Repository

Each specific repository can extend the base repository to inherit common CRUD operations, adding any additional methods unique to the entity it manages.

#### TransactionRepository
**Extends BaseRepository<Transaction, String>**
- **Methods**:
  - Inherits all methods from `BaseRepository<ModelClass, String>`
  - Additional methods specific to `ModelClass` can be defined here.


### Example Usage

**TransactionRepository**
- `save(transaction: Transaction): Transaction`: Saves a transaction to the database.
- `findById(transactionId: String): Optional<Transaction>`: Finds a transaction by its ID.
- `findAll(): List<Transaction>`: Retrieves all transactions.
- `update(transaction: Transaction): Transaction`: Updates an existing transaction.

### Endpoints with DTOs

**DTOs (Data Transfer Objects)**

1. **TransactionDTO**
     - `type: String`: Type of the transaction (Deposit, Withdrawal, Transfer).
     - `amount: double`: Amount involved in the transaction.
     - `fromAccountId: String`: Identifier for the account involved in the transaction.
     - `toAccountId: String`: Identifier for the target account in case of a transfer.

2. **AccountDTO**
   - Attributes:
     - `accountId: String`: Unique identifier for the account.
     - `balance: double`: Current balance of the account.
     - `accountHolder: String`: Name of the account holder.
     - `typeOfAccount: String`: Type of the account (e.g., Savings, Checking).

**Endpoints and Corresponding DTOs**

1. **Deposit Endpoint**
   - **URL**: `POST /transactions/deposit`
   - **Request Body**: `TransactionDTO`
   - **Response Body**: `TransactionDTO`

2. **Withdrawal Endpoint**
   - **URL**: `POST /transactions/withdrawal`
   - **Request Body**: `TransactionDTO`
   - **Response Body**: `TransactionDTO`

3. **Transfer Endpoint**
   - **URL**: `POST /transactions/transfer`
   - **Request Body**: `TransactionDTO`
   - **Response Body**: `TransactionDTO`

4. **Get Account Details Endpoint**
   - **URL**: `GET /accounts/{accountId}`
   - **Response Body**: `AccountDTO`


### Generic Process Flow for Transactions Through All Channels

#### 1. Generic Deposit

```plaintext
Actor -> System: initiateTransaction(deposit)
System -> Account: validateFunds(amount)
Account -> System: validation result
System -> Account: deposit(amount)
Account -> System: update balance
System -> Actor: confirmation
```

#### 2. Generic Withdrawal

```plaintext
Actor -> System: initiateTransaction(withdrawal)
System -> Account: validateFunds(amount)
Account -> System: validation result
System -> Account: withdraw(amount)
Account -> System: update balance
System -> Actor: confirmation
```

#### 3. Generic Transfer

```plaintext
Actor -> System: initiateTransaction(transfer)
System -> Account: validateFunds(amount)
Account -> System: validation result
System -> Account: transfer(toAccount, amount)
Account -> toAccount: update balance
System -> Actor: confirmation
```

