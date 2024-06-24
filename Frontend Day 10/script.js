$(document).ready(function () {
    const productList = $('#product-list');
    const searchBar = $('#search-bar');
    const categoryFilter = $('#category-filter');
    const ratingFilter = $('#rating-filter');

    let products = [];

    const fetchProducts = (url, callback) => {
        $.ajax({
            url: url,
            method: 'GET',
            success: function (data) {
                products = data.products;
                callback(products);
            },
            error: function (error) {
                console.error('Error fetching products:', error);
            }
        });
    };

    const fetchCategories = () => {
        $.ajax({
            url: 'https://dummyjson.com/products/categories',
            method: 'GET',
            success: function (data) {
                populateCategories(data);
            },
            error: function (error) {
                console.error('Error fetching categories:', error);
            }
        });
    };

    const populateCategories = (categories) => {
        categories.forEach(category => {
            const option = $(`<option value="${category}">${category}</option>`);
            categoryFilter.append(option);
        });
    };

    const displayProducts = (productArray) => {
        productList.empty();
        productArray.forEach(product => {
            const productCard = $(`
                <div class="product-card">
                    <img src="${product.thumbnail || 'default.jpg'}" alt="${product.title}">
                    <h2>${product.title}</h2>
                    <p>${product.description}</p>
                    <div class="details">
                        <div>Brand: ${product.brand}</div>
                        <div>SKU: ${product.sku}</div>
                        <div>Weight: ${product.weight}g</div>
                        <div>Dimensions: ${product.dimensions.width}x${product.dimensions.height}x${product.dimensions.depth} cm</div>
                        <div>Warranty: ${product.warrantyInformation}</div>
                        <div>Shipping: ${product.shippingInformation}</div>
                    </div>
                    <div class="original-price">Original Price: $${calculateOriginalPrice(product.price, product.discountPercentage)}</div>
                    <div class="price">Discounted Price: $${product.price.toFixed(2)}</div>
                    <div class="discount-percentage">Discount: ${product.discountPercentage}%</div>
                    <div class="rating ${getRatingClass(product.rating)}">Rating: ${product.rating}</div>
                    <div class="stock ${product.availabilityStatus === 'Low Stock' ? 'low-stock' : ''}">${product.availabilityStatus}</div>
                    <div class="reviews-summary">Reviews: ${product.reviews.length} (Avg. Rating: ${calculateAverageRating(product.reviews)})</div>
                    <div class="btn" data-product-id="${product.id}">Add to Cart</div>
                    <div class="btn" data-product-id="${product.id}">Buy Now</div>
                </div>
            `);
            productList.append(productCard);
        });

        $('.btn').on('click', function () {
            const productId = $(this).data('product-id');
            addToCart(productId, 1); // Assuming quantity is 1 for now
        });
    };

    const calculateOriginalPrice = (price, discountPercentage) => {
        return (price / (1 - discountPercentage / 100)).toFixed(2);
    };

    const getRatingClass = (rating) => {
        if (rating >= 4.5) return 'high';
        if (rating >= 3.5) return 'medium';
        return 'low';
    };

    const calculateAverageRating = (reviews) => {
        const totalRating = reviews.reduce((acc, review) => acc + review.rating, 0);
        return (totalRating / reviews.length).toFixed(2);
    };

    const filterProducts = () => {
        const searchQuery = searchBar.val().toLowerCase();
        const selectedCategory = categoryFilter.val();
        const selectedRating = ratingFilter.val();

        if (selectedCategory === 'all') {
            fetchProducts('https://dummyjson.com/products', () => applyFiltersAndSort(searchQuery, selectedRating));
        } else {
            fetchProducts(`https://dummyjson.com/products/category/${selectedCategory}`, () => applyFiltersAndSort(searchQuery, selectedRating));
        }
    };

    const applyFiltersAndSort = (searchQuery, selectedRating) => {
        let filteredProducts = products.filter(product => {
            const matchesSearch = product.title.toLowerCase().includes(searchQuery) || product.description.toLowerCase().includes(searchQuery);
            let matchesRating = true;
            if (selectedRating === 'high') {
                matchesRating = product.rating >= 4.5;
            } else if (selectedRating === 'medium') {
                matchesRating = product.rating >= 3.5 && product.rating < 4.5;
            } else if (selectedRating === 'low') {
                matchesRating = product.rating < 3.5;
            }

            return matchesSearch && matchesRating;
        });

        // Sort products by rating in descending order
        filteredProducts.sort((a, b) => b.rating - a.rating);

        displayProducts(filteredProducts);
    };
    const showToast = (message) => {
        const toast = document.getElementById("toast");
        toast.className = "toast show";
        toast.innerHTML = `<span class="close">&times;</span> ${message}`;

        setTimeout(function () {
            toast.className = toast.className.replace("show", "");
        }, 3000);

        const closeButton = document.querySelector('.toast .close');
        closeButton.onclick = function () {
            toast.style.visibility = 'hidden';
        };
    };
    const addToCart = (productId, quantity) => {
        fetch('https://dummyjson.com/carts/add', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                userId: 1,
                products: [
                    {
                        id: productId,
                        quantity: quantity,
                    }
                ]
            })
        })
        .then(res => res.json())
        .then(data => {
            console.log('Product added to cart:', data);
            showToast("Product added to cart");
        })
        .catch(error => {
            console.error('Error adding to cart:', error);
            alert('Failed to add product to cart');
        });
    };

    
    searchBar.on('input', filterProducts);
    categoryFilter.on('change', filterProducts);
    ratingFilter.on('change', filterProducts);

    fetchProducts('https://dummyjson.com/products', displayProducts);
    fetchCategories();
});

