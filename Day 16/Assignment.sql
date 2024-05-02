use pubs

SELECT * FROM titles

--1) Print all the titles names
 SELECT title "Title Names"
 FROM titles

--2) Print all the titles that have been published by 1389
SELECT title
FROM titles
WHERE pub_id = 1389;

--3) Print the books that have price in rangeof 10 to 15
SELECT *
FROM titles 
WHERE price BETWEEN 10 AND 15
 
--4) Print those books that have no price
SELECT * 
FROM titles 
WHERE price IS NULL;
 
--5) Print the book names that strat with 'The'
SELECT title
FROM titles
WHERE title LIKE 'The%';
 
--6) Print the book names that do not have 'v' in their name
SELECT title 
FROM titles
WHERE title NOT LIKE '%v%';

--7) print the books sorted by the royalty
SELECT * 
FROM titles
ORDER BY royalty;
 
--8) print the books sorted by publisher in descending then by types in asending then by price in descending
SELECT *
FROM titles
ORDER BY pub_id DESC, type ASC, price DESC;
 
--9) Print the average price of books in every type
 SELECT AVG(price) "average price", type 
 FROM titles
 GROUP BY type;

--10) print all the types in uniques
SELECT DISTINCT type
FROM titles;
 
--11) Print the first 2 costliest books
SELECT TOP 2 *
FROM titles
ORDER BY price DESC;

--OR 

SELECT *
FROM (
    SELECT *, RANK() OVER (ORDER BY price DESC) AS book_rank
    FROM titles
) AS ranked_books
WHERE book_rank <= 2;

--12) Print books that are of type business and have price less than 20 which also have advance greater than 7000
SELECT *
FROM titles
WHERE type = 'business'
AND price < 20
AND advance > 7000;
 
--13) Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. 
--	  Print only those which have count greater than 2. Also sort the result in ascending order of count
SELECT pub_id, COUNT(*) AS book_count
FROM titles
WHERE price BETWEEN 15 AND 25
AND title LIKE '%It%'
GROUP BY pub_id
HAVING COUNT(*) > 2
ORDER BY COUNT(*) ASC;

--14) Print the Authors who are from 'CA'
SELECT * FROM authors

SELECT *
FROM authors
WHERE state = 'CA';

--15) Print the count of authors from every state
SELECT state, COUNT(*) "NO OF AUTHORS" 
FROM authors
GROUP BY state