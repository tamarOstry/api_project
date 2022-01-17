window.addEventListener('load', (event) => {
    getProduct();
    getCategory();
});


function getProduct() {
    fetch('../api/products/')
        .then(response => {
            if (response.ok && response.status == 200)
                return response.json();
        })
        .then(data => {
            if (data) {
                data.forEach(p => drowProduct(p));
            }
            else {
                alert("we dont have a products")
            }
        })
    var l = [];
    l = JSON.parse(sessionStorage.getItem('cart'));
    if(l!=null)
        document.getElementById("ItemsCountText").innerHTML = l.length;
    else
      document.getElementById("ItemsCountText").innerHTML = 0;
}

function drowProduct(product) {
    var url = "../images/";
    var elmnt = document.getElementById("temp-card");
    var cln = elmnt.content.cloneNode(true);
    cln.querySelector("img").src = url + product.image;
    cln.querySelector(".price").innerText = product.price+'$';
    cln.querySelector(".description").innerText = product.description;
    cln.querySelector(".nameProduct").innerText = product.productName;
    cln.querySelector("button").addEventListener("click",()=>addToCart(product));
    document.getElementById("PoductList").appendChild(cln);
    var c = parseInt(document.getElementById("counter").innerText);
    if (c > 0) {
        c++;
        document.getElementById("counter").innerHTML =c;}
    else
        document.getElementById("counter").innerHTML = 1;
}


function getCategory() {
    fetch('../api/category/')
        .then(response => {
            if (response.ok && response.status == 200)
                return response.json();
        })
        .then(data => {
            if (data) {
                var CategoryArray = data;
                data.forEach(c => drowCategory(c));
            }
            else {
                alert("we dont have a categories");
            }
        })

}

function drowCategory(category) {
    var elmnt = document.getElementById("temp-category");
    var cln = elmnt.content.cloneNode(true);
    cln.querySelector(".OptionName").innerText = category.categoryName;
    cln.querySelector(".opt").id = category.categoryId;
    cln.querySelector(".lbl").for = category.categoryId;
    cln.querySelector('.opt').addEventListener("change", () => {  
        if (document.getElementById(category.categoryId).checked)
            getProductByCategory(category.categoryId);
        //else {
        //    window.location.href = "";
        //    getProduct();
        //}
    });
    document.getElementById('filters').appendChild(cln);
   

    // cln.querySelector('.opt').addEventListener("change", changeChooseCategory(category.categoryId));
}

//function changeChooseCategory(categoryId) {
//    CategoryArray
//    if (document.getElementById(categoryId).checked)
//        getProductByCategory(categoryId);
//}

function getProductByCategory(id) {
    fetch('../api/products/' + id)
        .then(response => {
            if (response.ok && response.status == 200)
                return response.json();
        })
        .then(data => {
            if (data) {
                document.body.removeChild(document.getElementById("PoductList"));
                c = 0;
                document.getElementById("counter").innerHTML = 0;
                var d = document.createElement('div');
                d.setAttribute("id","PoductList")
                document.body.appendChild(d);
                data.forEach(p => drowProduct(p));
            }
            else {alert("you need to application") }
        })
}


function addToCart(product) {
    var ss = sessionStorage.getItem('cart');
    if (ss) {
        var list =[];
        list = JSON.parse(ss);
        list.push(JSON.stringify(product));
        sessionStorage.setItem('cart', JSON.stringify(list));
        count = JSON.parse(sessionStorage.getItem('count'));
        document.getElementById("ItemsCountText").innerHTML = list.length;
    }
    else { 
        var cart = [];
        cart.push(JSON.stringify(product))
        sessionStorage.setItem('cart', JSON.stringify(cart));
        document.getElementById("ItemsCountText").innerHTML = 1;
    }
}

