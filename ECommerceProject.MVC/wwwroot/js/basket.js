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
                                                <span class="btn-quantity minus-btn">-</span>
                                                <input type="text" name="number" value="${item.quantity}">
                                                <span class="btn-quantity plus-btn">+</span>
                                            </div>
                                            <div class="tf-mini-cart-remove">Remove</div>
                                        </div>
                                    </div>
                                </div>`;
            });
            basketTotalCountHeader.innerText = data.totalCount;
        }).catch(error => {
            console.Error('Error:', error);
        });
}

document.addEventListener('DOMContentLoaded', function () {
    loadBasket();
});

function addToBasket(productVariantElementId) {
    console.log("Product id:");
    console.log(productVariantElementId);
    const test = document.getElementById(productVariantElementId);
    VariantId = test.value;
    console.log("variant id:")
    console.log(VariantId);

    fetch('/basket/add/' + VariantId, {
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

function removeFromBasket(productVariantId) {
    fetch('/basket/remove/' + productVariantId, {
        method: 'POST',
        headers: {
            'Content-Type':'application-json'
        }
    })
        .then(response => {
            if (response.ok) {
                loadBasket();
                element.closest('tr').remove();
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