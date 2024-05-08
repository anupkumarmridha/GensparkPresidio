--1) Create a stored procedure that will take the author firstname and print all the books polished by him 
--with the publisher's name
 
 select * from authors
 create procedure GetBooksByAuthor
    @AuthorFirstName varchar(50)
as
begin
    select t.title as book_title, p.pub_name as publisher_name
    from titles t
    join titleauthor ta on t.title_id = ta.title_id
    join authors a on ta.au_id = a.au_id
    join publishers p on t.pub_id = p.pub_id
    where a.au_fname = @AuthorFirstName;
end;

exec GetBooksByAuthor 'Ann'
drop procedure GetBooksByAuthor

--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
select * from employee
select * from sales
select * from titles
select * from jobs
select * from publishers

 create procedure get_titles_sold_by_employee
    @employee_firstname varchar(50)
as
begin
    select t.title 'Book Name',sum(t.price) 'Price',sum(s.qty) 'Quantity', sum(t.price*s.qty) 'Cost'
	 from titles as t 
	 join employee as e on e.pub_id=t.pub_id
	 join sales as s on t.title_id=s.title_id
	 where e.fname=@employee_firstname group by t.title
end;

get_titles_sold_by_employee 'Victoria';

drop procedure get_titles_sold_by_employee
--3) Create a query that will print all names from authors and employees
select au_fname as name from authors
union
select fname as name from employee;
 
--4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name,
-- Publisher's name, author's full name with quantity ordered and price for the order for all orders, 
-- print first 5 orders after sorting them based on the price of order

 
select top 5 t.title as BookTitle, p.pub_name, CONCAT(a.au_fname, ' ', a.au_lname) as AuthorName,
SUM(s.qty) as "Quantity Ordered", SUM(t.Price * s.qty) as OrderTotalPrice
from sales s 
join titles t on s.title_id = t.title_id 
join publishers p on t.pub_id = p.pub_id
join titleauthor ta on t.title_id = ta.title_id
join authors a on ta.au_id = a.au_id
group by t.title, p.pub_name, CONCAT(a.au_fname, ' ', a.au_lname)
order by OrderTotalPrice desc;

