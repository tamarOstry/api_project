window.addEventListener('load', (event) => {
    myCart();
});

function myCart() {
    var cart = sessionStorage.getItem('cart');
    if (cart) {
        var ListCart = JSON.parse(cart);
        ListCart.forEach(product => {
        var p = JSON.parse(product);
        drowProductFromCart(p);
        });
    }
}


function drowProductFromCart(product) {
    var elmnt = document.getElementById("temp-row");
    var cln = elmnt.content.cloneNode(true);
    var url = "../Images/" + product.image.toString();
    cln.querySelector(".image").style.backgroundImage = "url(" + url + ")";
    //cln.querySelector(".itemNumber").innerText = product.categoryId;
    //cln.querySelector(".itemName").innerText = product.productName;
    cln.querySelector(".price").innerText = product.price + '$';
    cln.querySelector(".descriptionColumn").innerText = product.description;
    cln.getElementById("deleteProduct").addEventListener("click", () => deleteProdFromCart(product.productId));
    document.querySelector("tbody").appendChild(cln);
    document.getElementById("itemCount").innerHTML = parseInt(document.getElementById("itemCount").innerText) + 1;
    document.getElementById("totalAmount").innerHTML = parseInt(document.getElementById("totalAmount").innerText) + product.price;
}

function deleteProdFromCart(productId) {
        var cart = sessionStorage.getItem('cart');
        var ListCart = JSON.parse(cart);
        var newList = [];
        ListCart.forEach(product => {
            var p = JSON.parse(product);
            document.getElementById("itemCount").innerHTML = parseInt(document.getElementById("itemCount").innerText) - 1;
            document.getElementById("totalAmount").innerHTML = parseInt(document.getElementById("totalAmount").innerText) - p.price;
            if (p.productId != productId)
            {
                newList.push(JSON.stringify(p));
            }
            else
            {
                document.querySelector(".items").removeChild(document.querySelector("tbody"));
                var t = document.createElement('tbody');
                document.querySelector(".items").appendChild(t);
            }
        });
        newList.forEach(p => drowProductFromCart(JSON.parse(p)));
        sessionStorage.setItem('cart', JSON.stringify(newList));
    }



function placeOrder() {
    var orderItems = [];
    JSON.parse(sessionStorage.getItem('cart')).forEach(p => {
        var item = {
            "OrderItemId": 0,
            "ProductId": JSON.parse(p).productId,
            "Quantity": 1
        };
        orderItems.push(item);
    });

    var order = {
        "OrderId": 0,
        "OrderDate": new Date(),
        "OrderSum": document.getElementById("totalAmount").innerText,
        "UserId": JSON.parse(sessionStorage.getItem('user')).userId,
        "OrderItems": orderItems
    };

    fetch('../api/orders', {
        headers: {
            'Content-Type': 'application/json',
        },
        method: 'POST',
        body: JSON.stringify(order)
    })
        .then((response) => {
            if (response.ok && response.status == 200)
                return response.json();
            else {
                alert("something is worng!!");
                throw new Error(response.status);
            }
                
        })
        .then(data => {
            if (data)       
            alert("the order :" + data.orderId +"is successfully!!!")
        }).catch((er) => { console.log(er); });
}