# steps:

1. **Pull the PostgreSQL Docker Image and Run an Instance**
2. **Create a Database**
3. **Create Tables with Proper Relationships**
4. **Insert Data into Tables**
5. **Log off the Instance**
6. **Run the Instance Again**
7. **Execute a Select Query**

### Step 1: Pull the PostgreSQL Docker Image and Run an Instance
```sh
# Pull the latest PostgreSQL image
docker pull postgres:latest

# Run a PostgreSQL container
docker run --name postgres-instance -e POSTGRES_PASSWORD=mysecretpassword -d postgres
```

### Step 2: Create a Database
First, access the running PostgreSQL container:
```sh
docker exec -it postgres-instance psql -U postgres
```

Within the PostgreSQL prompt, create the database:
```sql
CREATE DATABASE dbDocker;
```

### Step 3: Create Tables with Proper Relationships
Switch to the `dbDocker` database:
```sh
\c dbDocker;
```
To see all databases:
```sh
\l;
```

Create the tables with relationships:
```sql
-- Create Department table
CREATE TABLE Department (
    department_id SERIAL PRIMARY KEY,
    department_name VARCHAR(100) NOT NULL
);

-- Create Employee table
CREATE TABLE Employee (
    employee_id SERIAL PRIMARY KEY,
    employee_name VARCHAR(100) NOT NULL,
    age INT NOT NULL,
    phone VARCHAR(15),
    department_id INT,
    FOREIGN KEY (department_id) REFERENCES Department(department_id)
);

-- Create Salary table
CREATE TABLE Salary (
    salary_id SERIAL PRIMARY KEY,
    employee_id INT,
    amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (employee_id) REFERENCES Employee(employee_id)
);
```

### Step 4: Insert Data into Tables
Insert data into the tables:
```sql
-- Insert data into Department table
INSERT INTO Department (department_name) VALUES ('HR'), ('Finance'), ('IT');

-- Insert data into Employee table
INSERT INTO Employee (employee_name, age, phone, department_id) 
VALUES 
('Alice', 30, '123-456-7890', 1),
('Bob', 40, '234-567-8901', 2),
('Charlie', 25, '345-678-9012', 3);

-- Insert data into Salary table
INSERT INTO Salary (employee_id, amount) VALUES (1, 50000.00), (2, 60000.00), (3, 55000.00);
```

### Step 5: Log off the Instance
Exit the PostgreSQL prompt:
```sh
\q
```
Stop the Docker container:
```sh
docker stop postgres-instance
```

### Step 6: Run the Instance Again
Start the Docker container:
```sh
docker start postgres-instance
```
Access the PostgreSQL container again:
```sh
docker exec -it postgres-instance psql -U postgres -d dbdocker
```

### Step 7: Execute a Select Query
Execute the select query to get the required details:
```sql
SELECT 
    e.employee_name, 
    e.age, 
    e.phone, 
    d.department_name, 
    s.amount AS salary
FROM 
    Employee e
JOIN 
    Department d ON e.department_id = d.department_id
JOIN 
    Salary s ON e.employee_id = s.employee_id;
```

This will print the employee name, age, phone, department name, and salary.