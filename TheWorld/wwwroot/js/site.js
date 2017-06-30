//site.js
(function () {
    // JQuery: query the document for element
    // Dollar sign (JQuery) exposes a number of methods

    // Jquery syntax. Jquery API handles all the cross-browser for you.
    var ele = $("#username");               
    // This syntax may depend on browser capability.
    //var ele = document.getElementById("username");

    // Jquery api handles it.
    ele.text("Zhen Jia");
    // This may depend on browser capability.
    //ele.innerHTML = "Zhen Jia";

    //var main = document.getElementById("main");
    var main = $("#main");

    // An no-name function that is called when mouse enter,
    // event handler
    //main.onmouseenter = function () {
    //    // Different browers implement each api differently.
    //    //main.style.backgroundColor = "#888";
    //    // Edge won't work on this one:
    //    main.style = "background: #888";
    //};

    // Jquery syntax.
    main.on("mouseenter", function () {
        main.css("background-color", "#888");
    });

    //main.onmouseleave = function () {
    //    main.style.backgroundColor = "";
    //}
    main.on("mouseleave", function () {
        main.css("background-color", "");
    })

    var menuItems = $("ul.menu li a");
    menuItems.on("click", function () {
        var me = $(this);
        alert(me.text()); 
    });

    var $sidebarAndWrapper = $("#sidebar,#wrapper");
    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).text("Show sidebar");
        }
        else {
            $(this).text("Hide sidebar");
        }
    });
        
})();
