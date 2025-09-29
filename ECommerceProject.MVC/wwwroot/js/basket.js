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
                                                <span onclick="changeQuantity(${item.productVariantId}, 1)" class="btn-quantity minus-btn">-</span>
                                                <input type="text" id="productVariantId${item.productVariantId}" name="number" value="${item.quantity}">
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
                                                <input type="text" name="number" id="productVariantId${item.productVariantId}" value="${item.quantity}">
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

    /* const quantitySpanTest = document.getElementById(`productQuantityQuickAdd${productId}`);*/
    console.log(quantityTest);
  



    /*`/basket/changeQuantity?productVariantId=${productVariantId}&change=${change}`,*/
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

function setSelectedColor(variantId, productId, element) {
    if (element.value == false)
        return;
    const hiddenInput = document.getElementById(`product${productId}`);
    hiddenInput.value = variantId;
}

function changeQuantity(productVariantId, change) {
    const productVariantIdInput = document.getElementById(`productVariantId${productVariantId}`);
    const currentQuantity = parseInt(productVariantIdInput.value);

    if (currentQuantity + change < 1) {
        return;
    }

    productVariantIdInput.value = currentQuantity.change;

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

function updateTotalQuickAdd(productId, change) {

    const productQuantityQuickAdd = parseInt(document.getElementById(`productQuantityQuickAdd${productId}`).value)+change;
    const productPriceQuickAdd = parseInt(document.getElementById(`productPriceQuickAdd${productId}`).innerText);
    const totalPriceQuickAdd = document.getElementById(`totalPriceQuickAdd${productId}`);

    const result = productQuantityQuickAdd*productPriceQuickAdd;

    totalPriceQuickAdd.textContent="$ "+result.toFixed(2);
}

function getQuantity(productId, productIdText) {
    var quantityTest = parseInt(document.getElementById(`productQuantityQuickAdd${productId}`).value);
    console.log(quantityTest);
    addToBasket(productIdText, quantityTest);
}

