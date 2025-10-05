function editAddress(addressId) {
    const addressEditTest = document.getElementById(`addressEditTest${addressId}`);

    fetch(`/address/edit/?id=${addressId}`)
        .then(response => response.text())
        .then(html => {
            console.log(html);
            addressEditTest.innerHTML = html;
        });
}

function deleteAddress(id, element) {
    fetch(`/address/delete/${id}`, {
        method: "Post"
    })
        .then(response => response.text())
        .then(data => {
            element.parentNode.parentNode.remove();
        });
}

function closeEditAddress(addressId) {
    const addressEditTest = document.getElementById(`addressEditTest${addressId}`);
    addressEditTest.innerHTML = '';
}