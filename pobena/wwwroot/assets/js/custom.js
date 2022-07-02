$(document).ready(function () {

    //$(document).on("click", ".action-btn", function (e) {
    //    e.preventDefault();
    //    let url = $(this).attr("href");
    //    fetch(url).then(response => response.text()).then(data => {
    //        $(".dropdown-menu").html(data);
    //    })

    //})
    //$(document).on("click", ".action-btn", function (e) {
    //    e.preventDefault()

    //    let url = $("#basketform").attr("action")
    //    let count = $("#productcount").val();
    //    let selectColor = $("#selectColor").val();
    //    let selectSize = $("#selectSize").val();
    //    console.log(selectColor)
    //    console.log(selectSize)
    //    url = url + "?count=" + count + "&colorid=" + selectColor + "&sizeid=" + selectSize;
    //    fetch(url).then(response => {
    //        return response.text();
    //    }).then(data => {
    //        $(".dropdown-menu").html(data)

    //    })
    //})
    $(document).on("click", ".addtocart", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url).then(res => {
            return res.text()
        }).then(data => {
            console.log(data)
            $(".minicart-inner").html(data);
            fetch("/home/count").then(res => {
                return res.text()
            }).then(data => {
                $(".notification").html(data)
            })
        })
    })

    $(".deletebasket").click(function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url).then(response1 => {
            return response1.text();
        }).then(data => {
            fetch("../Basket/GetCard").then(response => response.text()).then(data => $(".basketContainer").html(data))
            fetch("home/count").then(res => {
                return res.text()
            }).then(data => {
                $(".notification").html(data)
            })
            $(".minicart-inner").html(data)
        })
        })
    
    $(document).on("click", ".bdec", function (e) {

        e.preventDefault();

        var id = $(this).next().attr("data-id");
        var color = parseInt($(this).next().attr("data-color"));
        var size = parseInt($(this).next().attr("data-size"));

        var count = parseInt($(this).next().val());

        if (count > 1) {
            count--;
        }

        //var productCount = parseInt($(this).next().attr("data-productCount"));

        //let prodCount = parseInt($(this).next(".prod-count").val());

        //if (prodCount <= 1) {
        //    prodCount = 1
        //}
        //else if (prodCount <= productCount) {
        //    prodCount--;
        //}
        //else {
        //    prodCount = productCount;
        //}

        //var count = prodCount;

        fetch("../../Basket/Update" + "?id=" + id + "&count=" + count + "&color=" + color + "&size=" + size).then(response => {

            fetch("../../Basket/GetBasket").then(response => response.text())
                .then(data => $(".minicart-inner").html(data))
            return response.text()

        }).then(data => $(".basketContainer").html(data))



        //$(this).next(".prod-count").val(prodCount);
    })
    $(document).on("click", ".binc", function (e) {

        e.preventDefault();

        var id = $(this).prev().attr("data-id");
        var color = parseInt($(this).prev().attr("data-color"));
        var size = parseInt($(this).prev().attr("data-size"));

        var count = parseInt($(this).prev().val());
        count++;

        //let prodCount = parseInt($(this).prev(".prod-count").val());
        //if (prodCount < productCount) {
        //    prodCount++;
        //} else {
        //    prodCount = productCount;
        //}
        //var count = prodCount;
        fetch("../../Basket/Update" + "?id=" + id + "&count=" + count + "&color=" + color + "&size=" + size).then(response => {

            fetch("../../Basket/GetBasket").then(response => response.text())
                .then(data => $(".minicart-inner").html(data))
            return response.text()

        }).then(data => $(".basketContainer").html(data))

        //$(this).prev(".prod-count").val(prodCount);
    })
    $(document).on("keyup", ".prod-count", function () {
        var productCount = parseInt($(this).attr("data-productCount"));
        var count;

        if (parseInt($(this).val()) <= parseInt(productCount) && parseInt($(this).val()) > 0) {
            count = parseInt($(this).val());
        }
        else if (parseInt($(this).val()) > parseInt(productCount)) {
            count = parseInt(productCount);
        } else {
            count = 1;
        }

        var id = $(this).attr("data-id");
        var color = parseInt($(this).attr("data-color"));
        var size = parseInt($(this).attr("data-size"));


        fetch("../../Basket/Update" + "?id=" + id + "&count=" + count + "&color=" + color + "&size=" + size).then(response => {

            fetch("../../Basket/GetBasket").then(response => response.text())
                .then(data => $(".minicart-inner").html(data))
            return response.text()

        }).then(data => $(".basketContainer").html(data))

        $(this).val(count);;

    })


    $(document).on("click", ".basketUpdate", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        let color = $(this).parent().parent().parent().find(".color").text()
        let size = $(this).parent().parent().parent().find(".size").text()

        let count = $(this).parent().find(".countInp").val();
        let id = 0;

        if ($(this).hasClass("subCount")) {
            if (count != 1) {
                count--;
            }
            id = $(this).next().attr("data-id");
        }
        else if ($(this).hasClass("addCount")) {
            count++;
            id = $(this).prev().attr("data-id");
        }

        url = "Basket/Update" + "?id=" + id + "&count=" + count + "&color=" + color + "&size=" + size;


        fetch(url).then(response => {
            fetch("Basket/GetBasket").then(response => response.text()).then(data => $(".minicart-content-box").html(data))
            return response.text()

        }).then(data => $(".basketIndexPart").html(data))

        $(".countInp").val(parseFloat(count));
    })

    $(document).on("click", ".deletecard", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => {
            fetch("../../Basket/GetBasket").then(response => response.text()).then(data => $(".minicart-inner").html(data))


            fetch("../../home/count").then(res => {
                return res.text()
            }).then(data => {
                $(".notification").html(data)
            })
            return response.text()
        })
            .then(data => {
                $(".basketContainer").html(data);
            })


    })

    //Shop filter
    $(document).on("click", ".shopFilter", function (e) {
        e.preventDefault();
        if ($(this).hasClass("size")) {
            $(this).toggleClass("active-size");
        }
        if ($(this).hasClass("color")) {
            $(this).toggleClass("active-color");
        }
        if ($(this).hasClass("brand")) {
            if ($(this).hasClass("active-brand")) {
                $(this).removeClass("active-brand");
            } else {
                $(".brand").removeClass("active-brand");
                $(this).addClass("active-brand");
            }
        }
        if ($(this).hasClass("category")) {
            if ($(this).hasClass("active-category")) {
                $(this).removeClass("active-category");
            } else {
                $(".category").removeClass("active-category");
                $(this).addClass("active-category");
            }
        }
        if ($(this).hasClass("price")) {
            if ($(this).hasClass("active-price")) {
                $(this).removeClass("active-price");
            } else {
                $(".price").removeClass("active-price");
                $(this).addClass("active-price");
            }
        }
        ShopFetch();
    })
    $(".selectfilter").change(function () {
        ShopFetch();
    })

    function ShopFetch() {
        let sortby = $(".sortby").find(":selected").val();
        let priceby = $(".sortby").find(":selected").val();
        var sizeIds = document.querySelectorAll(".active-size");
        var colorIds = document.querySelectorAll(".active-color");
        var Sids = "";
        var Cids = "";
        var SPids = "";
        var cat = "";
        var price = "";
        var minP = $("#input-left").val();
        var maxP = $("#input-right").val();
        if ($(".active-category").attr("data-id") != undefined) {
            cat = $(".active-category").attr("data-id");
        }
        if ($(".active-brand").attr("data-id") != undefined) {
            SPids = $(".active-brand").attr("data-id");
        }
        if ($(".active-price").attr("data-id") != undefined) {
            price = $(".active-price").attr("data-id");
        }
        for (var i = 0; i < sizeIds.length; i++) {
            Sids += sizeIds[i].getAttribute("data-id");
        }
        for (var i = 0; i < colorIds.length; i++) {
            Cids += colorIds[i].getAttribute("data-id");
        }

        fetch("../../shop/filter1"
            + "?sizes=" + Sids.split("").toString()
            + "&colors=" + Cids.split("").toString()
            + "&brands=" + SPids
            + "&price=" + price
            + "&sortby=" + parseInt(sortby)
            + "&category=" + cat
            //+ "&minPrice=" + parseInt(minP)
            //+ "&maxPrice=" + parseInt(maxP)
        ).then(res => {
            return res.text();
        }).then(data => {
            fetch("../../shop/filter2"
                + "?sizes=" + Sids.split("").toString()
                + "&colors=" + Cids.split("").toString()
                + "&brands=" + SPids
                + "&price=" + price
                + "&sortby=" + parseInt(sortby)
                + "&category=" + cat
                //+ "&minPrice=" + parseInt(minP)
                //+ "&maxPrice=" + parseInt(maxP)
            ).then(res => {
                return res.text();
            }).then(data => {
                $(".shop-products2").html(data)
            })

            $(".shop-products").html(data)
        })
    }
})
