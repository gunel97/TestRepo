const basketTotalPrice = document.getElementById('basketTotalPrice');
const basketContainer = document.getElementById('basketContainer');
const basketTotalCountHeader = document.getElementById('basketTotalCountHeader');

function loadBasket() {
    fetch('/basket/getbasket', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            basketContainer.innerHTML = "";
            data.items.forEach(item => {
                basketContainer.innerHTML += `
                <div class="tf-mini-cart-item">
                                    <div class="tf-mini-cart-image">
                                        <a href="product-detail.html">
                                            <img src="/images/products/${item.imageName}" alt="">
                                        </a>
                                    </div>
                                    <div class="tf-mini-cart-info">
                                        <a class="title link" asp-controller="product" asp-action="details"->${item.productName}</a>
                                        <div class="meta-variant">${item.colorName}</div>
                                        <div class="price fw-6">$${item.price*item.quantity}</div>
                                        <div class="tf-mini-cart-btns">
                                            <div class="wg-quantity small">
                                                <span onclick="changeQuantity(${item.productVariantId}, -1)" class="btn-quantity minus-btn">-</span>
                                                <input  type="number" min="1" id="productVariantId${item.productVariantId}" name="number" value="${item.quantity}">
                                                <span onclick="changeQuantity(${item.productVariantId}, 1)" class="btn-quantity plus-btn">+</span>
                                            </div>
                                            <div onclick="removeFromBasket(${item.productVariantId}, this)" id="removeButtonBasket" class="tf-mini-cart-remove">Remove</div>
                                        </div>
                                    </div>
                                </div>`;
            });
            basketTotalCountHeader.innerText = data.totalCount;
            basketTotalPrice.innerText = "$"+ data.totalPrice;
        }).catch(error => {
            console.Error('Error:', error);
        });
}

function loadBasketWithData(data) {
    basketContainer.innerHTML = "";
    data.items.forEach(item => {
        basketContainer.innerHTML += `
                <div class="tf-mini-cart-item">
                                    <div class="tf-mini-cart-image">
                                        <a href="product-detail.html">
                                            <img src="/images/products/${item.imageName}" alt="">
                                        </a>
                                    </div>
                                    <div class="tf-mini-cart-info">
                                        <a class="title link" asp-controller="product" asp-action="details"->${item.productName}</a>
                                        <div class="meta-variant">${item.colorName}</div>
                                        <div class="price fw-6">$${item.price * item.quantity}</div>
                                        <div class="tf-mini-cart-btns">
                                            <div class="wg-quantity small">
                                                <span onclick="changeQuantity(${item.productVariantId}, -1)" class="btn-quantity minus-btn">-</span>
                                                <input type="number" min="1" name="number" id="productVariantId${item.productVariantId}" value="${item.quantity}">
                                                <span onclick="changeQuantity(${item.productVariantId}, 1)" class="btn-quantity plus-btn">+</span>
                                            </div>
                                            <div onclick="removeFromBasket(${item.productVariantId}, this)" id="removeButtonBasket" class="tf-mini-cart-remove">Remove</div>
                                        </div>
                                    </div>
                                </div>`;
    });
    basketTotalCountHeader.innerText = data.totalCount;
    basketTotalPrice.innerText = data.totalPrice;
}


document.addEventListener('DOMContentLoaded', function () {
    loadBasket();
});

function addToBasket(productIdText, quantityTest) {
    console.log("Product id:");
    console.log(productIdText);
    const test = document.getElementById(productIdText);
    productVariantId = test.value;
    console.log("variant id:")
    console.log(productVariantId);

    console.log(quantityTest);
  
    fetch(`/basket/add?productVariantId=${productVariantId}&quantity=${quantityTest}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (response.ok) {
                 loadBasket();
                alert('Product added to basket!');
            }
            else {
                alert('Failed to add product to basket')
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occured');
        });
}

function removeFromBasket(productVariantId, element) {
    
    fetch('/basket/remove/' + productVariantId, {
        method: 'POST',
        headers: {
            'Content-Type':'application-json'
        }
    })
        .then(response => {
            if (response.ok) {
                loadBasket();
                element.remove();
            }
            else {
                alert('Failed to remove product from basket');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occured');
        })
}

function changeQuantity(productVariantId, change) {
    const productVariantIdInput = document.getElementById(`productVariantId${productVariantId}`);
    const currentQuantity = parseInt(productVariantIdInput.value);

    if (currentQuantity + change < 1) {
        return;
    }

    //productVariantIdInput.value = currentQuantity+change;

    fetch(`/basket/changeQuantity?productVariantId=${productVariantId}&change=${change}`, {
        method: 'POST'
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            loadBasketWithData(data.basketViewModel);
        })
        .catch(error => console.error('Error:', error));
}

function changeQuantityC(productVariantId, change) {
    console.log("test");
    const productVariantIdInput = document.getElementById(`productVariantIdC${productVariantId}`);
    const currentQuantity = parseInt(productVariantIdInput.value);

    if (currentQuantity + change < 1) {
        return;
    }

    //productVariantIdInput.value = currentQuantity+change;

    fetch(`/basket/changeQuantityC?productVariantId=${productVariantId}&change=${change}`, {
        method: 'POST'
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            loadBasketWithData(data.basketViewModel);
        })
        .catch(error => console.error('Error:', error));
}

function updateTotalQuickAdd(productIdText, change) {
    const productQuantityQuickAdd = document.getElementById(`productQuantityQuickAdd${productIdText}`);

    let prevQuantity = parseInt(productQuantityQuickAdd.value);
    console.log(prevQuantity);
    if (prevQuantity + change == 0) {
        return;
    }
    let currentQuantity = prevQuantity + change;
    console.log(currentQuantity);

    const productPriceQuickAdd = parseInt(document.getElementById(`productPriceQuickAdd${productIdText}`).innerText);
    console.log(productPriceQuickAdd);
    const totalPriceQuickAdd = document.getElementById(`totalPriceQuickAdd${productIdText}`);

    const result = currentQuantity*productPriceQuickAdd;

    totalPriceQuickAdd.textContent = "$ " + result.toFixed(2);
    productPriceQuickAdd.textContent = currentQuantity;

    setCurrentQuantity(productIdText, currentQuantity);
}

//function setCurrentQuantity(productIdText, currentQuantity) {
//    console.log("adf");
//    const testInput = document.getElementById(`productPriceQuickAdd${productIdText}`);
//    testInput.value = parseInt(currentQuantity);
//}


function getQuantity(productId, productIdText) {
    var quantity = parseInt(document.getElementById(`productQuantityQuickAdd${productId}`).value);
    console.log(quantity);
    addToBasket(productIdText, quantity);
}

function getQuantityD(productId, productIdText) {
    var quantity = parseInt(document.getElementById(`productQuantityDetails${productId}`).value);
    console.log(quantity);
    addToBasket(productIdText, quantity);
}

function setSelectedColor(variantId, productId, imageName , element) {
    const productImageQuickAdd = document.getElementById(`productImageQuickAdd${productId}`);
    console.log(imageName);
    productImageQuickAdd.src = `/images/products/${imageName}`;

    if (element.value == false)
        return;
        return;
    const hiddenInput = document.getElementById(`product${productId}`);
    hiddenInput.value = variantId;
}

function setSelectedColorD(variantId, productId, element) {
    console.log("test");
    if (element.value == false)
        return;

    const hiddenInput = document.getElementById(`productD${productId}`);
    console.log("set colorda variant id:")
    console.log(variantId)

    hiddenInput.value = variantId;
}
