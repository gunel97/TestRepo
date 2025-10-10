
const wishlistCount = document.getElementById('wishlistCount');

function loadWishlist() {
    console.log("loadwishlist");
    
    fetch('/wishlist/getwishlistj', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            if (data == null) {
                return;
            }
            else {
                data.items.forEach(
                    item => {

                        console.log("wishlist item product id");
                        console.log(item.product.id);

                        const productWishlistIcon = document.getElementById(`productWishlistIcon${item.product.id}`);

                        if (item.product.isInWishlist) {
                                productWishlistIcon.innerHTML = `
                        <span onclick="removeFromWishlistHome(${item.product.id})" class="icon icon-delete"></span>
                        <span class="tooltip">Remove from Wishlist</span>
                        `;
                            
                        }
                    }
                )
            }
            
            wishlistCount.innerText =data.count ;
        });
}

function loadWishlistIcon() {
    console.log("loadwishlistIcon");

    fetch('/wishlist/getwishlistj', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            if (data == null) {
                return;
            }

            wishlistCount.innerText = data.count;
        });
}

function loadWishlistShopList() {
    console.log("loadwishlist");

    fetch('/wishlist/getwishlistj', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            if (data == null) {
                return;
            }
            else {
                data.items.forEach(
                    item => {

                        console.log("wishlist item product id");
                        console.log(item.product.id);
                        const productWishlistIconShopList = document.getElementById(`productWishlistIconShopList${item.product.id}`);

                        if (item.product.isInWishlist) {
                            productWishlistIconShopList.innerHTML = `
                        <span onclick="removeFromWishlistHome(${item.product.id})" class="icon icon-delete"></span>
                        <span class="tooltip">Remove from Wishlist</span>
                        `;
                        }
                    }
                )
            }

            wishlistCount.innerText = data.count;
        });
}

function removeFromWishlistHome(id) {
    console.log("a");
    fetch(`/wishlist/remove/${id}`, {
        method: 'POST'
    })
        .then(response => {
            if (response.ok) {
                console.log("remove wishlist home ok");
                loadWishlist();

              
                    const productWishlistIcon = document.getElementById(`productWishlistIcon${id}`);

                    productWishlistIcon.innerHTML = `
                    <span onclick="addToWishlist(${id})" class="icon icon-heart"></span>
                    <span class="tooltip">Add to Wishlist</span>`;
                
                loadWishlist();
            }
            else {
                alert('Failed to remove from wishlist');
            }
        }).
        catch(error => {
            console.error('Error:', error);
            alert('An error occured');
        });
}

function deleteItemFromWishlistPages(id, element) {
    fetch(`/wishlist/remove/${id}`, {
        method: 'POST'
    })
        .then(response => {
            if (response.ok) {
                element.parentNode.parentNode.parentNode.remove();
                loadWishlistIcon();
            }
            else {
                alert('Failed to remove from wishlist');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occured');
        });
}

document.addEventListener('DOMContentLoaded', function () {

    const currentPath = window.location.pathname.toLowerCase();

    if (!currentPath.includes('/home/index') && !currentPath.includes('/shop/index')) {
        loadWishlistIcon();
    }
    else {
        loadWishlist();
    }
});

function addToWishlist(productId) {
    console.log("addtowishlist");
    console.log(productId);
    fetch(`/wishlist/add/${productId}`, {
        method: 'POST'
    })
    .then(response=>{
        if(response.ok){
            console.log("ok-add wishlist");
            loadWishlist();
        }
        else
        {
            alert('Failed');
        }
    })
    .catch(error=>{
        console.error('Error:', error);
        alert('An error occured');
    });
}