$(document).ready(function () {
    const productList = $('#product-list');
    const searchBar = $('#search-bar');
    const categoryFilter = $('#category-filter');
    const ratingFilter = $('#rating-filter');

    let products = [];

    
    const fetchTemplate = async (url) => {
        try {
            const response = await fetch(url);
            return await response.text();
        } catch (error) {
            console.error('Error fetching template:', error);
            return '';
        }
    };
    
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

     const displayProducts = async (productArray) => {
        const template = await fetchTemplate('ProductCard.html');
        productList.empty();
        productArray.forEach(product => {
            const productCard = template
                .replace(/{thumbnail}/g, product.thumbnail || 'default.jpg')
                .replace(/{title}/g, product.title)
                .replace(/{description}/g, product.description)
                .replace(/{brand}/g, product.brand)
                .replace(/{sku}/g, product.sku)
                .replace(/{weight}/g, product.weight)
                .replace(/{dimensions}/g, `${product.dimensions.width}x${product.dimensions.height}x${product.dimensions.depth} cm`)
                .replace(/{warrantyInformation}/g, product.warrantyInformation)
                .replace(/{shippingInformation}/g, product.shippingInformation)
                .replace(/{price}/g, product.price.toFixed(2))
                .replace(/{discountPercentage}/g, product.discountPercentage)
                .replace(/{ratingClass}/g, getRatingClass(product.rating))
                .replace(/{rating}/g, product.rating)
                .replace(/{stockClass}/g, product.availabilityStatus === 'Low Stock' ? 'low-stock' : '')
                .replace(/{availabilityStatus}/g, product.availabilityStatus)
                .replace(/{reviewsCount}/g, product.reviews.length)
                .replace(/{averageRating}/g, calculateAverageRating(product.reviews))
                .replace(/{id}/g, product.id);

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

