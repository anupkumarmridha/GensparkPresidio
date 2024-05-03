use pubs;
select * from sales
select * from titles
select * from authors
select * from stores
select * from publishers
select * from pub_info
select * from titleauthor
select * from employee
-- 1) Print the storeid and number of orders for the store
select stor_id, count(*) "order count"
from sales 
group by stor_id;

-- 2) print the numebr of orders for every title
select t.title, count(*) "order count"
from sales s
join titles t on s.title_id = t.title_id
group by t.title;

select * from publishers
-- 3) print the publisher name and book name
select p.pub_name, t.title
from publishers p
join titles t on p.pub_id = t.pub_id;

select * from authors
-- 4) Print the author full name for al the authors
select CONCAT(au_fname, au_lname) "Full Name" from authors

-- 5) Print the price or every book with tax (price+price*12.36/100)
select title, price, price + (price * 12.36 / 100) "price with tax"
from titles;

-- 6) Print the author name, title name
select CONCAT(a.au_fname, ' ', a.au_lname) "author name", t.title
from authors a
join titleauthor ta on a.au_id = ta.au_id
join titles t on ta.title_id = t.title_id;

-- 7) print the author name, title name and the publisher name
select CONCAT(a.au_fname, ' ', a.au_lname) "author name", 
       t.title "title name",
       p.pub_name "publisher name"
from authors a
join titleauthor ta on a.au_id = ta.au_id
join titles t on ta.title_id = t.title_id
join publishers p on t.pub_id = p.pub_id;

-- 8) Print the average price of books pulished by every publicher
select p.pub_name "publisher name", AVG(t.price) "average price"
from titles t
join publishers p on t.pub_id = p.pub_id
group by p.pub_name;

-- 9) print the books published by 'Marjorie'
select t.title
from titles t
join publishers p on t.pub_id = p.pub_id
where p.pub_name = 'Marjorie';

-- 10) Print the order numbers of books published by 'New Moon Books'
select s.ord_num
from sales s
join titles t on s.title_id = s.title_id
join publishers p on t.pub_id = p.pub_id
where p.pub_name = 'New Moon Books';

-- 11) Print the number of orders for every publisher
select p.pub_name "publisher name", COUNT(s.ord_num) "order count"
from sales s
join titles t on s.title_id = t.title_id
join publishers p on t.pub_id = p.pub_id
group by p.pub_name;

-- 12) print the order number , book name, quantity, price and the total price for all orders
select s.ord_num, t.title "book name", s.qty, t.price, (s.qty * t.price) "total price"
from sales s JOIN titles t on s.title_id = t.title_id;

-- 13) print the total order quantity for every book
select t.title "book name", SUM(s.qty) "total order quantity"
from sales s 
join titles t on s.title_id = t.title_id
group by t.title;

-- 14) print the total ordervalue for every book
select t.title "book name", SUM(s.qty * t.price) "total order value"
from sales s 
join titles t on s.title_id = t.title_id
group by t.title;
-- 15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select s.*
from sales s
join titles t ON s.title_id = t.title_id
join pub_info pi ON t.pub_id = pi.pub_id
join employee e ON pi.pub_id = e.pub_id
where e.fname = 'Paolo';