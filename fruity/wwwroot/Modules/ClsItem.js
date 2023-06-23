let Items = [];
let ClsItem = {
    LoadItems: function () {
        Helper.AjaxCallGet("/api/ItemApi", {}, "json", function (data) {
            let itemHtml1 = "";
            Items = data;
            for (var i = 0; i < data.length; i++) {
                itemHtml1 = itemHtml1 + ClsItem.Templete1(data[i]);
            }
           
            $("#TempleteId").html(itemHtml1);
        }, function () {


        });

    },
    Templete1: function (item) {
        let itembody = "<div class='col-lg-4 col-md-6 text-center _" + item.categoryId + "'>";
        itembody = itembody + "<div class='single-product-item'>";
        itembody = itembody + "<div class='product-image'>";
        itembody = itembody + "<a href='/Items/Details/" + item.itemId + "'><img src='/Images/" + item.imageName + "' alt=''></a></div>";
        itembody = itembody + "<h3>" + item.itemName + "</h3>";
        itembody = itembody + "<p class='product-price'><span>Per Kg</span> " + item.salesPrice + "$ </p>";
        itembody = itembody + " <a href='/Items/AddToCart/" + item.itemId + "' class='cart-btn'><i class='fas fa-shopping-cart'></i> Add to Cart</a></div></div>";
        return itembody;
    },
    FilterItems: function (catId) {
        let newitem = $.grep(Items, function (n, i) {
            return n.categoryId === catId;
        });
        let itemHtml1 = "";
        for (var i = 0; i < newitem.length; i++) {
            itemHtml1 = itemHtml1 + ClsItem.Templete1(newitem[i]);
        }

        $("#TempleteId").html(itemHtml1);
    }
}
ClsItem.LoadItems();