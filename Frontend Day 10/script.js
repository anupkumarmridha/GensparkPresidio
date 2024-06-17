document.addEventListener('DOMContentLoaded', () => {
    const productList = document.getElementById('product-list');

    // Fetch products from the API
    fetch('https://dummyjson.com/products')
        .then(response => response.json())
        .then(data => {
            const products = data.products;
            products.forEach(product => {
                // Create product card
                const productCard = document.createElement('div');
                productCard.className = 'product-card';

                // Product image
                const img = document.createElement('img');
                img.src = product.thumbnail || 'default.jpg';
                productCard.appendChild(img);

                // Product title
                const title = document.createElement('h2');
                title.textContent = product.title;
                productCard.appendChild(title);

                // Product description
                const description = document.createElement('p');
                description.textContent = product.description;
                productCard.appendChild(description);

                // Calculate original price
                const originalPrice = (product.price / (1 - product.discountPercentage / 100)).toFixed(2);

                // Product original price
                const originalPriceElem = document.createElement('div');
                originalPriceElem.className = 'original-price';
                originalPriceElem.textContent = `Original Price: $${originalPrice}`;
                productCard.appendChild(originalPriceElem);

                // Product price
                const price = document.createElement('div');
                price.className = 'price';
                price.textContent = `Discounted Price: $${product.price.toFixed(2)}`;
                productCard.appendChild(price);

                // Product discount percentage
                const discount = document.createElement('div');
                discount.className = 'discount-percentage';
                discount.textContent = `Discount: ${product.discountPercentage}%`;
                productCard.appendChild(discount);
 
                  // Product rating
                  const rating = document.createElement('div');
                  rating.className = 'rating';
                  rating.textContent = `Rating: ${product.rating}`;
                  if (product.rating >= 4.5) {
                      rating.classList.add('high');
                  } else if (product.rating >= 3.5) {
                      rating.classList.add('medium');
                  } else {
                      rating.classList.add('low');
                  }
                  productCard.appendChild(rating);
 
                 // Product stock status
                 const stock = document.createElement('div');
                 stock.className = 'stock';
                 stock.textContent = `${product.availabilityStatus} - ${product.stock}`;
                 if (product.availabilityStatus === 'Low Stock') {
                     stock.classList.add('low-stock');
                 }
                 productCard.appendChild(stock);

                // Product reviews summary
                const reviewsSummary = document.createElement('div');
                reviewsSummary.className = 'reviews-summary';
                // const averageRating = product.reviews.reduce((acc, review) => acc + review.rating, 0) / product.reviews.length;
                // reviewsSummary.textContent = `Reviews: ${product.reviews.length} (Avg. Rating: ${averageRating.toFixed(2)})`;
                reviewsSummary.textContent = `Reviews: ${product.reviews.length}`;
                productCard.appendChild(reviewsSummary);


                // Product details
                const details = document.createElement('div');
                details.className = 'details';
                productCard.appendChild(details);

                // Product brand
                const brand = document.createElement('div');
                brand.textContent = `Brand: ${product.brand}`;
                details.appendChild(brand);

                // Product SKU
                const sku = document.createElement('div');
                sku.textContent = `SKU: ${product.sku}`;
                details.appendChild(sku);

                // Product weight
                const weight = document.createElement('div');
                weight.textContent = `Weight: ${product.weight}g`;
                details.appendChild(weight);

                // Product dimensions
                const dimensions = document.createElement('div');
                dimensions.textContent = `Dimensions: ${product.dimensions.width}x${product.dimensions.height}x${product.dimensions.depth} cm`;
                details.appendChild(dimensions);

                // Product warranty
                const warranty = document.createElement('div');
                warranty.textContent = `Warranty: ${product.warrantyInformation}`;
                details.appendChild(warranty);

                // Product shipping information
                const shipping = document.createElement('div');
                shipping.textContent = `Shipping: ${product.shippingInformation}`;
                details.appendChild(shipping);

                // Append product card to product list
                productList.appendChild(productCard);
            });
        })
        .catch(error => console.error('Error fetching products:', error));
});
