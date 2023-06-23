let ClsCategory = {
    Loadcategories: function () {
        Helper.AjaxCallGet("/api/Category", {}, "json", function (data) {
            let Html = "";
            for (var i = 0; i < data.length; i++) {
                Html = Html + ClsCategory.Templete1(data[i]);
            }
            $("#Categoies").html(Html);
        }, function () {

        });
    },
    Templete1: function (cat) {
        let Html = "<li onclick='ClsItem.FilterItems(" + cat.categoryId+")'>" + cat.categoryName + "</li>";
        return Html;
    }
}
ClsCategory.Loadcategories();
