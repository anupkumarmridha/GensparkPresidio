use NorthWind;

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

select * from Suppliers
--select product names from the supplier Tokyo Traders
select ProductName from products where SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')
--get all the products that are supplied by suppliers from USA
select ProductName from products where SupplierID in 
(select SupplierID from Suppliers where Country = 'USA')

select * from Products
select * from Categories
--get all the products from the category that has 'ea' in the description
select ProductName from products where SupplierID in 
(select categoryID from categories where description like '%ea%')

select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')
and SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

select * from Customers
select * from [Order Details]
select * from Orders

select * from customers
--select the product id and the quantity ordered by customrs from France
select ProductID, Quantity from [Order Details] where OrderID IN 
(select OrderID from Orders
    where CustomerID IN (
        select CustomerID
        from Customers
        where Country = 'France'
    )
);
--Get the products that are priced above the average price of all the products
select ProductID, ProductName, UnitPrice
from Products where 
UnitPrice>(select AVG(UnitPrice) from Products)


--Select the lastet order by every employee
--select * from Orders where orderdate in 
--(select distinct Max(OrderDate) from orders group by Employeeid)
select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

--Or
select OrderID, EmployeeID, OrderDate
from Orders o 
where OrderDate=(select MAX(OrderDate) 
from Orders where EmployeeID = o.EmployeeID);

--Select the maximum priced product in every category
select * from Products p1
where UnitPrice = (select max(UnitPrice) 
from Products p2 where p1.CategoryID=p2.CategoryID)

select * from orders

--select the order number for the maximum fright paid by every customer
select OrderID, Freight from Orders o1
where Freight = (select MAX(Freight) 
from Orders o2 where o1.CustomerID=o2.CustomerID) order by o1.CustomerID

--cross join
select * from Categories, Customers
--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and the productname
select CategoryId,ProductName from products

--Get the categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

select * from Categories

select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

select categoryName,ProductName from Categories, Products 
where Categories.CategoryID = Products.CategoryID

--Get the Supplier company name, contact person name, Product name and the stock ordered
select companyname,ContactName,ProductName,UnitsOnOrder
 from Suppliers s join Products p
 on s.SupplierID = p.SupplierID
 order by UnitsOnOrder desc

--Get the Supplier company name, contact person name, Product name and the stock ordered

select s.CompanyName "Supplier Company Name", s.ContactName "Supplier Contact Person", p.ProductName "product name", od.Quantity "Stock Ordered"
from Suppliers s, Products p, [Order Details] od, Orders o
where p.SupplierID = s.SupplierID and p.ProductID = od.ProductID and od.OrderID = o.OrderID;

select * from Customers;
--Print the order id, customername and the fright cost for all teh orders
select  o.OrderID, c.CustomerID,c.ContactName, o.Freight
from Orders o join Customers c 
on o.CustomerID = c.CustomerID
order by o.Freight desc;

 --product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID

 --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)

select c.ContactName, p.ProductName, od.Quantity "Quantity Sold", o.Freight, (od.UnitPrice * od.Quantity + o.Freight) "Total Price"
from Orders o join  Customers c on o.CustomerID = c.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID
order by o.OrderID;


 --Print the product name and the total quantity sold
 select productName,sum(quantity) "Total quantity sold"
 from products p join [Order Details] od
 on p.ProductID = od.ProductID
 group by ProductName
 order by 2 desc

 --select customername and number of products bought every year
select c.ContactName, o.OrderId, count(*) as "No. of Products per Order"
from customers c join orders o on c.customerid = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
group by c.ContactName,o.OrderID

--Select the empoyee name, Customer name, product name and the total price of teh product
select concat(e.FirstName,' ',e.LastName) Employee_name,
c.ContactName Customer_name, p.ProductName, (od.Quantity * p.UnitPrice) 'Total Price' 
from
Employees e join Orders o on e.EmployeeID = o.EmployeeID 
join Customers c on c.CustomerId = o.CustomerId 
join [Order Details] od on od.OrderId = o.OrderId
join Products p on p.ProductId = od.ProductId